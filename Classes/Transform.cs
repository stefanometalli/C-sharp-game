
using System.Numerics;

public class Transform
{
    private Vector2 position;

    public Transform()
    {
        Position = new Vector2(0,0);
    }

    public Vector2 Position { get { return position; } set { position = value; } }

    public void Translate(Vector2 translation)
    {
        if (!float.IsNaN(translation.X) && !float.IsNaN(translation.Y))
        {
            Position += translation;
        }
    }

}