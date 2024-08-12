using WindowsForm.Classes;

public class GameObject : IComparable<GameObject>
{

    private Transform transform;
    private Dictionary<string, Component> components = new Dictionary<string, Component>();

    public string Tag { get; set; }

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
        if (components.ContainsKey(componentName))
        {
            return components[componentName];
        }
        return null;
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
        foreach (var component in components.Values)
        {
            if (component.IsEnabled)
            {
                component.Update();
            }
        }
    }

    public void Destroy()
    {
        foreach(var component in components.Values)
        {
            component.Destroy();
        }
        components.Clear();
        GameWorld.Destroy(this);
    }

    public int CompareTo(GameObject? other)
    {
        SpriteRenderer otherRenderer = (SpriteRenderer)other.GetComponent("SpriteRenderer");
        SpriteRenderer renderer = (SpriteRenderer)this.GetComponent("SpriteRenderer");

        if (otherRenderer != null && renderer != null)
        {
            if (renderer.SortOrder > otherRenderer.SortOrder)
            {
                return 1;
            }
            else if (renderer.SortOrder < otherRenderer.SortOrder)
            {
                return -1;
            }
            return 0;
        }
        else
        {
            return -1;
        }
    }
}
