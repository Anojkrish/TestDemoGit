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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DataSet ds = new DataSet("MyDataSet");
            ds.ReadXml(@"C:\Users\Anoj.krishnamoorthy\Documents\Visual Studio 2017\Projects\WindowsFormsApp1\WindowsFormsApp1\Test.xml");

           
                StreamWriter serialWriter;
                serialWriter = new StreamWriter(@"D:\Result.xml");
                XmlSerializer xmlWriter = new XmlSerializer(ds.GetType());
                xmlWriter.Serialize(serialWriter, ds);
                serialWriter.Close();
                ds.Clear();

           
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSet));
                FileStream readStream = new FileStream(@"D:\Result.xml", FileMode.Open);
                ds = (DataSet)xmlSerializer.Deserialize(readStream);
                readStream.Close();
           
            
        }
    }
    }

