namespace WindowsForm;

public partial class Form1 : Form
{

    private Image sprite;
    private GameObject gameObject;
    private GameWorld gameWorld;

    public Form1()
    {
        InitializeComponent();
        gameWorld = new GameWorld(DisplayRectangle.Size, CreateGraphics());
        gameObject = new GameObject(CreateGraphics(), new Point(0,0));
        gameObject.Position = new Point(DisplayRectangle.Width/2 - gameObject.Sprite.Width / 2, DisplayRectangle.Height - gameObject.Sprite.Height);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        gameObject.update();
    }
}
