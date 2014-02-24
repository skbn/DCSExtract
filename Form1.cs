using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DCS;

namespace DCSExtractGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool m_Tracked = false;
        private bool m_ReScan = false;
        private Thread m_Search = null;
        private Object m_Lock = new Object();

        private void Clear()
        {
            uv26.Text = "";
            pvi_upleft.Text = "";
            pvi_up.Text = "";
            pvi_upright.Text = "";
            pvi_downleft.Text = "";
            pvi_down.Text = "";
            pvi_downright.Text = "";
            store.Text = "";
            remain.Text = "";
            rounds.Text = "";
            lblMessage.Text = "";
            m_Tracked = false;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            m_Search = new Thread(new ThreadStart(Search));
            m_Search.Start();
            main.Start();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (m_Search != null) m_Search.Abort();
        }

        private void Search()
        {
            while (true)
            {
                Thread.Sleep(50);

                if (!DCSExtract.exist_dcs())
                {
                    lock (m_Lock)
                    {
                        m_ReScan = false;
                        m_Tracked = false;
                    }

                    continue;
                }

                DCSExtract.start_capture();

                if (!DCSExtract.exist_ka50())
                {
                    lock (m_Lock)
                    {
                        m_Tracked = false;
                        m_ReScan = false;
                    }

                    continue;
                }

                lock (m_Lock)
                {
                    m_Tracked = true;
                }

                while (true)
                {
                    Thread.Sleep(50);

                    lock (m_Lock)
                    {
                        if (m_ReScan)
                        {
                            m_Tracked = false;
                            m_ReScan = false;
                            break;
                        }
                    }
                }
            }
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (!DCSExtract.exist_dcs())
            {
                lock (m_Lock)
                {
                    m_ReScan = false;
                    m_Tracked = false;
                }

                Clear();
                this.Text = "Ka50 - No detected";

                return;
            }

            lock (m_Lock)
            {
                if (!m_Tracked)
                {
                    this.Text = "Ka50 - Tracking";
                    return;
                }
                else
                {
                    this.Text = "Ka50 - OK";
                }
            }

            string uv = "";
            bool ok = DCSExtract.ScanUV26(ref uv);

            int upleft = 0;
            string up = "";
            int upright = 0;
            int downleft = 0;
            string down = "";
            int downright = 0;

            ok = DCSExtract.ScanPVI(ref upleft, ref up, ref upright, ref downleft, ref down, ref downright);

            string left = "";
            int middle = 0;
            int right = 0;

            ok = DCSExtract.ScanPui800(ref left, ref middle, ref right);

            string mem = "";
            string que = "";
            string fail = "";
            string msg = "";

            ok = DCSExtract.ScanEkran(ref mem, ref que, ref fail, ref msg);

            if (!ok)
            {
                lock (m_Lock)
                {
                    m_ReScan = true;
                    return;
                }
            }

            uv26.Text = (uv != "") ? uv.ToString() : "";

            pvi_upleft.Text = (upleft != -1) ? "-" : "";
            pvi_up.Text = (up != "") ? up.ToString() : "";
            pvi_upright.Text = (upright != -1) ? upright.ToString() : "";

            pvi_downleft.Text = (downleft != -1) ? "-" : "";
            pvi_down.Text = (down != "") ? down.ToString() : "";
            pvi_downright.Text = (downright != -1) ? downright.ToString() : "";

            store.Text = (left != "") ? left : "";
            remain.Text = (middle != -1) ? middle.ToString() : "";
            rounds.Text = (right != -1) ? right.ToString() : "";

            lblQueue.ForeColor = (que != "") ? Color.Red : Color.LightGray;
            lblMemory.ForeColor = (mem != "") ? Color.Red : Color.LightGray;
            lblFailure.ForeColor = (fail != "") ? Color.Red : Color.LightGray;
            lblMessage.Text = (msg != "") ? msg : "";
        }
    }
}
