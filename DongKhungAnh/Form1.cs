using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongKhungAnh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;

                fileName = dlg.FileName;
                textBox1.Text = fileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;

                fileName = dlg.FileName;
                textBox2.Text = fileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Helper helper = new Helper();
            if (!File.Exists(textBox1.Text) || !File.Exists(textBox2.Text))
            {
                MessageBox.Show("Bạn cần chọn khung và ảnh");
            } else
            {
                string result = Helper.AddFrameToImage(textBox1.Text, textBox2.Text);
                textBox3.Text = result;
                textBox3.Enabled = true;
                button5.Enabled = true;
                button4.Enabled = true;
                button3.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\frame.png";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start(textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/open, "+ Path.GetDirectoryName(textBox3.Text));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
            textBox3.Text = "";
            textBox3.Enabled = false;
            button5.Enabled = false;
            button4.Enabled = false;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/hoanggiang.tran.963434/");
        }
    }
}
