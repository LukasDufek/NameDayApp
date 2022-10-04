using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace svatek
{
    
    public partial class Form1 : Form
    {
        public static List<string> jmena;  

        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime ted = DateTime.Now;
            int mesic = ted.Month;
            int den = ted.Day;

            numericUpDownMonth.Value = mesic;
            numericUpDownDay.Value = den;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int hledany_den = Decimal.ToInt32(numericUpDownDay.Value);
            int hledany_mesic = Decimal.ToInt32(numericUpDownMonth.Value);

           textBox1.Text= "Dnes má svátek: " + najdiPodleDatumu(hledany_den, hledany_mesic);
        }


        public static String najdiPodleDatumu(int hledany_den, int hledany_mesic)
        {

            jmena = new List<string>();
            using (StreamReader sr = new StreamReader(@"jmena.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    jmena.Add(s);
                }
            }

            String jmeno = "";
            int den = 0;
            int mesic = 1;


            for (int i = 0; i < jmena.Count; i++)
            {
                den++;
                if ((hledany_den == den) && (hledany_mesic == mesic))
                {
                    jmeno = jmena[i];
                }
                else if (String.IsNullOrEmpty(jmena[i]))
                {
                    den = 0;
                    mesic++;
                }
            }



            return jmeno;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /*
        public void pridejJmena()
        {
            jmena = new List<string>();
            using (StreamReader sr = new StreamReader(@"jmena.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    jmena.Add(s);
                }
            }
            
        }
        */

    }
}
