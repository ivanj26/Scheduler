using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Scheduler

{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //char[] delimiterChars = { ' ', ',', '.', '\n'};

            //string text = "C1, C3.\nC2.\n";
            //System.Console.WriteLine($"Original text: '{text}'");

            //string[] words = text.Split(delimiterChars);
            //System.Console.WriteLine($"{words.Length} words in text:");

            //foreach (var word in words)
            //{
            //    if (word.Length > 0)
            //    {
            //        System.Console.WriteLine($"<{word}>");
            //    }
            //}

            //AdjacencyGraph g = new AdjacencyGraph(
            //new VertexAndEdgeProvider(), // vertex and edge provider 
            //true // directed graph
            //);

            //// adding vertices u,v
            //IVertex u = g.AddVertex();    // IVertexMutableGraph
            //IVertex v = g.AddVertex();

            //VertexStringDictionary names = new VertexStringDictionary();
            //names[u] = "u";
            //names[v] = "v";
            //// adding the edge (u,v)
            //IEdge e = g.AddEdge(u, v);     // IEdgeMutableGraph

            //foreach (IVertex x in g.Vertices) // IVertexListGraph
            //{
            //    Console.WriteLine(x);
            //    Console.WriteLine(names[x]);
            //}
            //// iterating edges
            //foreach (IEdge t in g.Edges)       // IEdgeListGraph
            //{
            //    Console.WriteLine(t);
            //}
            //Console.Read();
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
