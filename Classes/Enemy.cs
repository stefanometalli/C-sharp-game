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

        public override void Awake()
        {
            speed = 100;
            spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
            spriteRenderer.SetSprite("enemy_01");
            spriteRenderer.ScaleFactor = 0.7f;
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
    }
}
