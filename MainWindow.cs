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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ArachNGIN.Tracer;
using ArachNGIN.Tracer.Helpers;
using MonoTorrent;
using MonoTorrent.BEncoding;
using MonoTorrent.Common;
using Torrentizer.Properties;

namespace Torrentizer
{
    public partial class MainWindow : Form
    {
        private readonly LogWindow log = new LogWindow();
        private string lastHashedFile = string.Empty;
        private TorrentCreator t;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            log.AddToTop = false;
            Tracer.Trace(
                $"App Startup, version { /*Application.ProductVersion*/Assembly.GetExecutingAssembly().GetName().Version}");
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
#if(DEBUG)
            log.Show();
#endif
            Focus();
            comboPieceLength.SelectedIndex = 0;
        }

        private void MainWindow_Move(object sender, EventArgs e)
        {
            log.Left = Right;
            log.Top = Top;
        }

        private static long GetPieceLength(string inText)
        {
            var intext = inText;
            // don't bother with auto mode
            if (intext.ToLowerInvariant() == "auto") return 0;
            // replacing useless stuff first
            intext = intext.Replace(" ", "").ToLower(CultureInfo.InvariantCulture);
            var justNumbers = intext.Replace("kb", "");
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

            var sb = new StringBuilder();
            foreach (var c in intext)
                if (!char.IsNumber(c))
                    sb.Append(c);
            var justUnits = sb.ToString();
            if (justUnits == "kb")
                number = number * 1024;
            else if (justUnits == "mb")
                number = number * 1024 * 1024;
            else if (justUnits == "gb") number = number * 1024 * 1024 * 1024;

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

            // prompt to save torrent
            // do nothing before this!
            if (dialogSaveTorrent.ShowDialog() != DialogResult.OK)
            {
                Enabled = true;
                return;
            }

            // try to guess torrent name and add .torrent extension
            Tracer.Trace("Adding files...");
            var soubory = new TorrentFileSource(comboAdd.Text);
            Tracer.Trace($"... will contain {soubory.Files.Count()} files.");
            dialogSaveTorrent.FileName = soubory.TorrentName + ".torrent";

            // let's go!
            Tracer.Trace("Creating torrent " + dialogSaveTorrent.FileName);

            t = new TorrentCreator();
            t.SetCustom(new BEncodedString("name"), new BEncodedString(dialogSaveTorrent.FileName));
            t.CreatedBy = Application.ProductName + " " + /*Application.ProductVersion*/
                           Assembly.GetExecutingAssembly().GetName().Version;
            // is private?
            t.Private = checkPrivate.Checked;
            if (GetPieceLength(comboPieceLength.Text) > 0) t.PieceLength = GetPieceLength(comboPieceLength.Text);
            else t.PieceLength = TorrentCreator.RecommendedPieceSize(soubory.Files);
            Tracer.Trace(TracerLevel.Debug, $"Piece length: {t.PieceLength}");
            // related: RSS
            if (!string.IsNullOrWhiteSpace(textRss.Text))
                t.SetCustom(new BEncodedString("rss"), new BEncodedString(textRss.Text));
            // related: web
            if (!string.IsNullOrWhiteSpace(textWeb.Text))
                t.SetCustom(new BEncodedString("website"), new BEncodedString(textWeb.Text));
            // related: similar torrents
            if (!string.IsNullOrWhiteSpace(textRelatedTorrents.Text))
                t.SetCustom(new BEncodedString("similar_torrents"), new BEncodedString(textRelatedTorrents.Text));
            // trackers
            foreach (var line in textTrackers.Lines)
                t.Announces.Add(new RawTrackerTier(new[] {line}));
            // webseeds
            if (!string.IsNullOrWhiteSpace(textWebSeeds.Text))
            {
                var be = new BEncodedList();
                foreach (var line in textWebSeeds.Lines)
                    be.Add(new BEncodedString(line));
                t.SetCustom(new BEncodedString("url-list"), be);
            }

            // comment
            if (!string.IsNullOrWhiteSpace(textComment.Text)) t.Comment = textComment.Text;
            // publisher, example: Michal via Torrentizer version 1.0.0.0
            t.Publisher =
                $"{Environment.UserName} via {Application.ProductName} version { /*Application.ProductVersion*/Assembly.GetExecutingAssembly().GetName().Version}";
            // shameless ad goes here:
            t.PublisherUrl = "http://github.com/pavuucek/Torrentizer";
            // not sure what this does...
            t.StoreMD5 = true;

            soubory.TorrentName = textTorrentName.Text;
            t.Hashed += (o, args) =>
            {
                if (args.CurrentFile != lastHashedFile)
                    log.Invoke((MethodInvoker) (() =>
                    {
                        Tracer.Trace(TracerLevel.Debug,
                            $"Hashing file {Math.Round(args.FileCompletion)}% {args.CurrentFile}");
                        lastHashedFile = args.CurrentFile;
                    }));
                progressBar1.Invoke((MethodInvoker) (() => { progressBar1.Value = (int) args.OverallCompletion; }));
            };
            Tracer.Trace("Hashing...");
            t.BeginCreate(soubory, AfterHashing, null);
        }

        private void AfterHashing(IAsyncResult ar)
        {
            try
            {
                using (var stream = File.OpenWrite(dialogSaveTorrent.FileName))
                {
                    t.EndCreate(ar, stream);
                }
            }
            catch (Exception ex)
            {
                log.Invoke((MethodInvoker) (() =>
                {
                    Tracer.Trace(TracerLevel.Error, "Error creating torrent.");
                    Tracer.Trace(ex);
                }));
            }

            Invoke((MethodInvoker) (() =>
            {
                Tracer.Trace("Finished creating torrent!");
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