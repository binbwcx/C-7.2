using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文档(*.txt)|*.txt|RichText文档(*.rtf)|" +
                "*.rtf|所有文件(*.*)|*.*";
            openFileDialog1.FileName = "???";
            openFileDialog1.Title = "打开文件";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.richTextBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {
                StreamReader sr = new StreamReader(textBox1.Text, Encoding.Default);
                string line = "";
                while ((line=sr.ReadLine())!=null)
                {
                    richTextBox1.Text += line + Environment.NewLine;

                }
                sr.Close();

            }
            else
            {
                MessageBox.Show("文件不存在");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter= "文本文档(*.txt)|*.txt|RichText文档(*.rtf)|" +
                "*.rtf|所有文件(*.*)|*.*";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Title = "保存文件";
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox2.Text = saveFileDialog1.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox2.Text))
            {
                File.Copy(textBox1.Text, textBox2.Text);
                MessageBox.Show("文件复制成功");
            }
            else
            {
                MessageBox.Show("文件不存在");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {
                File.Move(textBox1.Text, textBox2.Text);
                MessageBox.Show("移动成功");

            }
            else
            {
                MessageBox.Show("移动失败");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {
                File.Delete(textBox1.Text);
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            FileStream filestream = new FileStream(path, FileMode.Open);
            byte[] bt = new byte[filestream.Length];
            filestream.Read(bt, 0, bt.Length);
            string base64Str = Convert.ToBase64String(bt);

            filestream.Close();
            string FileName = textBox2.Text;
            using (FileStream fileStream = File.Create(FileName))
            {
                byte[] bytes = new UTF8Encoding(true).GetBytes(richTextBox1.Text);
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Close();
            }

        }
    }
}
