using WindowsForm.Classes;

class GameObject
{

    private Image sprite;
    private Graphics graphics;
    private Transform transform;
    private bool mainCharacter;
    private Dictionary<string, Component> components = new Dictionary<string, Component>();

    public GameObject(Graphics graphics, Image sprite, Point position)
    {
        this.sprite = sprite;
        this.graphics = graphics;
        this.transform = new Transform();
        transform.Position = new System.Numerics.Vector2(position.X, position.Y);
    }

    public GameObject(Graphics graphics, Image sprite, Point position, bool mainCharacter)
    {
        this.sprite = sprite;
        this.graphics = graphics;
        this.transform = new Transform();
        transform.Position = new System.Numerics.Vector2(position.X, position.Y);
        this.mainCharacter = mainCharacter;
    }

    public Image Sprite { get { return this.sprite; } }

    public void AddComponent(Component component)
    {
        components.Add(component.ToString(), component);
    }

    public void start() { }

    public void update()
    {
        foreach (var component in components.Values)
        {
            component.Update();
        }
        /**
        if ((this.mainCharacter))
        {
            if (Keyboard.IsKeyDown(Keys.D))
            {
                transform.Position.X += 1;
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
        }
        */
        graphics.DrawImage(sprite, transform.Position.X, transform.Position.Y);
        
    }
}
