using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] private Weapon enemyWeapon;
    [SerializeField] protected float stopDistance;
    [SerializeField] private Transform BulletSpawn; 
    

    private float timer;

    private void Update()
    {
        Attack(); 
    }

    public override void Attack()
    {
        timer += Time.deltaTime; 
        if (timer > 2f)
        {
            enemyWeapon.EnemyShoot(BulletSpawn.position, transform.rotation, "Player");
            timer = 0; 
        }
    }

    public override void Move(Vector2 direction, float angle)
    {
        if(Vector2.Distance(target.transform.position, transform.position) > stopDistance)
        {
            rigidbody.AddForce(direction.normalized * speed * Time.deltaTime * 1000f); 
        }

        transform.rotation = Quaternion.Euler(0, 0 , angle -90);
    }
}
