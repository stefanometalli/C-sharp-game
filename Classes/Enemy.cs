using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm.Classes
{
    class Enemy : Component
    {
        private SpriteRenderer spriteRenderer;
        private float speed;
        private static Random random = new Random();
        private Animator animator;
        private Collider collider;

        public override void Awake()
        {
            GameObject.Tag = "Enemy";
            speed = 100;
            collider = (Collider)GameObject.GetComponent("Collider");
            collider.CollisionHandler += Collision;
            spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
            spriteRenderer.SetSprite("enemy_01");
            spriteRenderer.ScaleFactor = 0.7f;
            GameObject.Transform.Position = new Vector2(random.Next((int)spriteRenderer.Rectangle.Width, (int)GameWorld.WorldSize.Width - (int)spriteRenderer.Rectangle.Width), -spriteRenderer.Rectangle.Height);
            animator = (Animator)GameObject.GetComponent("Animator");
            animator.AddAnimation(new Animation("EnemyFly", 10));
            animator.PlayAnimation("EnemyFly");
        }

        public override void Update()
        {
            Move();
            ScreenBounds();
        }

        private void Move()
        {
            GameObject.Transform.Translate(new Vector2(0, 1) * speed * MyTime.DeltaTime);
        }

        private void ScreenBounds()
        {
            if (GameObject.Transform.Position.Y > GameWorld.WorldSize.Height)
            {
                Reset();
            }
        }

        private void Reset()
        {
            GameObject.Transform.Position = new Vector2(random.Next((int)spriteRenderer.Rectangle.Width, (int)GameWorld.WorldSize.Width -(int)spriteRenderer.Rectangle.Width), -spriteRenderer.Rectangle.Height);
        }

        private void Collision(Collider other)
        {
            if (other.GameObject.Tag == "Laser")
            {
                other.GameObject.Destroy();
                Explode();
                Reset();
                GameManager.increaseScore();
            }
        }

        public override void Destroy()
        {
            collider.Destroy();
        }

        private void Explode()
        {
            GameObject explosion = new GameObject();
            explosion.AddComponent(new SpriteRenderer(3));
            explosion.AddComponent(new Animator());
            explosion.AddComponent(new Explosion(GameObject.Transform.Position));

            GameObject supplyCrate = new GameObject();
            supplyCrate.AddComponent(new SpriteRenderer());
            supplyCrate.AddComponent(new SupplyCrate(GameObject.Transform.Position));
            supplyCrate.AddComponent(new Collider());

            GameWorld.Instatiate(explosion);
            GameWorld.Instatiate(supplyCrate);
        }
    }
}
