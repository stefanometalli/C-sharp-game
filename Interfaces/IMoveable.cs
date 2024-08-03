interface IMoveable
{
    float Speed { get; set; }

    void Move();

    void Sprint(float extraSpeed);
}
