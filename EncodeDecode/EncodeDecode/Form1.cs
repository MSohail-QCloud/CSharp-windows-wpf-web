using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncodeDecode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //encode
        private void button1_Click(object sender, EventArgs e)
        {
            string EnText = txtEnName.Text+','+ txtEnClicks.Text+',' + txtEnLastDate.Text;
            var plainTextBytes = Encoding.UTF8.GetBytes(EnText);
            string encodedText = Convert.ToBase64String(plainTextBytes);
            txtEncodedtxt.Text = encodedText;
           
        }
        //decode
        private void button2_Click(object sender, EventArgs e)
        {
            var encodedTextBytes = Convert.FromBase64String(txtDecodedtxt.Text);
            string plainText = Encoding.UTF8.GetString(encodedTextBytes);
            //txtDeName.Text = plainText;

            string[] result;
            //string charCommaString = "a, e, i, o, u";
            char[] commaSeparator = new char[] { ',' };
            result = plainText.Split(commaSeparator, StringSplitOptions.None);
            //for (int i = 0; i < 3;i++ )
            //{
            //   result=commaSeparator[i];
            //}
            txtDeName.Text = result[0].ToString();
            txtDeClicks.Text = result[1].ToString();
            txtDeLastDate.Text = result[2].ToString();
        }
    }
}
