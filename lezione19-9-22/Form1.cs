using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace lezione19_9_22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            letturafile();
        }
        public struct list
        {
            public int col0;
            public string col1;
            public string col2;
            public int col3;
            public double col4;
            public double col5;
            public double col6;
            public string col7;
            public double col8;
        }

        list[] lista = new list[30];
        int conta_record = 0;
        const string filename = @"./dati.csv";
        string line = "";
        int recordLenght = 110;


        const char end_of_line = '#';
        const int end_of_line_position = 109;


        public void letturafile()
        {
            var sr = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            byte[] br = new byte[recordLenght];

            BinaryReader reader = new BinaryReader(sr);

            string[] strsplit = new string[9];

            sr.Seek(0, SeekOrigin.Begin);

            while (sr.Position < sr.Length)
            {
                br = reader.ReadBytes(recordLenght);
                line = Encoding.ASCII.GetString(br, 0, br.Length);

                strsplit = line.Split(',');

                lista[conta_record].col0 = Convert.ToInt32(strsplit[0]);
                MessageBox.Show(lista[conta_record].col0.ToString());

                lista[conta_record].col1 = strsplit[1];
                MessageBox.Show(lista[conta_record].col1);

                lista[conta_record].col2 = strsplit[2];
                MessageBox.Show(lista[conta_record].col2);

                lista[conta_record].col3 = Convert.ToInt32(strsplit[3]);
                MessageBox.Show(lista[conta_record].col3.ToString());

                check_double_dot(ref strsplit[4]);
                lista[conta_record].col4 = Convert.ToDouble(strsplit[4]);
                MessageBox.Show(lista[conta_record].col4.ToString());

                check_double_dot(ref strsplit[5]);
                lista[conta_record].col5 = Convert.ToDouble(strsplit[5]);
                MessageBox.Show(lista[conta_record].col5.ToString());

                check_double_dot(ref strsplit[6]);
                lista[conta_record].col6 = Convert.ToDouble(strsplit[6]);
                MessageBox.Show(lista[conta_record].col6.ToString());

                lista[conta_record].col7 = strsplit[7];
                MessageBox.Show(strsplit[7]);

                int num = strsplit[8].IndexOf(end_of_line);
                MessageBox.Show(num.ToString());
                string ssr = strsplit[8].Substring(num - 1);
                MessageBox.Show(strsplit[8]);
                check_double_dot(ref strsplit[8]);
                lista[conta_record].col8 = Convert.ToDouble(strsplit[8]);

                sr.Seek(recordLenght, SeekOrigin.Current);
                conta_record++;
            }
        }
        public void check_double_dot(ref string str)    //lettura del file
        {
            char[] cr = str.ToCharArray();
            for (int a = 0; a < str.Length; a++)
            {
                if (cr[a] == '.')
                {
                    cr[a] = ',';
                }
            }
            str = new string(cr);
        }
        public void check_double_comma(ref string str)      //scrittura sul file
        {
            char[] cr = str.ToCharArray();
            for (int a = 0; a < str.Length; a++)
            {
                if (cr[a] == ',')
                {
                    cr[a] = '.';
                }
            }
            str = new string(cr);
        }

    
    }
}
