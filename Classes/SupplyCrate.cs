using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm.Classes
{
    class SupplyCrate : Component
    {

        private Vector2 spawnPosition;
        private Collider collider;

        public SupplyCrate(Vector2 position)
        {
            spawnPosition = position;
        }

        public override void Awake()
        {
            SpriteRenderer spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");

            spriteRenderer.SortOrder = 0;
            spriteRenderer.ScaleFactor = 0.5f;
            spriteRenderer.SetSprite("supply-crate");
            collider = (Collider)GameObject.GetComponent("Collider");
            collider.CollisionHandler += Collision;
            GameObject.Tag = "SupplyCrate";
            GameObject.Transform.Position = spawnPosition;
            GameObject.Transform.Position += new Vector2(20, 15);
        }

        private void Collision(Collider other)
        {
            if (other.GameObject.Tag == "Player")
            {
                GameManager.RemoveLife();
                GameObject.Destroy();
            }
        }
    }
}
