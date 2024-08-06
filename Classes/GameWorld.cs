using WindowsForm.Classes;

class GameWorld
{

    private Color backgroundColor;
    public static Size WorldSize { get; private set; }
    private List<GameObject> gameObjects = new List<GameObject>();
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

    private void Initialize()
    {
        GameObject player = new GameObject();
        player.AddComponent(new Player());
        player.AddComponent(new SpriteRenderer());
        gameObjects.Add(player);

        GameObject enemy = new GameObject();
        enemy.AddComponent(new Enemy());
        enemy.AddComponent(new SpriteRenderer());
        gameObjects.Add(enemy);

        Awake();
        Start();
    }

    private void Awake()
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.Awake();
        }
    }

    private void Start()
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.Start();
        }
    }

    public void update()
    {
        MyTime.CalcDeltaTime();
        Graphics.Clear(backgroundColor);
        foreach (var gameObject in gameObjects)
        {
            gameObject.update();
        }
        bufferedGraphics.Render();
    }

}