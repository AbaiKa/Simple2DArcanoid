using UnityEngine;

public class SimpleEnemy : AEnemy
{
    protected override void Update()
    {
        Movement();
    }
    protected override void Movement()
    {
        transform.position += (Vector3)(Vector2.down * speed * Time.deltaTime);
    }
    protected override void Release()
    {
        Destroy(gameObject);
    }
}