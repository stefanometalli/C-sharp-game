using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm.Classes
{
    class Laser : Component
    {
        private SpriteRenderer spriteRenderer;
        private float speed;
        private string laserSprite;
        private Vector2 direction;
        private Vector2 startPosition;

        public Laser(string laserSprite, Vector2 direction, Vector2 startPosition)
        {
            this.laserSprite = laserSprite;
            this.direction = direction;
            this.startPosition = startPosition;
        }

        public override void Awake()
        {
            speed = 300;
            GameObject.Transform.Position = startPosition;
            spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
            spriteRenderer.SetSprite(laserSprite);
            spriteRenderer.ScaleFactor = 0.7f;
        }

        public override void Update()
        {
            Move();  
            if(spriteRenderer.OnBecameInvisible())
            {
                GameWorld.Destroy(GameObject);
            }
        }

        public void Move()
        {
            GameObject.Transform.Translate(direction * speed * MyTime.DeltaTime);
        }


    }
}
