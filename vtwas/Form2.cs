using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace vtwas
{
    public partial class Form2 : Form
    {

        Regex regex = new Regex("");

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                regex = new Regex(textBox1.Text);
                textBox4.Text = regex.Replace(textBox2.Text, textBox3.Text);
                //var m = regex.Match(textBox3.Text);
                //if (m.Success) textBox4.Text = regex.Replace(textBox2.Text, textBox3.Text);
                //else textBox4.Text = "false";
            }
            catch(ArgumentException ex)
            {
                textBox4.Text = "error:" + ex.Message;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = regex.Replace(textBox2.Text, textBox3.Text);
            //var m = regex.Match(textBox3.Text);
            //if (m.Success) textBox4.Text = regex.Replace(textBox2.Text, textBox3.Text);
            //else textBox4.Text = "false";

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = regex.Replace(textBox2.Text, textBox3.Text);
            //var m = regex.Match(textBox3.Text);
            //if (m.Success) textBox4.Text = regex.Replace(textBox2.Text, textBox3.Text);
            //else textBox4.Text = "false";

        }
    }
}
