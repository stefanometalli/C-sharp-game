using WindowsForm.Classes;

class GameWorld
{

    private Color backgroundColor;
    public static Size WorldSize { get; private set; }
    private static List<GameObject> gameObjects = new List<GameObject>();
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

        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].update();
        }

        bufferedGraphics.Render();
    }

    public static void Instatiate(GameObject go)
    {
        go.Awake();
        go.Start();
        gameObjects.Add(go);
    }

    public static void Destroy(GameObject go) 
    {
        gameObjects.Remove(go);
    }

}