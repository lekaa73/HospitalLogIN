using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalLogIN
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        public Form1()
        {
            InitializeComponent();
            Instance = this;
        }

        private void button1_Click(object sender, EventArgs e) //Login
        {
            string name = textBox1.Text;
            string line;
            string[] field;
            while ((line = sr.ReadLine()) != null)
            {
                field = line.Split(',');
                if (field[0] == name)
                {
                    Form2 form = new Form2();    //Open Form2
                    form.Show();                //Open Form2
                    return;  
                }
            }
            MessageBox.Show("Not found");
            button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e) //Exit
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox2.Focus();
            }
        }
        FileStream fs;
        StreamReader sr;
        StreamWriter sw;
        string fileName = "C:\\Users\\c.city\\OneDrive\\Desktop\\Employee.txt";
        private void button3_Click(object sender, EventArgs e) //Open
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
            button1.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e) //Clear
        {
            textBox1.Text = textBox2.Text = null;
        }

    }
}
