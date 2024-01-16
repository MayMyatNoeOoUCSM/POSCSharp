using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Admin.CustomControls
{
    public partial class CustomImageDatePicker : DateTimePicker
    {
        public CustomImageDatePicker():base()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.DrawLine(Pens.White, 0, this.ClientSize.Height - 1, this.ClientSize.Width, this.ClientSize.Height - 1);
            pe.Graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.Black), 0, 0);
            pe.Graphics.DrawImage(Properties.Resources.calendar, new Point(this.ClientRectangle.X -5 + this.ClientRectangle.Width - 16, this.ClientRectangle.Y ));
        }
    }
}
