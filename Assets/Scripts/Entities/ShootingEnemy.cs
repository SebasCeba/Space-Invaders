using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] private Weapon enemyWeapon;
    [SerializeField] private Transform aim; 

    public override void Attack()
    {
        enemyWeapon.ShootMe(transform.position, transform.rotation, "Player");
    }


    IEnumerable SpawnBullet()
    {
        while (10 == 10)
        {
            yield return new WaitForSeconds(4f); 

        }
    }
}
