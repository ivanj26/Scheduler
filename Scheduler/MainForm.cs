using System;
using System.Collections;
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
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;

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
            if (Application.OpenForms.Count == 2)
            {
                Application.OpenForms[1].Dispose();
            }
            HashSet<string> hashSetMatKul = parseStringToSetOfIVertex(isiFileTextBox.Text.ToString());

            //create vertex (matkul)
            foreach (string matkul in hashSetMatKul) {
                graph.AddVertex(matkul);
            }

            addEdges();
            foreach (string w in graph.Vertices)
            {
                Console.WriteLine(w);
            }

            GraphvizAlgorithm<string, Edge<string>> graphvizAlgorithm = new GraphvizAlgorithm<string, Edge<string>>(graph);
            graphvizAlgorithm.ImageType = GraphvizImageType.Png;
            graphvizAlgorithm.FormatVertex += GraphvizAlgorithm_FormatVertex;
            graphvizAlgorithm.FormatEdge += GraphvizAlgorithm_FormatEdge;
            graphvizAlgorithm.Generate(new FileDotEngine(), Application.StartupPath + "\\image\\image.png");

            //show Graph!
            Form pictureForm = new Form();
            PictureBox pictureBox = new PictureBox();

            pictureBox.Image = Image.FromFile(Application.StartupPath + "\\image\\image.png");
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            pictureForm.Size = new Size(pictureBox.Width + 15, pictureBox.Height + 50);
            pictureForm.Show();
            pictureForm.MaximizeBox = false;
            pictureForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            pictureForm.ShowIcon = false;
            pictureForm.Text = "Sketch Graph";
            pictureForm.Controls.Add(pictureBox);
        }

        private void GraphvizAlgorithm_FormatEdge(object sender, FormatEdgeEventArgs<string, Edge<string>> e)
        {
        }

        private void GraphvizAlgorithm_FormatVertex(object sender, FormatVertexEventArgs<string> e)
        {
            e.VertexFormatter.Label = e.Vertex;
        }

        private void addEdges()
        {
            char[] delimit1 = { '\n' };
            char[] delimit2 = { ',', ' ', '.' };

            string[] arraySplit1 = isiFileTextBox.Text.ToString().Split(delimit1);
            for (int i = 0; i < arraySplit1.Length; i++)
            {
                string[] arraySplit2 = arraySplit1[i].Split(delimit2);
                for (int j = 1; j < arraySplit2.Length; j++) {
                    if (!String.IsNullOrEmpty(arraySplit2[j]) && !String.IsNullOrWhiteSpace(arraySplit2[j]))
                    {
                        Edge<string> edge = new Edge<string>(arraySplit2[j], arraySplit2[0]);
                        graph.AddEdge(edge);
                    }
                }
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
