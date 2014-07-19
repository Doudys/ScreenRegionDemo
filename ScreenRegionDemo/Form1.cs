using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;



namespace ScreenRegionDemo
{
    public partial class Form1 : Form
    {
        int xheight, xwidth;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, System.EventArgs e)
        {
            xheight = (int)numericUpDownHeight.Value;
            xwidth = (int)numericUpDownWidth.Value;
            CaptureMyScreen(xheight, xwidth);
        }

        private void CaptureMyScreen(int xheight, int xwidth)
        {
            try
            {
                //Create a bitmap object
                Bitmap captureBitmap = new Bitmap(xheight, xwidth, PixelFormat.Format32bppArgb);

                // Create a Rectangle objecct which will capture the Current screen
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

                //Create a New grahic object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                //copy the image from the screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                //save image to hard drive
                captureBitmap.Save(@"C:\Users\GladysVM\Documents\Visual Studio 2010\Projects\ScreenRegionDemo\Capture.jpg", ImageFormat.Jpeg);
                MessageBox.Show("Screen Captured");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.HelpLink);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
