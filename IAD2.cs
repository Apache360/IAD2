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

namespace IAD2
{

    public partial class IAD2 : Form
    {
        FileStream fileStreamInput = null;
        string inputFileName = null;
        OpenFileDialog ofd = null;
        DataManager dataManager = new DataManager();

        public IAD2()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void IAD2Form_Load(object sender, EventArgs e)
        {
        }

        private void openFile()
        {
            using (ofd = new OpenFileDialog() { Filter = "All files|*.*|CSV|*.csv" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inputFileName = ofd.FileName;
                    fileStreamInput = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);

                    string[] safeFileName = ofd.SafeFileName.Split(new char[] { '.' });

                    switch (safeFileName[safeFileName.Length - 1])
                    {
                        case "csv":
                            dataGridView1.DataSource = new List<int>();
                            dataGridView2.DataSource = new List<int>(); 
                            dataManager.setData(fileStreamInput);
                            dataManager.processRawData();
                            showRawData();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void showRawData()
        {
            dataGridView1.DataSource= dataManager.passengerRawList;
            dataGridView1.Update();
        }

        private void buttonProcessRawData_Click(object sender, EventArgs e)
        {
            dataManager.processData();

            dataGridView1.DataSource=new List<int>();
            dataGridView1.DataSource=dataManager.passengerRawList;
            dataGridView1.Update();

            dataGridView2.DataSource = new List<int>();
            dataGridView2.DataSource = dataManager.passengerList;
            dataGridView2.Update();
        }

        private void buttonRemoveA_Click(object sender, EventArgs e)
        {
            dataManager.removeAnomalies();

            dataGridView2.DataSource = new List<int>();
            dataGridView2.DataSource = dataManager.passengerList;
            dataGridView2.Update();

            dataGridView3.DataSource = new List<int>();
            dataGridView3.DataSource = dataManager.passengerTemp;
            dataGridView3.Update();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource= new List<int>();
            dataGridView3.Update();
        }
    }
}

