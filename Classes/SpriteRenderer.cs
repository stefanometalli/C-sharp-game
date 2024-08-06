using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm.Classes
{
    class SpriteRenderer : Component
    {
        private Graphics graphics;
        private Image sprite;

        public RectangleF Rectangle 
        { 
            get 
            {
                return new RectangleF(GameObject.Transform.Position.X, GameObject.Transform.Position.Y, sprite.Width * ScaleFactor, sprite.Height * ScaleFactor);
            } 
        }

        public float ScaleFactor { get; set; } = 1f;

        public SpriteRenderer()
        {
            graphics = GameWorld.Graphics;
        }

        public void SetSprite(string spriteName)
        {
            this.sprite = Image.FromFile($@"Sprites/{spriteName}.png");
        }

        public override void Update() 
        {
            graphics.DrawImage(sprite, Rectangle);
        }
        public override string ToString() 
        { 
            return "SpriteRenderer"; 
        }

    }
}
