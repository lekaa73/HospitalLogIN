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
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace HospitalLogIN
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox7.Focus();
            }
        }

        FileStream fs;
        StreamReader sr;
        StreamWriter sw;
        string fileName = "C:\\Users\\c.city\\OneDrive\\Desktop\\Hospital.txt";

        private void button1_Click(object sender, EventArgs e) //Open
        {
            OpenFileDialog fd = new OpenFileDialog();
            DialogResult res = fd.ShowDialog();
            if (res == DialogResult.Cancel)
                return;
            fileName = fd.FileName;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);
            sr = new StreamReader(fs);
            MessageBox.Show("File is opened");
            button2.Enabled = true;
            button3.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button11.Enabled = true;

        }
        private void button2_Click(object sender, EventArgs e) //insert
        {
            fs.Seek(0, SeekOrigin.End);
            string record = textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text+ "," + textBox5.Text + "," +
            textBox6.Text + "," + textBox7.Text;

            sw.WriteLine(record);
            sw.Flush();
            MessageBox.Show("Record saved");
        }

        private void button3_Click(object sender, EventArgs e)  //Read
        {
            string record = sr.ReadLine();
            string[] field;
            if (record != null)
            {
                field = record.Split(',');
                textBox1.Text = field[0];
                textBox2.Text = field[1];
                textBox3.Text = field[2];
                textBox4.Text = field[3];
                textBox5.Text = field[4];
                textBox6.Text = field[5];
                textBox7.Text = field[6];

            }
            else
            {
                MessageBox.Show("No more record");
                button7_Click(sender, e);
            }
        }

        private void button7_Click(object sender, EventArgs e) //Clear
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = null;
        }

        private void button8_Click(object sender, EventArgs e) //StartOfFile
        {
            fs.Seek(0, SeekOrigin.Begin);
            MessageBox.Show("Begin of the file");
        }

        private void button9_Click(object sender, EventArgs e) //EndOfFile
        {
            fs.Seek(0, SeekOrigin.End);
            MessageBox.Show("Enf of the file");
        }

        private void button10_Click(object sender, EventArgs e) //Close
        {
            sw.Close();
            sr.Close();
            fs.Close();
            MessageBox.Show("File Closed");
            button2.Enabled = false;
            button3.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button11.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e) //Exit
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e) //Search
        {
            int Idnum = int.Parse(textBox1.Text);
            string line;
            string[] field;
            while ((line = sr.ReadLine()) != null)
            {
                field = line.Split(',');
                if (int.Parse(field[0]) == Idnum)
                {
                    textBox2.Text = field[1];
                    textBox3.Text = field[2];
                    textBox4.Text = field[3];
                    textBox5.Text = field[4];
                    textBox6.Text = field[5];
                    textBox7.Text = field[6];
                    MessageBox.Show("Found");
                    return;
                }
            }
            MessageBox.Show("Not found");
        }

        private void button5_Click(object sender, EventArgs e) //Delete
        {
            fs.Seek(0, SeekOrigin.Begin);
            fs.Flush();
            sw.Flush();
            string line;
            string[] field;
            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                field = line.Split(',');
                if (field[0] == textBox1.Text)
                {
                    fs.Seek(count, SeekOrigin.Begin);

                    sw.Write("*");
                    sw.Flush();

                }
                count += line.Length + 2;
            }
        }

        private void button6_Click(object sender, EventArgs e) //Squeeze
        {
            string line;
            fs.Seek(0, SeekOrigin.Begin);
            FileStream SQfile = new
            FileStream("Squeeze.txt", FileMode.Create, FileAccess.Write);
            StreamWriter SQwriter = new StreamWriter(SQfile);
            while ((line = sr.ReadLine()) != null)
            {
                if (line[0] != '*')
                {
                    SQwriter.WriteLine(line);
                    SQwriter.Flush();

                }
            }
            SQwriter.Close();
            SQfile.Close();
        }
    }
}
