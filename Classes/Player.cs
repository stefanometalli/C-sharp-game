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
    private Animator animator;
    private Collider collider;
    private GameObject shield;

    private float shootCooldown = 1;
    private float timeSinceLastShot;
    private bool canShoot = true;
    private bool immortal = false;
    private float immortalTime;
    private float immortalDuration = 3;
    private float blinkCooldown = .2f;
    private float timeSinceLastBlink;


    public override void Awake()
    {
        GameObject.Tag = "Player";
        speed = 200;
        spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
        spriteRenderer.SetSprite("player");
        spriteRenderer.ScaleFactor = 0.7f;
        collider = (Collider)GameObject.GetComponent("Collider");
        collider.CollisionHandler += Collision;
        animator = (Animator)GameObject.GetComponent("Animator");
        animator.AddAnimation(new Animation("PlayerFly", 10));
        animator.PlayAnimation("PlayerFly");
        GameObject.Transform.Position = new Vector2(GameWorld.WorldSize.Width / 2 - spriteRenderer.Rectangle.Width / 2, GameWorld.WorldSize.Height - spriteRenderer.Rectangle.Height);
        Reset();
    }

    public override void Update()
    {
        GetInput();
        Move();
        ScreenLimits();
        ScreenWarp();
        HandleShootCooldown();
        Immortality();
    }

    private void GetInput()
    {
        velocity = Vector2.Zero;

        if (Keyboard.IsKeyDown(Keys.W) || Keyboard.IsKeyDown(Keys.Up))
        {
            velocity += new Vector2(0, -1);
        }
        if (Keyboard.IsKeyDown(Keys.A) || Keyboard.IsKeyDown(Keys.Left))
        {
           velocity += new Vector2(-1, 0);
        }
        if (Keyboard.IsKeyDown(Keys.S) || Keyboard.IsKeyDown(Keys.Down))
        {
            velocity += new Vector2(0, 1);
        }
        if (Keyboard.IsKeyDown(Keys.D) || Keyboard.IsKeyDown(Keys.Right))
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
        if (GameObject.Transform.Position.Y > GameWorld.WorldSize.Height - spriteRenderer.Rectangle.Height)
        {
            GameObject.Transform.Position = new Vector2(GameObject.Transform.Position.X, GameWorld.WorldSize.Height - spriteRenderer.Rectangle.Height);
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

    private void Collision(Collider other)
    {
        if (other.GameObject.Tag == "Enemy" && !immortal)
        {
            if (shield != null)
            {
                GameWorld.Destroy(shield);
                shield = null;
            }
            else
            {
                immortal = true;
                GameManager.RemoveLife();
                Reset();
            }
        }
    }

    private void Reset()
    {
        if (GameManager.LifeCount == 0)
        {
            RemovePlayer();
        }
        else
        {
            GameObject.Transform.Position = new Vector2(GameWorld.WorldSize.Width / 2 - spriteRenderer.Rectangle.Width / 2, GameWorld.WorldSize.Height - spriteRenderer.Rectangle.Height);
        }
    }

    private void RemovePlayer()
    {
        Explode();
        GameObject.Destroy();
    }

    public override void Destroy()
    {
        collider.Destroy();
    }



    private void Explode()
    {
        GameObject explosion = new GameObject();
        explosion.AddComponent(new SpriteRenderer());
        explosion.AddComponent(new Animator());
        explosion.AddComponent(new Explosion(GameObject.Transform.Position));
        GameWorld.Instatiate(explosion);
    }

    public void ApplyShield()
    {
        if (shield == null)
        {
            shield = new GameObject();
            shield.AddComponent(new Shield(GameObject.Transform, new Vector2(-35, -35)));
            shield.AddComponent(new SpriteRenderer(3));
            shield.AddComponent(new Collider());
            GameWorld.Instatiate(shield);
        }
    }

    public void Immortality()
    {
        if (immortal)
        {
            timeSinceLastBlink += MyTime.DeltaTime;

            if (timeSinceLastBlink >= blinkCooldown)
            {
                spriteRenderer.IsEnabled = !spriteRenderer.IsEnabled;
                timeSinceLastBlink = 0;
            }

            immortalTime += MyTime.DeltaTime;

            if (immortalTime >= immortalDuration)
            {
                immortal = false;
                spriteRenderer.IsEnabled = true;
                immortalTime = 0;
                timeSinceLastBlink = 0;
            }
        }
    }
}
