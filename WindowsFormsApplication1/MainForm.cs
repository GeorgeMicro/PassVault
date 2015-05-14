using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Check checkform = new Check();
            checkform.ShowDialog(); //ShowDialog also locks the previous form!
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save saveform = new Save();
            saveform.ShowDialog();
        }
    }
}
