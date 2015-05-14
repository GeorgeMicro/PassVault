using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassVault
{
    public partial class Save : Form
    {
        public Save()
        {
            InitializeComponent();
        }

        void addnew()
        {
            string newContent = textBox1.Text + ";" + textBox2.Text + ";" + textBox3.Text + ";" + textBox4.Text + ";";
            File.AppendAllText(Variables.filepath, newContent);
            MessageBox.Show("New Password Stored");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = ""; 
       }

        private void button1_Click(object sender, EventArgs e)
        {
            addnew();
        }
    }
}
