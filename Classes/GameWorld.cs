class GameWorld
{

    private Graphics graphics;
    private Color backgroundColor;
    private Size worldSize;
    private GameObject gameObject;


    public GameWorld(Size worldSize, Graphics graphics)
    {
        this.worldSize = worldSize;
        this.graphics = graphics;
        this.backgroundColor = ColorTranslator.FromHtml("#000c41");
    }

    public void update()
    {
        gameObject.update();
    }

}