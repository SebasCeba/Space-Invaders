using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{ 

    //This is only for physical contact 
    public void PlayerReceiveDamage(int damage);

    //Enemy receives damage from the bullet of the player 
    public void EnemyReceiveDamage(int damage);

    //This will be for the Enemy bullet that deals damage to the player 
    //Or not 
    //public void EnemyBulletDamage(); 
}
