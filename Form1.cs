﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TubesGraph
{
    public partial class Form1 : Form
    {
        public int totalEdge;
        public string fileContent;
        public string[] fileLines;
        public string[] nodeIn;
        public string[] nodeOut;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Open file
            openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            textBox1.Text = fileName;

            this.fileContent="";
            this.fileLines = File.ReadAllLines(fileName);
            this.totalEdge = int.Parse(this.fileLines[0]);

            //Read file per line
            for (int i = 0; i <= this.totalEdge; i++)
            {
                if (i != 0)
                {
                    this.fileContent += this.fileLines[i] + "\n";
                }
            }

            //Read all nodes
            this.nodeOut = new string[this.totalEdge];
            this.nodeIn = new string[this.totalEdge];
            for (int i = 0; i <= this.totalEdge; i++)
            {
                if (i > 0)
                {
                    this.nodeOut[i-1] += this.fileLines[i][0];
                    this.nodeIn[i-1] += this.fileLines[i][2];
                }
            }

            richTextBox1.Text = this.fileContent;


            //Create graph object
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            for (int i = 0; i < this.totalEdge; i++)
            {
                graph.AddEdge(this.nodeOut[i], this.nodeIn[i]).Attr.Color = Microsoft.Msagl.Drawing.Color.MediumSpringGreen;

                graph.FindNode(this.nodeOut[i]).Attr.FillColor = Microsoft.Msagl.Drawing.Color.SpringGreen;
                graph.FindNode(this.nodeOut[i]).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;

                graph.FindNode(this.nodeIn[i]).Attr.FillColor = Microsoft.Msagl.Drawing.Color.SpringGreen;
                graph.FindNode(this.nodeIn[i]).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
            }

            //Deploy graph
            gViewer1.Graph = graph;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void gViewer1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}