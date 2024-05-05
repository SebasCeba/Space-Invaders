using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{
    [SerializeField]
    private Weapon enemyWeapon;

    public override void Attack()
    {
        Debug.Log("This enemy is exploding");

        enemyWeapon.ShootMe(transform.position, transform.rotation, "Player");
    }
}
