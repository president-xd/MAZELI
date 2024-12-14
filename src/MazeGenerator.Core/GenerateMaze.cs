using System.Drawing;

namespace MazeGenerator.Core
{
    // create Maze in this class
    public class GenerateMaze
    {
        private readonly Maze _maze;

        public GenerateMaze(Maze maze)
        {
            _maze = maze;
        }

        public void Generate(int value)
        {
            // create maze in this method using breath first search
            //Init(value);
            _maze.MazePen.Dispose();
            _maze.MazePen = _maze.X < 5 ? new Pen(Brushes.WhiteSmoke, 1) : new Pen(Brushes.WhiteSmoke, 3);
            var algo = new SearchAlgorithm(_maze);
            algo.DepthFirstSearch();
        }
    }
}