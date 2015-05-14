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

namespace PassVault
{
    public partial class Check : Form
    {
        Dictionary<string, string[]> passdict = new Dictionary<string, string[]>();
        public Check()
        {
            InitializeComponent();
            try
            {
                fill_listbox(); //fill the listbox with the content in a text file.
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void fill_listbox()
        {
            string line;
            StreamReader file = new StreamReader(Variables.filepath);

            while ((line = file.ReadLine()) != null)
            {
                //line = file.ReadLine();
                string[] info = line.Split(';').ToArray();
                string site = info[0];
                RemoveAt<string>(info, 0);  //change to array
                passdict.Add(site, info);
                listBox1.Items.Add(site);
            }
            file.Close();
        }

        void writeback() //write back the list to the password file
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Variables.filepath))
            {
                foreach (KeyValuePair<string, string[]> i in passdict)
                {
                    file.WriteLine(i.Key + ";" + i.Value[0] + ";" + i.Value[1] + ";" + i.Value[2] + ";");
                }
            }
        }
        private void Form2_FormClosing(object sender, EventArgs e)
        {
            writeback(); //before the form to be closed writeback all data
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] temp;
            passdict.TryGetValue(listBox1.SelectedItem.ToString(), out temp);
            string[] str = temp.ToArray();
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //edit button
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] temp = new string[3];
            temp[0] = textBox1.Text;
            temp[1] = textBox2.Text;
            temp[2] = textBox3.Text;
            passdict[listBox1.SelectedItem.ToString()] = temp;
            MessageBox.Show("Your change is saved!");
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            //textBox1.Text;
        }

        public static void RemoveAt<T>(T[] arr, int index)
        {
            for (int a = index; a < arr.Length - 1; a++)
            {
                // moving elements downwards, to fill the gap at [index]
                arr[a] = arr[a + 1];
            }
            // finally, let's decrement Array's size by one
            Array.Resize(ref arr, arr.Length - 1);
        }

    }
}
