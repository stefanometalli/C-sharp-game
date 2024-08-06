using WindowsForm.Classes;
using System.Numerics;

class Player : Component
{
    private int health;
    public int strength;
    protected int mana;

    private Vector2 velocity;
    private float speed;
    private SpriteRenderer spriteRenderer;

    public override void Awake()
    {
        speed = 200;
        spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
        spriteRenderer.SetSprite("player");
        spriteRenderer.ScaleFactor = 0.7f;
        GameObject.Transform.Position = new Vector2(GameWorld.WorldSize.Width / 2 - spriteRenderer.Rectangle.Width / 2, GameWorld.WorldSize.Height - spriteRenderer.Rectangle.Height);
    }

    public override void Update()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        velocity = Vector2.Zero;

        if (Keyboard.IsKeyDown(Keys.W))
        {
            velocity += new Vector2(0, -1);
        }
        if (Keyboard.IsKeyDown(Keys.A))
        {
           velocity += new Vector2(-1, 0);
        }
        if (Keyboard.IsKeyDown(Keys.S))
        {
            velocity += new Vector2(0, 1);
        }
        if (Keyboard.IsKeyDown(Keys.D))
        {
            velocity += new Vector2(1, 0);
        }

        velocity = Vector2.Normalize(velocity);
    }

    private void Move()
    {
        GameObject.Transform.Translate(velocity * speed * MyTime.DeltaTime);
    }

    public override string ToString()
    {
        return "Player";
    }
}
