using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable 
{
    public float speed;
    private int strength;
    protected Health healthPoints;

    [SerializeField] protected new Rigidbody2D rigidbody;

    public int StartingHealth; 


    public abstract void Attack(); 

    public abstract void Die();

    private void Start()
    {
        healthPoints = new Health(StartingHealth);
    }
    public virtual void SetWeapon(Weapon newWeapon)
    {

    }

    public virtual void Move(Vector2 direction, float angleToRotate)
    {
        rigidbody.AddForce(direction.normalized * speed * Time.deltaTime * 500f);
        transform.rotation = Quaternion.Euler(0, 0, angleToRotate - 90); 
    }

    public void ReceiveDamage()
    {
        if (healthPoints == null)
        {
            Debug.Log("Who are you gonna call...Ghostbusters");
        }
        healthPoints.RecieveDamage();
    }

    public void ReceiveDamage(int damage)
    {
        Debug.Log("Why aren't you working!");
        healthPoints.RecieveDamage(damage);
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
