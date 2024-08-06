using WindowsForm.Classes;

class GameWorld
{

    private Graphics dc;
    private Color backgroundColor;
    public static Size WorldSize { get; private set; }
    private GameObject gameObject;
    private GameObject secondGameObject;
    private BufferedGraphics bufferedGraphics;


    public GameWorld(Rectangle displayRectangle, Graphics graphics)
    {
        WorldSize = displayRectangle.Size;
        this.bufferedGraphics = BufferedGraphicsManager.Current.Allocate(graphics, displayRectangle);
        this.dc = bufferedGraphics.Graphics;
        this.backgroundColor = ColorTranslator.FromHtml("#000c41");

        Image sprite = Image.FromFile(@"Sprites/player.png");
        gameObject = new GameObject(true);
        secondGameObject = new GameObject();

        SpriteRenderer sr = new SpriteRenderer(dc);
        sr.SetSprite("player");

        gameObject.AddComponent(sr);
    }

    public void update()
    {
        dc.Clear(this.backgroundColor);
        gameObject.update();
        secondGameObject.update();

        bufferedGraphics.Render();
    }

}