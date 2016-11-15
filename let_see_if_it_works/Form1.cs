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

namespace let_see_if_it_works
{
    public partial class Form1 : Form
    {
        string inpath;
        string outpath;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
                inpath = this.textBox1.Text.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            combine(inpath, outpath);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public static void combine(string inputdirectory, string outputdirectory)
        {
            string[] inputFilePaths = System.IO.Directory.GetFiles(inputdirectory);
            Console.WriteLine("Number of files: {0}", inputFilePaths.Length);
            using (var outputStream = System.IO.File.Create(outputdirectory))
            {
                foreach (var inputFilePath in inputFilePaths)
                {
                    using (var inputStream = System.IO.File.OpenRead(inputFilePath))
                    {
                        inputStream.CopyTo(outputStream);
                    }
                    Console.WriteLine("The file {0} has been processed.", inputFilePath);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            countthenumbers(outpath);
        }
        public static void countthenumbers(string outputpath)
        {
            int count = 0;
            int comcount = 0;
            var linescount = System.IO.File.ReadLines(outputpath);
            foreach (var item in linescount)
            {

                if (item.StartsWith("\\"))
                {
                    continue;
                }
                else if (!(item.StartsWith("/*") || item.StartsWith("\\") || item.StartsWith("*/")) && comcount == 0)
                {
                    //Console.WriteLine(item);
                    //Console.WriteLine("real Count----->" + count);
                    count++;
                }
                else if (item.EndsWith("*/") && comcount == 1)
                {
                    //Console.WriteLine("IN ENDS WITH");
                    //Console.WriteLine("end with Count----->" + count);
                    comcount = 0;
                    continue;
                }
                else if (item.StartsWith("/*") && comcount == 0)
                {
                    //Console.WriteLine("IN STARTS WITH");
                    comcount = 1;
                    continue;
                }
            }
            string finalcount = count.ToString();
            MessageBox.Show(finalcount);
            File.Delete(outputpath);
         }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog2_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = folderBrowserDialog2.SelectedPath;
                string final = this.textBox2.Text + "input.txt";
                outpath = final;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
