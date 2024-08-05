class GameWorld
{

    private Graphics dc;
    private Color backgroundColor;
    private Size worldSize;
    private GameObject gameObject;
    private GameObject secondGameObject;
    private BufferedGraphics bufferedGraphics;


    public GameWorld(Rectangle displayRectangle, Graphics graphics)
    {
        this.worldSize = displayRectangle.Size;
        this.bufferedGraphics = BufferedGraphicsManager.Current.Allocate(graphics, displayRectangle);
        this.dc = bufferedGraphics.Graphics;
        this.backgroundColor = ColorTranslator.FromHtml("#000c41");

        Image sprite = Image.FromFile(@"Sprites/player.png");
        gameObject = new GameObject(dc, sprite, new Point(this.worldSize.Width/2 - sprite.Width/2, this.worldSize.Height - sprite.Height));
        secondGameObject = new GameObject(dc, sprite, new Point(0, 0));
    }

    public void update()
    {
        dc.Clear(this.backgroundColor);
        gameObject.update();
        secondGameObject.update();

        bufferedGraphics.Render();
    }

}