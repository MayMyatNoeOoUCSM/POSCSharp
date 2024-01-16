//<copyright file ="BaseForm.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2020  All Rights Reserved
//</copyright>
//<author> NAWZINMARLARWIN\Naw Zin Marlar Win </author>
//<date>11/6/2020</date>

namespace POS.Views
{
    using POS_Admin.Utilities;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="BaseForm" />.
    /// </summary>
    public partial class BaseForm : Form
    {
        /// <summary>
        /// Gets or sets the BorderColor.
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// Gets or sets the BorderWeight.
        /// </summary>
        public int BorderWeight { get; set; }

        /// <summary>
        /// The OnPaint.
        /// </summary>
        /// <param name="e">The e<see cref="PaintEventArgs"/>.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                BorderColor, BorderWeight, ButtonBorderStyle.Solid,
                BorderColor, BorderWeight, ButtonBorderStyle.Solid,
                BorderColor, BorderWeight, ButtonBorderStyle.Solid,
                BorderColor, BorderWeight, ButtonBorderStyle.Solid);
            base.OnPaint(e);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseForm"/> class.
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
            int style = FormUtility.GetWindowLong(this.Handle, FormUtility.GWL_EXSTYLE);
            style |= FormUtility.WS_EX_COMPOSITED;
            FormUtility.SetWindowLong(this.Handle, FormUtility.GWL_EXSTYLE, style);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BorderColor = SystemColors.ControlDarkDark;
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// The Label_MouseHover.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        public void Label_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// The Label_MouseLeave.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        public void Label_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// The LabelColor_MouseHover.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        public void LabelColor_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black; //new color
        }

        /// <summary>
        /// The LabelColor_MouseLeave.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        public void LabelColor_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.White; //new color
        }

        /// <summary>
        /// The ButtonColor_MouseHover.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        public void ButtonColor_MouseHover(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = Color.Black; //new color
        }

        /// <summary>
        /// The LabelColor_MouseLeave.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        public void ButtonColor_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = Color.White; //new color
        }

        /// <summary>
        /// Gets the CreateParams.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        /// <summary>
        /// The InitializeComponent.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.DoubleBuffered = true;
            this.Name = "BaseForm";
            this.ResumeLayout(false);
        }
    }
}
