using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm.Classes
{
    public delegate void CollisionEventHandler(Collider other);
    public class Collider : Component
    {

        private SpriteRenderer spriteRenderer;
        public event CollisionEventHandler CollisionHandler;
        private static List<Collider> colliders = new List<Collider>();

        public override void Awake()
        {
            spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
            colliders.Add(this);
        }

        public override void Update()
        {
            for (int i = 0; i < colliders.Count; i++) 
            {
                OnCollision(colliders[i]);
            }
        }

        public void OnCollision(Collider other)
        {
            if (other != this)
            {
                RectangleF intersection = RectangleF.Intersect(spriteRenderer.Rectangle, other.spriteRenderer.Rectangle);

                if ((intersection.Width > 0 || intersection.Height > 0) && CollisionHandler != null)
                {
                    CollisionHandler.Invoke(other);
                }
            }
        }

        public override string ToString()
        {
            return "Collider";
        }

        public override void Destroy()
        {
            colliders.Remove(this);
        }

    }
}
