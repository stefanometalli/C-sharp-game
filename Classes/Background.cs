using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm.Classes
{
    class Background : Component
    {
        protected SpriteRenderer spriteRenderer;
        private Vector2 startPosition;
        protected float speed;
        private Image sprite;
        private Transform sibling;

        public Background(string spriteName, Vector2 position, float speed, Transform sibling)
        {
            this.startPosition = position;
            this.speed = speed;
            this.sibling = sibling;
            sprite = Image.FromFile($@"Sprites/{spriteName}.png");
        }

        public override void Awake()
        {
            this.spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
            this.spriteRenderer.Sprite = sprite;
            this.GameObject.Transform.Position = startPosition;
        }

        public override void Update()
        {
            Move();
        }

        private void Move()
        {
            GameObject.Transform.Translate(new Vector2(0, 1) * speed * MyTime.DeltaTime);
            if (GameObject.Transform.Position.Y > GameWorld.WorldSize.Height)
            {
                Reset();
            }
        }

        public virtual void Reset()
        {
            GameObject.Transform.Position = new Vector2(0, sibling.Position.Y -spriteRenderer.Sprite.Height);
        }
    }
}
