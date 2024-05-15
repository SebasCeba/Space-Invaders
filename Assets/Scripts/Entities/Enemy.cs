using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float attackdistance; 
    private Player target;

    [SerializeField] public float time;

    //This will be the amount of damage it does to the player 
    public int damage;

    public void SetUpEnemy(int healthParam)
    {
        healthPoints = new Health(healthParam);
        target = FindObjectOfType<Player>();
        healthPoints.OneHealthChanged.AddListener(ChangedHealth);
    }

    private void ChangedHealth(int health)
    {
        Debug.Log("Enemy life has changed " + health);

        if (health <= 0)
        {
            Debug.Log("I'm dying");
            Die(); 
        }
    }

    public void FixedUpdate()
    {
        if(target != null)
        {
            Vector2 direction = target.transform.position - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Move(direction, angle);
        }
    }

    public override void Move(Vector2 direction, float angle)
    {
        //If distance from target is lesser than attackdistance
        if (Vector2.Distance(target.transform.position, transform.position) > attackdistance)
        {
            base.Move(direction, angle);
        }
        else //everytime the enemy is close to the player 
        {
            time = time + Time.deltaTime; 

            if (time >= 0.5f)
            {
                target.PlayerReceiveDamage(damage);
                time = 0f;
                Debug.Log("I'm hitting the player"); 
            } 
            rigidbody.velocity = Vector2.zero;
        }
    }

    public override void Attack()
    {
        target.PlayerReceiveDamage(damage);
    }

    public override void Die()
    {
        //Increse score 
        GameManager.singleton.scoreManager.IncreaseScore();
        Destroy(gameObject); //Dies 
    }
}
