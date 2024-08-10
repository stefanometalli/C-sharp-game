using System.Numerics;
using WindowsForm.Classes;

class GameWorld
{

    private Color backgroundColor;
    public static Size WorldSize { get; private set; }
    private static List<GameObject> gameObjects = new List<GameObject>();
    private BufferedGraphics bufferedGraphics;

    public static bool Debug { get; set; } = false;

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
        player.AddComponent(new SpriteRenderer(2));
        player.AddComponent(new Collider());
        gameObjects.Add(player);

        GameObject enemy = new GameObject();
        enemy.AddComponent(new Enemy());
        enemy.AddComponent(new SpriteRenderer(1));
        enemy.AddComponent(new Collider());
        gameObjects.Add(enemy);

        GameObject background = new GameObject();
        background.AddComponent(new Background("Bg1_Trans", Vector2.Zero, 20));
        background.AddComponent(new SpriteRenderer(0));
        gameObjects.Add(background);

        gameObjects.Sort();
        Awake();
        Start();
    }

    private void Awake()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].Awake();
        }
    }

    private void Start()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].Start();
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
        gameObjects.Sort();
    }

    public static void Destroy(GameObject go) 
    {
        gameObjects.Remove(go);
    }

}