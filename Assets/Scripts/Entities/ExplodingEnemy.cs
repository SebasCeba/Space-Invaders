using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ExplodingEnemy : Enemy
{
    public int Explodingdamage;

    public override void Attack()
    {
        base.Attack();
    }

    public new void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if(player != null)
            {
                player.PlayerhasTaken(Explodingdamage);
            }
                Destroy(this.gameObject);
        }
    }
}
