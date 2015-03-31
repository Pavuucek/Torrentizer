using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var t = new TorrentCreator();
            t.CreatedBy = "torrentizer pyčo!";
            t.SetCustom(new BEncodedString("rss"), new BEncodedString("rsssurl"));
            t.SetCustom(new BEncodedString("url-list"),
                new BEncodedList()
                {
                    new BEncodedString("webseed1"),
                    new BEncodedString("webseed2"),
                    new BEncodedString("webseeeeeeeed3")
                });
            t.Comment = "komment pyčo!";
            t.PieceLength = 128*1024;
            t.Publisher = "publisher";
            t.StoreMD5 = true;
            t.Announces.Add(new RawTrackerTier(new string[] {"tier1.anounce1", "tier1.nounce2"}));
            t.Announces.Add(new RawTrackerTier(new string[] {"tier2.announce1"}));

            var soubory = new TorrentFileSource(".\\");
            soubory.TorrentName = "bezejmeeeeenaaaaaa";
            t.Create(soubory, "a.torrent");
            MessageBox.Show("a");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Log.Log("App Startup");
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            Log.Show();
            Focus();
            comboPieceLength.SelectedIndex = 0;
            Log.Log("show");
            Log.Log("test: "+GetPieceLength("auto").ToString());
            Log.Log("test: " + GetPieceLength("16 mB").ToString());
            Log.Log("test: " + GetPieceLength("16 gB").ToString());
            Log.Log("test: " + GetPieceLength("16").ToString());
        }

        private void MainWindow_Move(object sender, EventArgs e)
        {
            Log.Left = Right; //Left + Width;
            Log.Top = Top;
        }

        private long GetPieceLength(string inText)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
