using DiscUtils.Iso9660;
using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.IO.Compression;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public string ISOFileName { get; private set; }  // возможно не нужен
        string[] Drives = Environment.GetLogicalDrives();
        public Form1()
        {
            InitializeComponent();


        }

      

     

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceDirName = textBox3.Text;    //что перенести
                string destDirName = textBox4.Text + "/NEW";     //название новой папки


                FileSystem.MoveDirectory(sourceDirName, destDirName);
                MessageBox.Show("Перемещение завершено");
            }
            catch
            {
                MessageBox.Show("ERROR");
            }



        }

     

        private void button5_Click(object sender, EventArgs e) 
        {

        


            CDBuilder builder = new CDBuilder();
            builder.UseJoliet = true;
            builder.VolumeIdentifier = "KYRS";


            string compressedFile = "D:\\" + "/" + "archiv" + "." + "rar";
            ZipFile.CreateFromDirectory(textBox1.Text, compressedFile);



            builder.AddFile("new.zip", @"D:\archiv.rar");

            comboBox1.Items.Add(textBox2.Text);

            int a = comboBox1.SelectedIndex;

            try
            {
                builder.Build($"{Drives[a]}new.iso");
                MessageBox.Show("OK");
            }
            catch
            {
                MessageBox.Show("Загружать на диск С нельзя!");
            }
           

            




            



            if (File.Exists(@"D:\archiv.rar")) // удаление рара который исп
            {
                File.Delete(@"D:\archiv.rar");
            }




            /*string targetFile = "F:\\";
            ZipFile.ExtractToDirectory(compressedFile, targetFile);*/





        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fdb = new FolderBrowserDialog() { Description = "select file" })
            {
                if (fdb.ShowDialog() == DialogResult.OK)

                    textBox1.Text = fdb.SelectedPath;


            }

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for(int i = 0; i < Drives.Length; i++) {
                comboBox1.Items.Add(Drives[i]);
            }
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fdb3 = new FolderBrowserDialog() { Description = "select file" })
            {
                if (fdb3.ShowDialog() == DialogResult.OK)

                    textBox3.Text = fdb3.SelectedPath;


            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fdb4 = new FolderBrowserDialog() { Description = "Куда перенести." })
            {
                if (fdb4.ShowDialog() == DialogResult.OK)

                    textBox4.Text = fdb4.SelectedPath;


            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
} 

