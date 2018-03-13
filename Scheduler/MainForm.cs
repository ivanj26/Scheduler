using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickGraph;

namespace Scheduler
{
    public partial class MainForm : Form
    {
        // Create new graph
        
        AdjacencyGraph<string, Edge<string>> graph = new AdjacencyGraph<string, Edge<string>>(
            true // directed graph
            );
        TextBox isiFileTextBox = new TextBox();
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void cariFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Text File | *txt";
            openFileDialog.Title = "Cari text file kuliah";

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.OpenFile() != null) {
                try
                {
                    this.namaFileTextBox.Text = openFileDialog.FileName;
                    Label isiFileLabel = new Label();

                    isiFileLabel.AutoSize = true;
                    isiFileLabel.Text = "Isi file dari " + openFileDialog.FileName.ToString() + " = ";
                    isiFileLabel.Font = (Font)pilihFileLabel.Font.Clone();
                    isiFileLabel.Margin = (Padding)pilihFileLabel.Margin;

                    isiFileTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                    isiFileTextBox.Multiline = true;
                    isiFileTextBox.ScrollBars = ScrollBars.Vertical;
                    isiFileTextBox.ReadOnly = true;
                    isiFileTextBox.Height = 150;
                    isiFileTextBox.Margin = (Padding)pilihFileLabel.Margin;
                    isiFileTextBox.Width = (pilihFileLabel.Width + 16 + cariFile.Width + namaFileTextBox.Width) - pilihFileLabel.Location.X;


                    if (flowLayoutPanel.Controls.Count != 3) { 
                        flowLayoutPanel.Controls.RemoveAt(flowLayoutPanel.Controls.Count - 1);
                        flowLayoutPanel.Controls.RemoveAt(flowLayoutPanel.Controls.Count - 1);
                    }
                    flowLayoutPanel.Controls.Add(isiFileLabel);
                    flowLayoutPanel.Controls.Add(isiFileTextBox);
                    this.MaximumSize = new Size(610, 170 + isiFileLabel.Height + isiFileTextBox.Height);
                    this.MinimumSize = new Size(610, 170 + isiFileLabel.Height + isiFileTextBox.Height);
                }
                catch (Exception ex) {
                    MessageBox.Show("Terjadi kesalahan!", "Error: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void flowLayoutPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel.Controls.Count > 3)
            {
                tampilkanGraph.Enabled = true;
            }
        }

        private void tampilkanGraph_Click(object sender, EventArgs e)
        {
            graph.Clear();
            Console.Clear();
            HashSet<string> hashSetMatKul = parseStringToSetOfIVertex(isiFileTextBox.Text.ToString());

            //create vertex (matkul)
            foreach (string matkul in hashSetMatKul) {
                graph.AddVertex(matkul);
            }

            //tampilin vertex di graph
            foreach (string v in graph.Vertices)
            {
                Console.WriteLine(v);
            }
        }

        private HashSet<string> parseStringToSetOfIVertex(string text) {
            //Baca string di textbox
            char[] delimit = {
                ' ',
                '.',
                ',',
                '\n',
                '\0'
            };

            string[] arrayMatKul = text.Split(delimit);
            HashSet<string> hashSetMatKul = new HashSet<string>();
            foreach (string matkul in arrayMatKul) {
                if (!String.IsNullOrEmpty(matkul) && !String.IsNullOrWhiteSpace(matkul)) {
                    hashSetMatKul.Add(matkul);
                }
            }
            return hashSetMatKul;
        }
    }
}
