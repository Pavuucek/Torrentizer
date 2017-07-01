/*
 * Copyright (c) 2015 Michal Kuncl <michal.kuncl@gmail.com> http://www.pavucina.info
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction,
 * including without limitation the rights to use, copy, modify, merge, publish, distribute,
 * sublicense, and/or sell copies of the Software, and to permit persons to whom the Software
 * is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MonoTorrent;
using MonoTorrent.BEncoding;
using MonoTorrent.Common;
using Torrentizer.Properties;

namespace Torrentizer
{
    public partial class MainWindow : Form
    {
        public readonly LogWindow Log = new LogWindow();
        private string _lastHashedFile = string.Empty;
        private TorrentCreator _t;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Log.AddToTop = false;
            Log.Log($"App Startup, version {Application.ProductVersion}");
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
#if(DEBUG)
            Log.Show();
#endif
            Focus();
            comboPieceLength.SelectedIndex = 0;
        }

        private void MainWindow_Move(object sender, EventArgs e)
        {
            Log.Left = Right;
            Log.Top = Top;
        }

        private static long GetPieceLength(string inText)
        {
            // don't bother with auto mode
            if (inText.ToLower() == "auto") return 0;
            // replacing useless stuff first
            inText = inText.Replace(" ", "").ToLower();
            var justNumbers = inText.Replace("kb", "");
            justNumbers = justNumbers.Replace("mb", "");
            justNumbers = justNumbers.Replace("gb", "");
            long number;
            try
            {
                number = Convert.ToInt64(justNumbers);
            }
            catch (Exception)
            {
                number = 0;
            }
            var justUnits = string.Empty;
            foreach (var c in inText)
                if (!char.IsNumber(c)) justUnits += c;
            switch (justUnits)
            {
                case "kb":
                    number = number * 1024;
                    break;
                case "mb":
                    number = number * 1024 * 1024;
                    break;
                case "gb":
                    number = number * 1024 * 1024 * 1024;
                    break;
            }
            return number;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // checks first
            if (string.IsNullOrWhiteSpace(comboAdd.Text))
            {
                MessageBox.Show(Resources.MainWindow_btnCreate_Click_SelectFileOrFolder);
                return;
            }
            if (string.IsNullOrWhiteSpace(textTrackers.Text))
            {
                MessageBox.Show(Resources.MainWindow_btnCreate_Click_AtLeastOneTrackerRequired);
                return;
            }
            // we want user to wait patiently so disable everything
            Enabled = false;
            // let's go!
            Log.Log("Creating torrent " + dialogSaveTorrent.FileName);

            // try to guess torrent name and add .torrent extension
            Log.Log("Adding files...");
            var soubory = new TorrentFileSource(comboAdd.Text);
            Log.Log($"... will contain {soubory.Files.Count()} files.");
            dialogSaveTorrent.FileName = soubory.TorrentName + ".torrent";
            // prompt to save torrent
            if (dialogSaveTorrent.ShowDialog() != DialogResult.OK)
            {
                Enabled = true;
                return;
            }
            _t = new TorrentCreator();
            _t.SetCustom(new BEncodedString("name"), new BEncodedString(dialogSaveTorrent.FileName));
            _t.CreatedBy = Application.ProductName + " " + Application.ProductVersion;
            // is private?
            _t.Private = checkPrivate.Checked;
            if (GetPieceLength(comboPieceLength.Text) > 0) _t.PieceLength = GetPieceLength(comboPieceLength.Text);
            else _t.PieceLength = TorrentCreator.RecommendedPieceSize(soubory.Files);
            Log.Log($"Piece length: {_t.PieceLength}");
            // related: RSS
            if (!string.IsNullOrWhiteSpace(textRss.Text))
                _t.SetCustom(new BEncodedString("rss"), new BEncodedString(textRss.Text));
            // related: web
            if (!string.IsNullOrWhiteSpace(textWeb.Text))
                _t.SetCustom(new BEncodedString("website"), new BEncodedString(textWeb.Text));
            // related: similar torrents
            if (!string.IsNullOrWhiteSpace(textRelatedTorrents.Text))
                _t.SetCustom(new BEncodedString("similar_torrents"), new BEncodedString(textRelatedTorrents.Text));
            // trackers
            foreach (var line in textTrackers.Lines)
                _t.Announces.Add(new RawTrackerTier(new[] {line}));
            // webseeds
            if (!string.IsNullOrWhiteSpace(textWebSeeds.Text))
            {
                var be = new BEncodedList();
                foreach (var line in textWebSeeds.Lines)
                    be.Add(new BEncodedString(line));
                _t.SetCustom(new BEncodedString("url-list"), be);
            }
            // comment
            if (!string.IsNullOrWhiteSpace(textComment.Text)) _t.Comment = textComment.Text;
            // publisher, example: Michal via Torrentizer version 1.0.0.0
            _t.Publisher = $"{Environment.UserName} via {Application.ProductName} version {Application.ProductVersion}";
            // shameless ad goes here:
            _t.PublisherUrl = "http://github.com/pavuucek/Torrentizer";
            // not sure what this does...
            _t.StoreMD5 = true;

            soubory.TorrentName = textTorrentName.Text;
            _t.Hashed += t_Hashed;
            Log.Log("Hashing...");
            _t.BeginCreate(soubory, AfterHashing, null);
        }

        private void t_Hashed(object sender, TorrentCreatorEventArgs e)
        {
            if (e.CurrentFile != _lastHashedFile)
#if (DEBUG)
                Log.Invoke((MethodInvoker) (() =>
                {
                    Log.Log($"Hashing file {Math.Round(e.FileCompletion)}% {e.CurrentFile}");
                    _lastHashedFile = e.CurrentFile;
                }));
#endif
            /*Log.Invoke((MethodInvoker)(() =>
            {
                Log.Log(string.Format("Overall {0}% hashed", e.OverallCompletion));
            }));
            Log.Invoke((MethodInvoker)(() =>
            {
                Log.Log(string.Format("Total data to hash: {0}", e.OverallSize));
            }));*/
            progressBar1.Invoke((MethodInvoker) (() => { progressBar1.Value = (int) e.OverallCompletion; }));
        }

        private void AfterHashing(IAsyncResult ar)
        {
            try
            {
                using (var stream = File.OpenWrite(dialogSaveTorrent.FileName))
                {
                    _t.EndCreate(ar, stream);
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                Log.Invoke((MethodInvoker) (() => { Log.Log($"Error creating torrent: {ex}"); }));
#endif
            }
            Invoke((MethodInvoker) (() =>
            {
                Log.Log("Finished creating torrent!");
                Enabled = true;
                MessageBox.Show(Resources.MainWindow_AfterHashing_TorrentCreated);
                progressBar1.Value = 0;
            }));
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            if (dialogAddFile.ShowDialog() == DialogResult.OK)
            {
                comboAdd.Text = dialogAddFile.FileName;
                textTorrentName.Text = Path.GetFileName(dialogAddFile.FileName);
            }
        }

        private void buttonAddFolder_Click(object sender, EventArgs e)
        {
            if (dialogAddFolder.ShowDialog() == DialogResult.OK)
            {
                comboAdd.Text = dialogAddFolder.SelectedPath;
                textTorrentName.Text = new DirectoryInfo(dialogAddFolder.SelectedPath).Name;
            }
        }

    }
}