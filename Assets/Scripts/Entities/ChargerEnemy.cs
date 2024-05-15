using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerEnemy : Enemy
{
    [SerializeField]private Weapon enemyWeapon; 
    public override void Attack()
    {
        enemyWeapon.EnemyShoot(transform.position, transform.rotation, "Player");
    }
}
