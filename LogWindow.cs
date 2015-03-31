using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Torrentizer
{
    public partial class LogWindow : Form
    {
        public LogWindow()
        {
            InitializeComponent();
        }

        public bool AddToTop = true;

        public void Log(string what)
        {
            what = DateTime.Now + " " + what;
            if (AddToTop) logBox.Items.Insert(0, what);
            else
            {
                logBox.Items.Add(what);
                ScrollControlIntoView(logBox);
            }
            Application.DoEvents();
        }
    }
}
