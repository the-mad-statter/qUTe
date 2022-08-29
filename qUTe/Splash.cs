using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace qUTe
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            Bitmap b = new Bitmap(this.BackgroundImage);
            b.MakeTransparent(b.GetPixel(1, 1));
            this.BackgroundImage = b;
        }

        private void splash_Load(object sender, EventArgs e)
        {
        }
    }
}