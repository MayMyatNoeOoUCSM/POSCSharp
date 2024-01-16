﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Admin.CustomControls
{
    public partial class CustomPaddingTextBox : TextBox
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hwnd, int msg,
        int wParam, int lParam);
        private const int EM_SETMARGINS = 0xd3;
        private const int EC_RIGHTMARGIN = 2;
        private const int EC_LEFTMARGIN = 1;

        private int p = 5;
        public CustomPaddingTextBox() :base()
        {
            //InitializeComponent();
            var b = new Label { Dock = DockStyle.Bottom, Height = 0, BackColor = Color.Gray };
            var l = new Label { Dock = DockStyle.Left, Width = p, BackColor = Color.White };
            var r = new Label { Dock = DockStyle.Right, Width = p, BackColor = Color.White };
            AutoSize = false;
            Padding = new Padding(5);
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            Controls.AddRange(new Control[] { l, r, b });
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetMargin();
        }
        private void SetMargin()
        {
            SendMessage(Handle, EM_SETMARGINS, EC_RIGHTMARGIN, p << 16);
            SendMessage(Handle, EM_SETMARGINS, EC_LEFTMARGIN, p);

        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
