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
        private bool isVisible;

        public int SortOrder { get; set; }

        public Image Sprite { 
            get { 
                return sprite; 
            }
            set
            {
                sprite = value;
            }
        }

        public RectangleF Rectangle 
        { 
            get 
            {
                return new RectangleF(GameObject.Transform.Position.X, GameObject.Transform.Position.Y, sprite.Width * ScaleFactor, sprite.Height * ScaleFactor);
            } 
        }

        private RectangleF[] rectangles = new RectangleF[1];

        public float ScaleFactor { get; set; } = 1f;

        public SpriteRenderer()
        {
            graphics = GameWorld.Graphics;
            this.SortOrder = 0;
        }

        public SpriteRenderer(int sortOrder)
        {
            graphics = GameWorld.Graphics;
            this.SortOrder = 0;
            this.SortOrder = sortOrder;
        }

        public void SetSprite(string spriteName)
        {
            this.sprite = Image.FromFile($@"Sprites/{spriteName}.png");
        }

        public override void Update() 
        {
            graphics.DrawImage(sprite, Rectangle);
            if (GameWorld.Debug)
            {
                graphics.DrawRectangle(new Pen(Color.Red, 0.5f), new Rectangle((int)Rectangle.X, (int)Rectangle.Y, (int)Rectangle.Width, (int)Rectangle.Height));
            }
        }

        /**
         * Distrugge oggetti che erano visibili e poi sono diventati non visibili 
         */
        public bool OnBecameInvisible()
        {
            if(isVisible)
            {
                if (GameObject.Transform.Position.Y < -Rectangle.Height) 
                {
                    isVisible = false;
                    return true;
                }

                if (GameObject.Transform.Position.Y > GameWorld.WorldSize.Height)
                {
                    isVisible = false;
                    return true;
                }

                if (GameObject.Transform.Position.X > GameWorld.WorldSize.Width)
                {
                    isVisible = false;
                    return true;
                }

                if (GameObject.Transform.Position.X < -Rectangle.Width)
                {
                    isVisible = false;
                    return true;
                }
            }
            isVisible = true;
            return false;
        }

        public override string ToString() 
        { 
            return "SpriteRenderer"; 
        }

    }
}
