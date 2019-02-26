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

using System.Windows.Forms;
using ArachNGIN.Tracer;
using ArachNGIN.Tracer.Handlers;
using ArachNGIN.Tracer.Helpers;
using ArachNGIN.Tracer.MessageFormat;

namespace Torrentizer
{
    public partial class LogWindow : Form, ITracerHandler
    {
        public bool AddToTop { get; set; } = true;


        public LogWindow()
        {
            InitializeComponent();
            Tracer.CurrentLevel = TracerLevel.Trace;
            Tracer.AddHandler(new DebugHandler());
            Tracer.AddHandler(this);
            Tracer.AddHandler(new FileHandler(new DebugMessageFormat()));
        }

        private void Log(string what)
        {
            if (AddToTop)
            {
                logBox.Items.Insert(0, what);
            }
            else
            {
                logBox.Items.Add(what);
                logBox.TopIndex = logBox.Items.Count - 1;
            }

            Application.DoEvents();
        }

        private readonly IMessageFormat messageFormat = new DebugMessageFormat();

        public void Trace(TracerMessage tracerMessage)
        {
            Log(messageFormat.Format(tracerMessage));
        }
    }
}