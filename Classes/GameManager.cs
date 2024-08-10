using WindowsForm.Classes;
using System.Numerics;

public static class GameManager
{

    public static List<GameObject> UIElements = new List<GameObject>();

    public static int LifeCount { get; set; }

    public static float xOffset;

    private static GameObject currentLife;

    private static Button restartButton;

    public static void Initialize(Button button)
    {
        restartButton = button;
        restartButton.Hide();
    }

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
        if (LifeCount > 1)
        {
            UIElements[UIElements.Count - 1].Destroy();
            currentLife = UIElements[LifeCount - 1];
            UIElements.RemoveAt(LifeCount - 1);
            LifeCount--;
        }
        else
        {
            UIElements[UIElements.Count - 1].Destroy();
            currentLife = UIElements[LifeCount - 1];
            UIElements.RemoveAt(LifeCount - 1);
            LifeCount--;
            GameOver();
        }

    }

    public static void GameOver()
    {
        GameObject gameOver = new GameObject();
        SpriteRenderer sr = new SpriteRenderer();
        sr.SetSprite("GameOver");
        gameOver.AddComponent(sr);
        UIElements.Add(gameOver);
        restartButton.Show();
    }
    public static void Reset() 
    {
        restartButton.Hide();
        for (int i = 0; i < UIElements.Count; i++)
        {
            UIElements[i].Destroy();
        }
        UIElements.Clear();
        LifeCount = 0;
        xOffset = 0;
    }

}
