using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events; 

public class Health 
{
    [Header("Player's Health")]
    private int PlayerHealth;
    //This was added
    public int maxHealth = 100;

    [Header("Enemy Health")]
    private int EnemyHP; 

    public UnityEvent<int> OneHealthChanged; 

    public void PlayerReceiveDamage(int damage)
    {
        PlayerHealth -= damage;
        OneHealthChanged.Invoke(PlayerHealth);
    }

    public void EnemyReceiveDamage(int damage)
    {
        EnemyHP -= damage;
        Debug.Log("EnemyHP: " + EnemyHP);
    }

    public int GetCurrentHP()
    {
        return EnemyHP; 
    }

    public void SetCurrentHP(int health)
    {
        PlayerHealth = health; 
    }

    public int GetPlayerHP()
    {
        return PlayerHealth;
    }

    public Health(int maxHealth)
    {
        OneHealthChanged = new UnityEvent<int>();
        EnemyHP = maxHealth;
        PlayerHealth = maxHealth;
    }
}
