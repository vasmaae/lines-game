namespace IntroductoryEducationalPractice;

public partial class FormGame : Form
{
    private Game game;

    public FormGame()
    {
        InitializeComponent();
        game = new();
    }

    private void PictureBoxGame_Click(object sender, EventArgs e)
    {
        Bitmap bmpGame = new(pictureBoxGame.Width, pictureBoxGame.Height);
        Graphics gGame = Graphics.FromImage(bmpGame);
        game.RenderGame(gGame);

        Bitmap bmpNextStep = new(pictureBoxNextStep.Width, pictureBoxNextStep.Height);
        Graphics gNextStep = Graphics.FromImage(bmpNextStep);
        game.RenderNextStep(gNextStep);

        pictureBoxGame.Image = bmpGame;
        pictureBoxNextStep.Image = bmpNextStep;
    }
}
