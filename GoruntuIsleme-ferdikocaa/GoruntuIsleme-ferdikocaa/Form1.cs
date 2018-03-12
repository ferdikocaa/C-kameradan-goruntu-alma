using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace GoruntuIsleme_ferdikocaa
{
    public partial class Form1 : Form
    {
         public Form1()
        {
            InitializeComponent();
        }
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        private void button1_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();//picture box'a resmi atıyoruz.
            pictureBox1.Image = bmp;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning)
            {
                cam.Stop(); 
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in webcam)
            {
                comboBox1.Items.Add(item.Name);
            }
            comboBox1.SelectedIndex = 0;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog swf = new SaveFileDialog();
            swf.Filter = "(*.jpg)|*.jpg|Bitma*p(*.bmp)|*.bmp";
            DialogResult dialog = swf.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                pictureBox1.Image.Save(swf.FileName);
            }
        }
    }
}
