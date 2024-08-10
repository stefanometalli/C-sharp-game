using WindowsForm.Classes;
using System.Numerics;

public static class GameManager
{

    public static List<GameObject> UIElements = new List<GameObject>();

    public static int LifeCount { get; set; }

    public static float xOffset;

    private static GameObject currentLife;

    public static void AddLife()
    {
        currentLife = new GameObject();
        SpriteRenderer sr = new SpriteRenderer();
        sr.ScaleFactor = 0.5f;
        sr.SetSprite("player");
        currentLife.AddComponent(sr);
        UIElements.Add(currentLife);
        currentLife.Transform.Translate(new Vector2(sr.Sprite.Width * sr.ScaleFactor * LifeCount + xOffset, 10));

        xOffset += 5;

        LifeCount++;
    }

    public static void RemoveLife()
    {
        if (LifeCount > 0)
        {
            UIElements[UIElements.Count - 1].Destroy();
            currentLife = UIElements[LifeCount - 1];
            UIElements.RemoveAt(LifeCount - 1);
            LifeCount--;
        }
        else
        {
            //GameOver
        }
    }
}
