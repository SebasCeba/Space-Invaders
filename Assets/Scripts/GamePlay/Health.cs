using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events; 

public class Health 
{
    public int currentHealth;
    public UnityEvent<int> OneHealthChanged; 

    public void RecieveDamage()
    {
        currentHealth -= 1;

        OneHealthChanged.Invoke(currentHealth);

    }

    public void RecieveDamage(int damage)
    {
        currentHealth -= damage;

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
