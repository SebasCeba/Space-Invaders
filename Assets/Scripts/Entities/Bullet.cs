using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public float bulletSpeed;
    public float fireRate; 
    private int damage;
    private string targetTag; 

    private void Start()
    {
        Destroy(gameObject, 5f); 
    }

    public void SetUpBullet(string tag, int damageParam)
    {
        damage = damageParam;
        targetTag = tag;
    }

    public void Update()
    {
        //Just moving forward 
        transform.Translate(Vector2.up * bulletSpeed * fireRate * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(targetTag))
        {
            //Do damage to enemy 
            collision.GetComponent<IDamageable>().EnemyReceiveDamage(damage);
            Destroy(gameObject); 
        }

        if(collision.gameObject.CompareTag(targetTag))
        {
            //Do damage to the player 
            collision.GetComponent<IDamageable>().PlayerReceiveDamage(damage);
            Destroy(gameObject);
        }
    }
}
