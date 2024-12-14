namespace MazeGenerator.Core
{
    // this class will be used to solve Maze 
    public class MazeSolver
    {
        private readonly Maze _maze;

        public MazeSolver(Maze maze)
        {
            _maze = maze;
        }

        public void Solve()
        {
            _maze.Solving = true;
            // use this method to solve Maze
            _maze.FoundPath.Clear();
            UnVisitAll();
            var algo = new SearchAlgorithm(_maze);
            algo.BreathFirstSearch();
            _maze.Solving = false;
        }

        private void UnVisitAll()
        {
            for (var i = 0; i < _maze.MazeArray.GetLength(0); i++)
            for (var j = 0; j < _maze.MazeArray.GetLength(1); j++)
            {
                _maze.MazeArray[i, j].IsVisited = false;
                _maze.MazeArray[i, j].Path = Cell.Paths.None;
            }
        }
    }
}