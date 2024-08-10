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

    private float shootCooldown = 1;
    private float timeSinceLastShot;
    private bool canShoot = true;

    public override void Awake()
    {
        GameObject.Tag = "Player";
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
        ScreenLimits();
        ScreenWarp();
        HandleShootCooldown();
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
        if (Keyboard.IsKeyDown(Keys.Space))
        {
            Shoot();
        }

        velocity = Vector2.Normalize(velocity);
    }

    private void Move()
    {
        GameObject.Transform.Translate(velocity * speed * MyTime.DeltaTime);
    }

    private void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            timeSinceLastShot = 0;
            GameObject laser = new GameObject();
            Vector2 spawnPosition = new Vector2(GameObject.Transform.Position.X + spriteRenderer.Rectangle.Width / 2 - 3, GameObject.Transform.Position.Y - 18);
            laser.AddComponent(new Laser("laser", new Vector2(0, -1), spawnPosition));
            laser.AddComponent(new SpriteRenderer(1));
            laser.AddComponent(new Collider());
            GameWorld.Instatiate(laser);
        }
    }

    private void HandleShootCooldown()
    {
        if(!canShoot)
        {
            timeSinceLastShot += MyTime.DeltaTime;
        }
        if (timeSinceLastShot >= shootCooldown)
        {
            canShoot = true;
        }
    }

    public override string ToString()
    {
        return "Player";
    }

    private void ScreenLimits()
    {
        if (GameObject.Transform.Position.Y < 0)
        {
            GameObject.Transform.Position = new Vector2(GameObject.Transform.Position.X, 0);
        }
        if (GameObject.Transform.Position.Y > GameWorld.WorldSize.Height - spriteRenderer.Sprite.Height)
        {
            GameObject.Transform.Position = new Vector2(GameObject.Transform.Position.X, GameWorld.WorldSize.Height - spriteRenderer.Sprite.Height);
        }
    }

    private void ScreenWarp()
    {
        if (GameObject.Transform.Position.X + spriteRenderer.Sprite.Width < 0)
        {
            GameObject.Transform.Position = new Vector2(GameWorld.WorldSize.Width, GameObject.Transform.Position.Y);

        }
        if (GameObject.Transform.Position.X > GameWorld.WorldSize.Width)
        {
            GameObject.Transform.Position = new Vector2(0 - spriteRenderer.Sprite.Width, GameObject.Transform.Position.Y);
        }
    }
}
