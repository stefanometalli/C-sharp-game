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

    public void Initialize()
    {
        for (int i = 0; i < gameObjects.Count; i++) 
        {
            gameObjects[i].Destroy();
        }
        gameObjects.Clear();
        GameManager.Reset();

        GameObject player = new GameObject();
        player.AddComponent(new Player());
        player.AddComponent(new SpriteRenderer(2));
        player.AddComponent(new Collider());
        player.AddComponent(new Animator());
        gameObjects.Add(player);

        GameObject enemy = new GameObject();
        enemy.AddComponent(new Enemy());
        enemy.AddComponent(new SpriteRenderer(1));
        enemy.AddComponent(new Collider());
        enemy.AddComponent(new Animator());
        gameObjects.Add(enemy);

        GameObject background1 = new GameObject();
        GameObject background2 = new GameObject();
        GameObject background3 = new GameObject();

        background1.AddComponent(new Background("Bg1_Trans", Vector2.Zero, 40, background3.Transform));
        background1.AddComponent(new SpriteRenderer(0));
        gameObjects.Add(background1);

        background2.AddComponent(new Background("Bg2_Trans", new Vector2(0, -768), 40, background1.Transform));
        background2.AddComponent(new SpriteRenderer(0));
        gameObjects.Add(background2);

        background3.AddComponent(new Background("Bg3_Trans", new Vector2(0, -768*2), 40, background2.Transform));
        background3.AddComponent(new SpriteRenderer(0));
        gameObjects.Add(background3);

        GameObject smoke = new GameObject();
        smoke.AddComponent(new SpriteRenderer());
        smoke.AddComponent(new BackgroundElement("space-smoke_01"));
        gameObjects.Add(smoke);

        GameObject planet = new GameObject();
        planet.AddComponent(new SpriteRenderer());
        planet.AddComponent(new BackgroundElement("planet_01"));
        gameObjects.Add(planet);

        for (int i = 0; i < 3; i++)
        {
            GameManager.AddLife();
        }

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

        for (int i = 0; i < GameManager.UIElements.Count; i++)
        {
            GameManager.UIElements[i].update();
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