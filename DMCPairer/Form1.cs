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

namespace DMCPairer
{
    public partial class Form1 : Form
    {
        string PlateDMC = "";
        string VehicleDMC = "";
        string temp = "";
        int int_UnitScanned = 1;
        Boolean IsPlateDMCNext = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = "";
            var str_XMLfilecontent = File.ReadLines(richTextBox4.Text);
            foreach (var line_to_be_processed in str_XMLfilecontent)
            {
                if (line_to_be_processed == "</Serials>")
                {

                }
                else temp += line_to_be_processed + Environment.NewLine;

            }
            temp += richTextBox3.Text;
            string[] str_tofile = { " " };
            str_tofile[0] = temp + "</Serials>" ;
            File.WriteAllLines(richTextBox4.Text, str_tofile);
            int_UnitScanned--;
            MessageBox.Show("XML file was updated with " +int_UnitScanned.ToString()+ " entries successfully. " + System.Environment.NewLine + "You may exit the application. ");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Welcome! Scan the plate DMC for unit 1";
            richTextBox2.Select();
            richTextBox4.Text = "C:\\02 ProjectServer\\DQ400_CFD_ASB\\04 Configuration Files\\Serials_DQ400.xml";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)


        {
            if (e.KeyCode == Keys.Enter)

            {
                if (IsPlateDMCNext)
                {
                    richTextBox1.Text = "Scan VehicleDMC for unit " + int_UnitScanned.ToString() + " !";
                    temp = richTextBox2.Text.Replace("\n", "").Replace("\r", "");
                    richTextBox3.Text += " <TCU MetalPlateID=\"" + temp;
                    richTextBox3.Text += "\" VehicleConnectorID=\"";
                    richTextBox2.Text = "";
                    IsPlateDMCNext = false;
                    int_UnitScanned++;
                }
                else
                {
                    richTextBox1.Text = "Scan PlateDMC for unit " + int_UnitScanned.ToString() + " !";
                    temp = richTextBox2.Text.Replace("\n", "").Replace("\r", "");
                    richTextBox3.Text += temp;
                    
                    richTextBox3.Text += "\"/>" + Environment.NewLine;
                    richTextBox2.Text = "";
                    IsPlateDMCNext = true;
                    
                }
                    
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
