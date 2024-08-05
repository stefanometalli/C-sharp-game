class Player : GameObject, IMoveable
{
    private int health;
    public int strength;
    protected int mana;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public float Speed
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public Player(Graphics graphics, Image sprite, Point point, int health) : base(graphics, sprite, point)
    {
        this.health = health;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    private bool isAlive()
    {
        return health > 0;
    }

    /*public override void update()
    {
        throw new NotImplementedException();
    }
    */
    public void Move()
    {
        throw new NotImplementedException();
    }

    public void Sprint(float extraSpeed)
    {
        throw new NotImplementedException();
    }
}
