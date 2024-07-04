namespace IntroductoryEducationalPractice;

public class Game
{
    private Random random;

    private List<Position> _availablePositions;

    private int[,] _fieldBalls;
    private int[] _nextStepBalls;
    private int _points;

    public int Points => _points;
    public int CountOfAvailablePositions => _availablePositions.Count;

    public Game()
    {
        _points = 0;
        random = new();

        _availablePositions = new();
        for (int i = 0; i < 81; i++)
            _availablePositions.Add(new Position(i / 9, i % 9));

        _nextStepBalls = new int[3];
        for (int i = 0; i < _nextStepBalls.Length; i++)
            _nextStepBalls[i] = random.Next(1, 7);

        _fieldBalls = new int[9, 9];
        GenerateBalls();
    }

    public bool IsBall((int, int) position)
    {
        if (_fieldBalls[position.Item1, position.Item2] == 0) return false;
        else return true;
    }

    public void GenerateBalls()
    {
        if (_availablePositions.Count < _nextStepBalls.Length) return;

        int index;
        Position position;

        DeleteSeries();

        for (int i = 0; i < _nextStepBalls.Length; i++)
        {
            index = random.Next(0, _availablePositions.Count);
            position = _availablePositions[index];
            _fieldBalls[position.x, position.y] = _nextStepBalls[i];

            _availablePositions.RemoveAt(index);
            _nextStepBalls[i] = random.Next(1, 7);
        }
    }

    private void DeleteSeries()
    {
        int counter;
        int currentRangeStartIndex;

        for (int i = 0; i < _fieldBalls.GetLength(0); i++)
        {
            counter = 0;
            currentRangeStartIndex = 0;

            for (int j = 0; j < _fieldBalls.GetLength(1); j++)
            {
                if (_fieldBalls[i, currentRangeStartIndex] == _fieldBalls[i, j]) counter++;
                else if (_fieldBalls[i, currentRangeStartIndex] != _fieldBalls[i, j] && counter >= 5) break;
                else
                {
                    counter = 1;
                    currentRangeStartIndex = j;
                }
            }

            if (_fieldBalls[i, currentRangeStartIndex] != 0 && counter >= 5)
            {
                for (int j = currentRangeStartIndex; j < currentRangeStartIndex + counter; j++)
                {
                    _availablePositions.Add(new Position(i, j));
                    _fieldBalls[i, j] = 0;
                }
                _points += counter * 2;
            }
        }

        for (int j = 0; j < _fieldBalls.GetLength(1); j++)
        {
            counter = 0;
            currentRangeStartIndex = 0;

            for (int i = 0; i < _fieldBalls.GetLength(0); i++)
            {
                if (_fieldBalls[currentRangeStartIndex, j] == _fieldBalls[i, j]) counter++;
                else if (_fieldBalls[currentRangeStartIndex, j] != _fieldBalls[i, j] && counter >= 5) break;
                else
                {
                    counter = 1;
                    currentRangeStartIndex = i;
                }
            }

            if (_fieldBalls[currentRangeStartIndex, j] != 0 && counter >= 5)
            {
                for (int i = currentRangeStartIndex; i < currentRangeStartIndex + counter; i++)
                {
                    _availablePositions.Add(new Position(i, j));
                    _fieldBalls[i, j] = 0;
                }
                _points += counter * 2;
            }
        }
    }

    public bool ReplaceBall((int, int) start, (int, int) end)
    {
        if (RoadExists(start, end))
        {
            _availablePositions.Add(new Position(start.Item1, start.Item2));

            for (int i = 0; i < _availablePositions.Count; i++)
            {
                if (_availablePositions[i].x == end.Item1 && _availablePositions[i].y == end.Item2)
                {
                    _availablePositions.RemoveAt(i);
                    break;
                }
            }

            _fieldBalls[end.Item1, end.Item2] = _fieldBalls[start.Item1, start.Item2];
            _fieldBalls[start.Item1, start.Item2] = 0;

            return true;
        }
        else return false;
    }

    private bool RoadExists((int, int) start, (int, int) end)
    {
        int[,] maze = new int[_fieldBalls.GetLength(0), _fieldBalls.GetLength(1)];
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                maze[i, j] = _fieldBalls[i, j];
            }
        }
        return WaveTraycing(maze, start, end);
    }

    private bool WaveTraycing(int[,] maze, (int, int) start, (int, int) finish)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);

        if (start.Item1 == finish.Item1 && start.Item2 == finish.Item2)
            return false;

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue(start);

        maze[start.Item1, start.Item2] = -1;

        int[] moveX = { 0, 0, 1, -1 };
        int[] moveY = { 1, -1, 0, 0 };

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int nextX = current.Item1 + moveX[i];
                int nextY = current.Item2 + moveY[i];

                if (nextX >= 0 && nextX < rows && nextY >= 0 && nextY < cols && maze[nextX, nextY] == 0)
                {
                    if (nextX == finish.Item1 && nextY == finish.Item2)
                        return true;

                    maze[nextX, nextY] = -1;
                    queue.Enqueue((nextX, nextY));
                }
            }
        }

        return false;
    }

    public void RenderGame(Graphics g, bool isSelected, (int, int) selectedBall)
    {
        Pen pen = new(Color.Black);
        Brush brush;

        for (int i = 0; i <= _fieldBalls.GetLength(0); i++)
        {
            g.DrawLine(pen, 60 * i, 0, 60 * i, _fieldBalls.GetLength(0) * 60);
        }
        for (int i = 0; i <= _fieldBalls.GetLength(1); i++)
        {
            g.DrawLine(pen, 0, 60 * i, _fieldBalls.GetLength(1) * 60, 60 * i);
        }

        for (int i = 0; i < _fieldBalls.GetLength(0); i++)
        {
            for (int j = 0; j < _fieldBalls.GetLength(1); j++)
            {
                if (_fieldBalls[i, j] != 0)
                {
                    brush = new SolidBrush(ToColor((BallColor)_fieldBalls[i, j]));
                    g.FillEllipse(brush, 60 * i + 10, 60 * j + 10, 40, 40);
                    g.DrawEllipse(pen, 60 * i + 10, 60 * j + 10, 40, 40);
                }
            }
        }

        if (isSelected)
        {
            Pen red = new(Color.Red, 3);

            g.DrawRectangle(red, 60 * selectedBall.Item1, 60 * selectedBall.Item2, 60, 60);
        }
    }

    public void RenderNextStep(Graphics g)
    {
        Pen pen = new(Color.Black);
        Brush brush;

        for (int i = 0; i <= _nextStepBalls.Length; i++)
        {
            g.DrawLine(pen, 60 * i, 0, 60 * i, 60);
        }
        for (int i = 0; i <= 1; i++)
        {
            g.DrawLine(pen, 0, 60 * i, _nextStepBalls.Length * 60, 60 * i);
        }

        for (int i = 0; i < _nextStepBalls.Length; i++)
        {
            brush = new SolidBrush(ToColor((BallColor)_nextStepBalls[i]));
            g.FillEllipse(brush, 60 * i + 10, 10, 40, 40);
            g.DrawEllipse(pen, 60 * i + 10, 10, 40, 40);
        }
    }

    private Color ToColor(BallColor color)
    {
        switch (color)
        {
            case BallColor.YELLOW: return Color.Yellow;
            case BallColor.BLUE: return Color.Blue;
            case BallColor.TURQUOISE: return Color.LightBlue;
            case BallColor.PURPLE: return Color.Purple;
            case BallColor.PINK: return Color.Pink;
            case BallColor.ORANGE: return Color.Orange;
        }
        return Color.Red;
    }

    private enum BallColor
    {
        YELLOW = 1,
        BLUE,
        TURQUOISE,
        PURPLE,
        PINK,
        ORANGE,
    }

    public struct Position
    {
        public int x, y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
