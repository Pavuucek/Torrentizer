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
            Log.Log("App Startup: " + DateTime.Now);
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            Log.Show();
            Log.Log("show");
        }

        private void MainWindow_Move(object sender, EventArgs e)
        {
            Log.Left = Right; //Left + Width;
            Log.Top = Top;
        }
    }
}
