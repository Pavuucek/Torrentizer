using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MonoTorrent;
using MonoTorrent.BEncoding;
using MonoTorrent.Common;

namespace Torrentizer
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public LogWindow Log = new LogWindow();

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Log.AddToTop = false;
            Log.Log(string.Format("App Startup, version {0}", Application.ProductVersion));
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
            foreach (char c in inText)
            {
                if (!char.IsNumber(c)) justUnits += c;
            }
            switch (justUnits)
            {
                case "kb":
                    number = number*1024;
                    break;
                case "mb":
                    number = number*1024*1024;
                    break;
                case "gb":
                    number = number*1024*1024*1024;
                    break;
            }
            return number;
        }

        
        private TorrentCreator _t;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            _t = new TorrentCreator();
            _t.CreatedBy = Application.ProductName + " " + Application.ProductName;
            // is private?
            _t.Private = checkPrivate.Checked;
            if (GetPieceLength(comboPieceLength.Text) > 0) _t.PieceLength = GetPieceLength(comboPieceLength.Text)
            // related: RSS
            if (!string.IsNullOrWhiteSpace(textRss.Text))
                _t.SetCustom(new BEncodedString("rss"), new BEncodedString(textRss.Text));
            // related: web
            if(!string.IsNullOrWhiteSpace(textWeb.Text))
                _t.SetCustom(new BEncodedString("website"), new BEncodedString(textWeb.Text));
            // related: similar torrents
            if (!string.IsNullOrWhiteSpace(textRelatedTorrents.Text))
                _t.SetCustom(new BEncodedString("similar_torrents"), new BEncodedString(textRelatedTorrents.Text));
            // trackers
            foreach (var line in textTrackers.Lines)
            {
                _t.Announces.Add(new RawTrackerTier(new string[] {line}));
            }
            // webseeds
            if (!string.IsNullOrWhiteSpace(textWebSeeds.Text))
            {
                var be = new BEncodedList();
                foreach (var line in textWebSeeds.Lines)
                {
                    be.Add(new BEncodedString(line));
                }
                _t.SetCustom(new BEncodedString("url-list"), be);
            }
            // comment
            if (!string.IsNullOrWhiteSpace(textComment.Text)) _t.Comment = textComment.Text;
            // publisher, example: Michal via Torrentizer version 1.0.0.0
            _t.Publisher = string.Format("{0} via {1} version {2}",
                Environment.UserName, Application.ProductName,
                Application.ProductVersion);
            // shameless ad goes here:
            _t.PublisherUrl = "http://github.com/pavuucek/Torrentizer";
            // not sure what this does...
            _t.StoreMD5 = true;

            var soubory = new TorrentFileSource("d:\\xx\\dht.dat");
            //soubory.TorrentName = "bezejmeeeeenaaaaaa";
            _t.Hashed += t_Hashed;
            Log.Log("Hashing...");
            _t.Create(soubory, "a.torrent");
        }

        void t_Hashed(object sender, TorrentCreatorEventArgs e)
        {

            Log.Invoke((MethodInvoker) (() =>
            {
                Log.Log(string.Format("Hashing file {0}", e.CurrentFile));
            }));
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

        private void CreateProgress(IAsyncResult ar)
        {
            try
            {
                using (var stream = File.OpenWrite("a.torrent")) _t.EndCreate(ar, stream);
            }
            catch (Exception ex)
            {
                Log.Invoke((MethodInvoker) (() =>
                {
                    Log.Log(string.Format("Error creating torrent: {0}", ex));
                }));
            }
        }
    }
}
