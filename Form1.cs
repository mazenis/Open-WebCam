using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
namespace Webcam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private FilterInfoCollection WEBCAM;
        private VideoCaptureDevice CAM1;

        private void button1_Click(object sender, EventArgs e)
        {
            CAM1 = new VideoCaptureDevice(WEBCAM[comboBox1.SelectedIndex].MonikerString);
            CAM1.NewFrame += new NewFrameEventHandler(CAM1_NewFrame);

            CAM1.Start();
        }

        private void CAM1_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WEBCAM = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in WEBCAM)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CAM1.Stop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CAM1.IsRunning==true)
            {
                CAM1.Stop();
            }
        }
    }
}
