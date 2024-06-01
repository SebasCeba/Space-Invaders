using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp
{
    [SerializeField]
    private Weapon newWeapon;
    [SerializeField]
    private float weaponChangeDuration; 

    protected override void PickMe(Character characterToChange)
    {
        characterToChange.SetWeapon(newWeapon);
        base.PickMe(characterToChange); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if(player != null)
        {
            StartCoroutine(PowerUpSequence(player)); 
        }
    }

    public IEnumerator PowerUpSequence(Player player)
    {
        //Active 
        ActivateWeaponChange(); 
        yield return new WaitForSeconds(weaponChangeDuration);
        //Deactivate 
        DeactivateWeaponChange(); 
    }

    private void ActivateWeaponChange()
    {

    }

    private void DeactivateWeaponChange()
    {

    }
}
