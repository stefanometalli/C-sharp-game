using WindowsForm.Classes;

class GameObject
{

    private Transform transform;
    private bool mainCharacter;
    private Dictionary<string, Component> components = new Dictionary<string, Component>();

    public GameObject()
    {
        this.transform = new Transform();
    }

    public GameObject(bool mainCharacter)
    {
        this.transform = new Transform();
        this.mainCharacter = mainCharacter;
    }

    public Transform Transform { get { return this.transform; } private set { } }

    public void AddComponent(Component component)
    {
        components.Add(component.ToString(), component);
        component.GameObject = this;
    }

    public void start() { }

    public void update()
    {
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
        foreach (var component in components.Values)
        {
            component.Update();
        }
    }
}
