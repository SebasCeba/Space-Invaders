using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable 
{
    public float speed;
    private int strength;
    protected Health healthPoints;

    [SerializeField] protected new Rigidbody2D rigidbody;

    public int HPStart; 

    public abstract void Attack(); 

    public abstract void Die();

    private void Start()
    {
        healthPoints = new Health(HPStart);
    }
    public virtual void SetWeapon(Weapon newWeapon)
    {

    }

    public virtual void Move(Vector2 direction, float angleToRotate)
    {
        rigidbody.AddForce(direction.normalized * speed * Time.deltaTime * 500f);
        transform.rotation = Quaternion.Euler(0, 0, angleToRotate - 90); 
    }
    public void PlayerhasTaken(int damage)
    {
        //This will be for the enemy doing damage to the player 
        healthPoints.PlayerReceiveDamage(damage);
    }

    public void EnemyReceives(int damage)
    {
        //This player references the prefab of the bullet and the damage it does to the enemy 
        Debug.Log("The enemy has been hit");
        healthPoints.EnemyReceiveDamage(damage);
    }


    public Character() 
    {
        speed = 5f; 
    }


    public Character(float speed, int health)
    {
        this.speed = speed;
        healthPoints = new Health(health); 
    }
}
