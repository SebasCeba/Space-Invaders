using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ExplodingEnemy : Enemy
{
    [SerializeField] private Weapon enemyWeapon;
    public override void Attack()
    {
        enemyWeapon.EnemyShoot(transform.position, transform.rotation, "Player");
    }

    //public override void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        target.ReceiveDamage(damage);
    //    }
    //}
}
