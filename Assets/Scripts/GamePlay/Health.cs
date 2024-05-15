using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events; 

public class Health 
{
    private int currentHealth;
    public UnityEvent<int> OneHealthChanged; 

    public void PlayerReceiveDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Am I dying?");
        OneHealthChanged.Invoke(currentHealth);

    }

    public void EnemyReceiveDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("This should be called");
        OneHealthChanged.Invoke(currentHealth);
    }

    //public void RecieveDamage(int explosive)
    //{
    //    currentHealth -= 10;

    //    OneHealthChanged.Invoke(currentHealth);
    //}


    public void IncreaseLife()
    {

    }


    public Health(int maxHealth)
    {
        currentHealth = maxHealth; 
        OneHealthChanged = new UnityEvent<int>();
    }
}
