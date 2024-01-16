//<copyright file ="FormUtility.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2020  All Rights Reserved
//</copyright>
//<author> NAWZINMARLARWIN\Naw Zin Marlar Win </author>
//<date>12/11/2020</date>

namespace POS_Admin.Utilities
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="FormUtility" />.
    /// </summary>
    public static class FormUtility
    {
        /// <summary>
        /// The ScaleImage.
        /// </summary>
        /// <param name="image">The image<see cref="Image"/>.</param>
        /// <param name="maxWidth">The maxWidth<see cref="int"/>.</param>
        /// <param name="maxHeight">The maxHeight<see cref="int"/>.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }
        internal static readonly int GWL_EXSTYLE = -20;
        internal static readonly int WS_EX_COMPOSITED = 0x02000000;

        [DllImport("user32")]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
       
        /// <summary>
        /// The AppReloader.
        /// </summary>
        public static void AppReloader()
        {
            //Start a new instance of the current program
            Process.Start(Application.ExecutablePath);

            //close the current application process
            Process.GetCurrentProcess().Kill();
        }

    }
}
