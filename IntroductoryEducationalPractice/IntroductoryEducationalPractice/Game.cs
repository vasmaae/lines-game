using System.Runtime.CompilerServices;

namespace IntroductoryEducationalPractice;

public class Game
{
    private int[,] _fieldBalls;
    private int[] _nextStepBall;

    public Game()
    {
        _fieldBalls = new int[9, 9];
        _nextStepBall = new int[3];
    }

    public void RenderGame(Graphics g)
    {
        Pen pen = new(Color.Black);

        for (int i = 0; i <= _fieldBalls.GetLength(0); i++)
        {
            g.DrawLine(pen, 60 * i, 0, 60 * i, _fieldBalls.GetLength(0) * 60);
        }
        for (int i = 0; i <= _fieldBalls.GetLength(1); i++)
        {
            g.DrawLine(pen, 0, 60 * i, _fieldBalls.GetLength(1) * 60, 60 * i);
        }
    }

    public void RenderNextStep(Graphics g)
    {
        Pen pen = new(Color.Black);

        for (int i = 0; i <= _nextStepBall.Length; i++)
        {
            g.DrawLine(pen, 60 * i, 0, 60 * i, 60);
        }
        for (int i = 0; i <= 1; i++)
        {
            g.DrawLine(pen, 0, 60 * i, _nextStepBall.Length * 60, 60 * i);
        }
    }
}

file class Ball
{
    public int X { get; set; }
    public int Y { get; set; }
    public BallColor BallColor { get; private set; }

    Ball(BallColor ballColor)
    {
        BallColor = ballColor;
        X = 0;
        Y = 0;
    }

    public Color ToColor()
    {
        switch (BallColor)
        {
            case BallColor.YELLOW:
                return Color.Yellow;
            case BallColor.BLUE:
                return Color.Blue;
            case BallColor.TURQUOISE:
                return Color.AliceBlue;
            case BallColor.PURPLE:
                return Color.Purple;
            case BallColor.PINK:
                return Color.Pink;
            case BallColor.ORANGE:
                return Color.Orange;
            default:
                return Color.White;
        }
    }
}

file enum BallColor
{
    YELLOW = 1,
    BLUE = 2,
    TURQUOISE = 3,
    PURPLE = 4,
    PINK = 5,
    ORANGE = 6,
}