using WindowsForm.Classes;

class GameWorld
{

    private Color backgroundColor;
    public static Size WorldSize { get; private set; }
    private GameObject gameObject;
    private BufferedGraphics bufferedGraphics;

    public static Graphics Graphics { get; private set; }


    public GameWorld(Rectangle displayRectangle, Graphics graphics)
    {
        WorldSize = displayRectangle.Size;
        bufferedGraphics = BufferedGraphicsManager.Current.Allocate(graphics, displayRectangle);
        Graphics = bufferedGraphics.Graphics;
        backgroundColor = ColorTranslator.FromHtml("#000c41");
        Initialize();

    }

    public void update()
    {
        Graphics.Clear(backgroundColor);
        gameObject.update();
        bufferedGraphics.Render();
    }

    private void Initialize()
    {
        gameObject = new GameObject();
        Player player = new Player();
        SpriteRenderer sr = new SpriteRenderer();
        gameObject.AddComponent(player);
        gameObject.AddComponent(sr);

        Awake();
        Start();
    }

    private void Awake()
    {
        gameObject.Awake();

    }

    private void Start()
    {

    }

}