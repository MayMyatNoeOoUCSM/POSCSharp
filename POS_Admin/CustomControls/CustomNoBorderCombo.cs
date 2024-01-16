//<copyright file ="CustomNoBorderCombo.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2020  All Rights Reserved
//</copyright>
//<author> NAWZINMARLARWIN\Naw Zin Marlar Win </author>
//<date>12/11/2020</date>

namespace POS_Admin.CustomControls
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="CustomCombo" />.
    /// </summary>
    public partial class CustomNoBorderCombo : ComboBox
    {
        /// <summary>
        /// Defines the BorderBrush.
        /// </summary>
        private Brush BorderBrush = new SolidBrush(SystemColors.Window);

        /// <summary>
        /// Defines the ArrowBrush.
        /// </summary>
        private Brush ArrowBrush = new SolidBrush(SystemColors.ControlText);

        /// <summary>
        /// Defines the DropButtonBrush.
        /// </summary>
        private Brush DropButtonBrush = new SolidBrush(SystemColors.Control);

        /// <summary>
        /// Defines the _ButtonColor.
        /// </summary>
        private Color _ButtonColor = SystemColors.Control;

        /// <summary>
        /// Gets or sets the ButtonColor.
        /// </summary>
        public Color ButtonColor
        {
            get { return _ButtonColor; }
            set
            {
                _ButtonColor = value;
                DropButtonBrush = new SolidBrush(this.ButtonColor);
                this.Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomNoBorderCombo"/> class.
        /// </summary>
        public CustomNoBorderCombo()
        {
            InitializeComponent();
            // Set OwnerDrawVariable to indicate we will manually draw all elements.
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;

            // Hook into our DrawItem & MeasureItem events
            this.DrawItem +=
                new DrawItemEventHandler(ComboBox_DrawItem);
            BorderColor = Color.White;
        }

        /// <summary>
        /// Defines the _textAlign.
        /// </summary>
        private StringAlignment _textAlign = StringAlignment.Center;

        /// <summary>
        /// Gets or sets the TextAlign.
        /// </summary>
        [Description("String Alignment")]
        [Category("CustomFonts")]
        [DefaultValue(typeof(StringAlignment))]
        public StringAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;
            }
        }

        /// <summary>
        /// Defines the _textYOffset.
        /// </summary>
        private int _textYOffset = 0;

        /// <summary>
        /// Gets or sets the TextYOffset.
        /// </summary>
        [Description("When using a non-centered TextAlign, you may want to use TextYOffset to manually center the Item text.")]
        [Category("CustomFonts")]
        [DefaultValue(typeof(int))]
        public int TextYOffset
        {
            get { return _textYOffset; }
            set
            {
                _textYOffset = value;
            }
        }

        /// <summary>
        /// Defines the myFont.
        /// </summary>
        public Font myFont;

        /// <summary>
        /// The ComboBox_DrawItem.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DrawItemEventArgs"/>.</param>
        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            // Draw the background
            e.DrawBackground();

            // Draw the items
            if (e.Index >= 0)
            {
                // Set the string format to our desired format (Center, Near, Far)
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Near;

                // Set the brush the same as our ForeColour
                Brush brush = new SolidBrush(this.ForeColor);

                // If this item is selected, draw the highlight
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    brush = SystemBrushes.Control;
                }

                // Draw our string including our offset.
                e.Graphics.DrawString(this.GetItemText(Items[e.Index]), this.Font, brush,
                    new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), sf);
                e.DrawFocusRectangle();
            }
        }

        /// <summary>
        /// Defines the WM_PAINT.
        /// </summary>
        private const int WM_PAINT = 0xF;

        /// <summary>
        /// The WndProc.
        /// </summary>
        /// <param name="m">The m<see cref="Message"/>.</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                using (var g = Graphics.FromHwnd(Handle))
                {
                    if (this.BorderColor == Color.White)
                    {
                        // Uncomment this if you don't want the "highlight border".                  
                        using (var p = new Pen(this.BorderColor, 1))
                        {
                            g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                        }

                        g.FillRectangle(BorderBrush, this.ClientRectangle);
                        Rectangle rect = new Rectangle(this.Width - 1, 3, 1, this.Height - 6);
                        g.FillRectangle(Brushes.White, rect);
                        System.Drawing.Drawing2D.GraphicsPath pth = new System.Drawing.Drawing2D.GraphicsPath();
                        PointF TopLeft = new PointF(this.Width - 13, (this.Height - 5) / 2);
                        PointF TopRight = new PointF(this.Width - 6, (this.Height - 5) / 2);
                        PointF Bottom = new PointF(this.Width - 9, (this.Height + 2) / 2);
                        pth.AddLine(TopLeft, TopRight);
                        pth.AddLine(TopRight, Bottom);

                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        ArrowBrush = new SolidBrush(SystemColors.ControlText);
                        //Draw the arrow
                        g.FillPath(ArrowBrush, pth);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the BorderColor.
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "White")]
        public Color BorderColor { get; set; }

        /// <summary>
        /// The OnPaint.
        /// </summary>
        /// <param name="pe">The pe<see cref="PaintEventArgs"/>.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
