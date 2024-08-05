class GameObject
{

    private Image sprite;
    private Graphics graphics;
    private Point position;

    public GameObject(Graphics graphics, Point position)
    {
        this.sprite = Image.FromFile(@"Sprites/player.png");
        this.graphics = graphics;
        this.position = position;
        this.position.X = this.position.X - sprite.Width / 2;
        this.position.Y = this.position.Y - sprite.Height;
    }

    public Point Position { get { return this.position; } set { this.position = value; } }

    public Image Sprite { get { return this.sprite; } }

    public void start() { }

    public void update()
    {
        graphics.DrawImage(sprite, this.position.X, this.position.Y);
    }
}
