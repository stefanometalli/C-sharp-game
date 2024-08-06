using WindowsForm.Classes;

class GameObject
{

    private Transform transform;
    private Dictionary<string, Component> components = new Dictionary<string, Component>();

    public GameObject()
    {
        this.transform = new Transform();
    }

    public Transform Transform { get { return this.transform; } private set { } }

    public void AddComponent(Component component)
    {
        components.Add(component.ToString(), component);
        component.GameObject = this;
    }

    public Component GetComponent(string componentName)
    {
        return components[componentName];
    }

    public bool HasComponent(string componentName) 
    { 
        return components.ContainsKey(componentName);
    }

    public void Awake()
    {
        foreach (var component in components.Values)
        {
            component.Awake();
        }
    }

    public void Start() 
    {
        foreach (var component in components.Values)
        {
            if (component.IsEnabled)
            {
                component.Start();
            }
        }
    }

    public void update()
    {
        /**
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
        */
        foreach (var component in components.Values)
        {
            if (component.IsEnabled)
            {
                component.Update();
            }
        }
    }
}
