class GameObject
{

    private Image sprite;
    private Graphics graphics;
    private Point position;

    public GameObject(Graphics graphics, Image sprite, Point position)
    {
        this.sprite = sprite;
        this.graphics = graphics;
        this.position = position;
    }

    public Point Position { get { return this.position; } set { this.position = value; } }

    public Image Sprite { get { return this.sprite; } }

    public void start() { }

    public void update()
    {
        if (Keyboard.IsKeyDown(Keys.D))
        {
            position.X += 1;
        }
        if (Keyboard.IsKeyDown(Keys.A))
        {
            position.X -= 1;
        }
        if (Keyboard.IsKeyDown(Keys.W))
        {
            position.Y -= 1;
        }
        if (Keyboard.IsKeyDown(Keys.S))
        {
            position.Y += 1;
        }
        graphics.DrawImage(sprite, this.position.X, this.position.Y);
    }
}
