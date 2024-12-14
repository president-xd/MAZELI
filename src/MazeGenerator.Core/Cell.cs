using System.Drawing;

namespace MazeGenerator.Core

{
    public class Cell
    {
        public enum Paths
        {
            Up,
            Down,
            Right,
            Left,
            None
        }

        /*
         * this array defines cell walls 
         * true= Wall exist, false= Wall dosen't exist.
         * Sequence of these is Left, Top, Right, Bottom
         */

        public Paths Path;

        public Cell(Point location, Point position)
        {
            Position = position;
            Location = location; // Don't mind location, it's for the UI
            IsVisited = false;
            PreviousCell = null;
            Path = Paths.None;
        }

        public bool[] CellWalls { get; set; } = {true, true, true, true};

        /*
         * you may use Point datatype instead of int[,] array if you like to draw proper UI using Pen
         * but if you want to create UI like displayed in problem document 
         * then int[,] array will helpful.
         */
        public Point Location { get; set; }

        /*
         * you may use Point datatype instead of int[,] array if you like to draw proper UI using Pen
         * but if you want to create UI like displayed in problem document 
         * then int[,] array will helpful.
         */
        public Point Position { get; set; }
        public bool IsVisited { get; set; }
        public Cell PreviousCell { get; set; }

        public void Draw(Graphics g, Pen pen, Size size)
        {
            // Draws every wall, if it is intact
            if (CellWalls[0])
            {
                g.DrawLine(pen, Location, new Point(Location.X, Location.Y + size.Height));
            }

            if (CellWalls[2])
            {
                g.DrawLine(pen, new Point(Location.X + size.Width, Location.Y),
                    new Point(Location.X + size.Width, Location.Y + size.Height));
            }

            if (CellWalls[1])
            {
                g.DrawLine(pen, Location, new Point(Location.X + size.Width, Location.Y));
            }

            if (CellWalls[3])
            {
                g.DrawLine(pen, new Point(Location.X, Location.Y + size.Height),
                    new Point(Location.X + size.Width, Location.Y + size.Height));
            }
        }
    }
}