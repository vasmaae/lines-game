namespace IntroductoryEducationalPractice;

public partial class FormGame : Form
{
    private Game game;

    private bool isSelected = false;
    private (int, int) selectedBall;

    public FormGame()
    {
        InitializeComponent();
        game = new();
        Render();
    }

    private void PictureBoxGame_Click(object sender, MouseEventArgs e)
    {
        (int, int) position = (e.X / 60, e.Y / 60);

        if (isSelected && !game.IsBall(position) && selectedBall != position)
        {
            if (game.ReplaceBall(selectedBall, position))
                game.GenerateBalls();
            isSelected = false;
        }
        else if (!isSelected && game.IsBall(position))
        {
            selectedBall = position;
            isSelected = true;
        }
        else if (isSelected && game.IsBall(position))
            isSelected = false;
        
        Render();

        if (game.CountOfAvailablePositions < 3)
            MessageBox.Show("Вы проиграли:(\nНачините заново с помощью кнопки \"Новая Игра\"", "Проигрыш", MessageBoxButtons.OK, MessageBoxIcon.Question);

    }

    private void Render()
    {
        Bitmap bmpGame = new(pictureBoxGame.Width, pictureBoxGame.Height);
        Graphics gGame = Graphics.FromImage(bmpGame);
        game.RenderGame(gGame, isSelected, selectedBall);

        Bitmap bmpNextStep = new(pictureBoxNextStep.Width, pictureBoxNextStep.Height);
        Graphics gNextStep = Graphics.FromImage(bmpNextStep);
        game.RenderNextStep(gNextStep);

        pictureBoxGame.Image = bmpGame;
        pictureBoxNextStep.Image = bmpNextStep;
        labelCountOfPoints.Text = game.Points.ToString();
    }

    private void ButtonNewGame_Click(object sender, EventArgs e)
    {
        game = new();
        Render();
    }
}
