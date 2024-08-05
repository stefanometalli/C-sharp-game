namespace WindowsForm;

public partial class Form1 : Form
{

    private Image sprite;
    private GameObject gameObject;
    private GameWorld gameWorld;

    public Form1()
    {
        InitializeComponent();
        gameWorld = new GameWorld(DisplayRectangle, CreateGraphics());
    }

    private void GameLoop_Tick(object sender, EventArgs e)
    {
        gameWorld.update();
    }
}
