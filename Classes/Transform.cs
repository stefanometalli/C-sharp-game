
using System.Numerics;

public class Transform
{
    private Vector2 position;

    public Transform()
    {
        Position = new Vector2();
    }

    public Vector2 Position { get { return position; } set { position = value; } }

}