using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float attackdistance; 
    private Player target;

    [SerializeField] public float time; 

    public void SetUpEnemy(int healthParam)
    {
        healthPoints = new Health(healthParam);
        target = FindObjectOfType<Player>();
        healthPoints.OneHealthChanged.AddListener(ChangedHealth);
    }

    public void ChangedHealth(int health)
    {
        Debug.Log("Enemy life has changed " + health);

        if (health <= 0)
        {
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
        //Ifi distance from target is lesser than attackdistance
        if (Vector2.Distance(target.transform.position, transform.position) > attackdistance)
        {
            base.Move(direction, angle);
        }
        else //everytime the enemy is close to the player 
        {
            time = time + Time.deltaTime; 

            if (time >= 0.5f)
            {
                target.ReceiveDamage();
                time = 0f; 
            } 

            rigidbody.velocity = Vector2.zero;
        }
    }

    public override void Attack()
    {
        target.ReceiveDamage();
    }

    public override void Die()
    {
        //Increse score 
        GameManager.singleton.scoreManager.IncreaseScore();
        Destroy(gameObject); //Dies 
    }
}
