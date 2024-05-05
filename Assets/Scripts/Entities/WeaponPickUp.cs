using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp
{
    [SerializeField]
    private Weapon newWeapon; 

    protected override void PickMe(Character characterToChange)
    {
        characterToChange.SetWeapon(newWeapon);
        base.PickMe(characterToChange); 
    }
}
