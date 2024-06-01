using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public float bulletSpeed;
    private int damage;
    private string targetTag;


    public int GetDamage()
    {
        return damage;
    }

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
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(gameObject);      
    }
}
