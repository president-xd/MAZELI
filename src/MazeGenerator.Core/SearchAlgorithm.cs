using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace MazeGenerator.Core
{
    public class SearchAlgorithm
    {
        private readonly Maze _maze;

        public SearchAlgorithm(Maze maze)
        {
            _maze = maze;
        }

        //Find Maze exit

        #region Breadth-First Search

        public bool BreathFirstSearch()
        {
            var que = new Queue<Cell>();
            que.Enqueue(_maze.Begin);
            _maze.Begin.IsVisited = true;
            var path = new List<Cell>();
            while (que.Count > 0)
            {
                var currentCell = que.Dequeue();
                if (currentCell.Position == _maze.End.Position)
                {
                    while (currentCell.Position != _maze.Begin.Position)
                    {
                        path.Add(currentCell);
                        currentCell = currentCell.PreviousCell;
                    }

                    path.Reverse();
                    foreach (var cell in path)
                    {
                        _maze.FoundPath.Add(cell);
                        Thread.Sleep(20);
                    }

                    break;
                }

                Thread.Sleep(2);
                var cellNeighbours = GetCurrentCanVisitCellNeighbours(currentCell);

                foreach (var cellNeighbour in cellNeighbours)
                {
                    if (!cellNeighbour.IsVisited)
                    {
                        cellNeighbour.PreviousCell = currentCell;

                        que.Enqueue(cellNeighbour);
                        cellNeighbour.IsVisited = true;
                    }
                }
            }
            // implement Breadth-First search here

            return false;
        }

        #endregion Breadth-First Search

        //Create Maze

        #region Depth-First Search

        public void DepthFirstSearch()
        {
            var cellStack = new Stack<Cell>();
            var currentCell = _maze.Begin;
            Cell neighbourCell = null;
            cellStack.Push(currentCell);
            while (cellStack.Count > 0)
            {
                _maze.CurrentGenerateCell = currentCell.Position;
                Thread.Sleep(3);
                currentCell.IsVisited = true;
                var currentCellPointNeighbours = GetCurrentCellNeighbours(currentCell);
                var currentCellNeighbours = new List<Cell>();
                foreach (var currentCellPointNeighbour in currentCellPointNeighbours)
                {
                    currentCellNeighbours.Add(new Cell(new Point(currentCellPointNeighbour.X, currentCellPointNeighbour.Y), new Point(currentCellPointNeighbour.X, currentCellPointNeighbour.Y)));
                }

                var currentUnvisitedCellNeighbours = currentCellNeighbours.Where(n => n.IsVisited == false).ToList();
                if (currentUnvisitedCellNeighbours.Count <= 0)
                {
                    var previousCell = currentCell;
                    currentCell = cellStack.Pop();
                    continue;
                }

                if (currentCell.Position == _maze.End.Position)
                {
                    var currCell = currentCell;
                    while (currCell.Position != _maze.Begin.Position)
                    {
                        RemoveWall(currCell, currCell.PreviousCell);
                        currCell = currCell.PreviousCell;
                    }
                }

                var random = new Random();
                var randomNumber = random.Next(0, currentUnvisitedCellNeighbours.Count);
                neighbourCell = currentUnvisitedCellNeighbours[randomNumber];
                RemoveWall(currentCell, neighbourCell);
                neighbourCell.PreviousCell = currentCell;
                currentUnvisitedCellNeighbours.RemoveAt(randomNumber);
                foreach (var unvisited in currentUnvisitedCellNeighbours)
                {
                    cellStack.Push(unvisited);
                }

                cellStack.Push(neighbourCell);
            }

            CreateEndOfMaze();
        }


        private void CreateEndOfMaze()
        {
            var temp = new Point();
            var random = new Random();
            temp.Y = 0;
            temp.X = 0;

            temp.Y = random.Next(_maze.Height);
            temp.X = _maze.Width - 1;
            _maze.MazeArray[temp.X, temp.Y].CellWalls[2] = false;
            _maze.End = _maze.MazeArray[temp.X, temp.Y];
        }


        private void RemoveWall(Cell current, Cell next)
        {
            // Next is up 
            if (current.Position.X == next.Position.X && current.Position.Y > next.Position.Y)
            {
                _maze.MazeArray[current.Position.X, current.Position.Y].CellWalls[1] = false;
                _maze.MazeArray[next.Position.X, next.Position.Y].CellWalls[3] = false;
            }
            // the next is down
            else if (current.Position.X == next.Position.X)
            {
                _maze.MazeArray[current.Position.X, current.Position.Y].CellWalls[3] = false;
                _maze.MazeArray[next.Position.X, next.Position.Y].CellWalls[1] = false;
            }
            // the next is left
            else if (current.Position.X > next.Position.X)
            {
                _maze.MazeArray[current.Position.X, current.Position.Y].CellWalls[0] = false;
                _maze.MazeArray[next.Position.X, next.Position.Y].CellWalls[2] = false;
            }
            // the next is right
            else
            {
                _maze.MazeArray[current.Position.X, current.Position.Y].CellWalls[2] = false;
                _maze.MazeArray[next.Position.X, next.Position.Y].CellWalls[0] = false;
            }
        }

        private List<Point> GetCurrentCellNeighbours(Cell current)
        {
            var neighbours = new List<Point>();

            var tempPos = current.Position;
            // Check right neigbour cell 
            tempPos.X = current.Position.X - 1;
            if (tempPos.X >= 0 && AllWallsIntact(_maze.MazeArray[tempPos.X, tempPos.Y]))
            {
                neighbours.Add(tempPos);
            }

            // Check left neigbour cell 
            tempPos.X = current.Position.X + 1;
            if (tempPos.X < _maze.Width && AllWallsIntact(_maze.MazeArray[tempPos.X, tempPos.Y]))
            {
                neighbours.Add(tempPos);
            }

            // Check Upper neigbour cell 
            tempPos.X = current.Position.X;
            tempPos.Y = current.Position.Y - 1;
            if (tempPos.Y >= 0 && AllWallsIntact(_maze.MazeArray[tempPos.X, tempPos.Y]))
            {
                neighbours.Add(tempPos);
            }

            // Check Lower neigbour cell 
            tempPos.Y = current.Position.Y + 1;
            if (tempPos.Y < _maze.Height && AllWallsIntact(_maze.MazeArray[tempPos.X, tempPos.Y]))
            {
                neighbours.Add(tempPos);
            }

            return neighbours;
        }

        private List<Cell> GetCurrentCanVisitCellNeighbours(Cell current)
        {
            var neighbours = new List<Cell>();

            var tempPos = current.Position;
            // Check left neigbour cell 
            tempPos.X = current.Position.X - 1;
            if (tempPos.X >= 0 && _maze.MazeArray[tempPos.X, tempPos.Y].CellWalls[2] == false)
            {
                neighbours.Add(_maze.MazeArray[tempPos.X, tempPos.Y]);
            }

            // Check right neigbour cell 
            tempPos.X = current.Position.X + 1;
            if (tempPos.X < _maze.Width && _maze.MazeArray[tempPos.X, tempPos.Y].CellWalls[0] == false)
            {
                neighbours.Add(_maze.MazeArray[tempPos.X, tempPos.Y]);
            }

            // Check Upper neigbour cell 
            tempPos.X = current.Position.X;
            tempPos.Y = current.Position.Y - 1;
            if (tempPos.Y >= 0 && _maze.MazeArray[tempPos.X, tempPos.Y].CellWalls[3] == false)
            {
                neighbours.Add(_maze.MazeArray[tempPos.X, tempPos.Y]);
            }

            // Check Lower neigbour cell 
            tempPos.Y = current.Position.Y + 1;
            if (tempPos.Y < _maze.Height && _maze.MazeArray[tempPos.X, tempPos.Y].CellWalls[1] == false)
            {
                neighbours.Add(_maze.MazeArray[tempPos.X, tempPos.Y]);
            }

            return neighbours;
        }

        private bool AllWallsIntact(Cell cell)
        {
            for (var i = 0; i < 4; i++)
            {
                if (!_maze.MazeArray[cell.Position.X, cell.Position.Y].CellWalls[i])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion Depth-First Search
    }
}