using System;
using System.ComponentModel;
using System.Windows.Forms;
using MazeGenerator.Core;

namespace MazeGenerator.Forms
{
    public partial class Form1 : Form
    {
        private readonly BackgroundWorker _backGroundWorker;
        private Maze _maze;
        private GenerateMaze _mazeGenerator;
        private bool hasSolution;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;

            _backGroundWorker = new BackgroundWorker();
            _backGroundWorker.DoWork += _backGroundWorker_DoWork;
            _backGroundWorker.RunWorkerCompleted += _backGroundWorker_RunWorkerCompleted;
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            // generate Maze here using GenerateMaze class
            GenerateBtn.Enabled = false;
            SolveBtn.Enabled = false;
            timer1.Enabled = true;
            hasSolution = false;
            _backGroundWorker.RunWorkerAsync(new object[] {30, false});
        }

        private void SolveBtn_Click(object sender, EventArgs e)
        {
            // solve maze here using MazeSolver class
            GenerateBtn.Enabled = false;
            SolveBtn.Enabled = false;
            timer1.Enabled = true;
            if (_maze != null)
            {
                _maze.Solving = true;
                hasSolution = true;
                _backGroundWorker.RunWorkerAsync(new object[] {30, true});
            }
        }

        private void mazePicBox_Paint(object sender, PaintEventArgs e)
        {
            if (_maze != null)
            {
                _maze.Draw(e.Graphics);
                if (hasSolution)
                {
                    _maze.DrawPath(e.Graphics);
                }
            }
        }

        private void _backGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = e.Argument as object[];

            var value = 25; // Cell size
            var solving = (bool) args[1];
            if (!solving)
            {
                //this._maze.Generate(this.pictureBoxDraw.Width / value,
                //    (this.pictureBoxDraw.Height - value) / value,
                //    (int)args[2]);
                _maze = new Maze(mazePicBox.Width, mazePicBox.Height, 25);
                _mazeGenerator = new GenerateMaze(_maze);
                _mazeGenerator.Generate(value);
            }
            else
            {
                var solver = new MazeSolver(_maze);
                solver.Solve();
                hasSolution = true;
            }

            mazePicBox.Invalidate();
        }

        private void _backGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GenerateBtn.Enabled = true;
            SolveBtn.Enabled = true;
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mazePicBox.Invalidate();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            _maze = new Maze(mazePicBox.Width, mazePicBox.Height, 25);


            // re-draw the picture
            //this.mazePicBox.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}