using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp
{
    [SerializeField]
    private Weapon newWeapon;
    [SerializeField]
    private float weaponChangeDuration;

    //[SerializeField]
    //private GameObject SpriteRanderer = null;

    private void Start()
    {
        Destroy(gameObject, 10f); 
    }
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
        //This stores the old weapon 
        Weapon oldWeapon = player.GetCurrentWeapon();
        //Soft Disable 
        //SpriteRanderer.SetActive(false);
        //Active 
        ActivateWeaponChange(player); 
        yield return new WaitForSeconds(weaponChangeDuration);
        //Deactivate 
        DeactivateWeaponChange(player, oldWeapon);


        Destroy(gameObject);
    }

    private void ActivateWeaponChange(Player player)
    {
        player.SetWeapon(newWeapon);
    }

    private void DeactivateWeaponChange(Player player, Weapon oldWeapon)
    {
        player.SetWeapon(oldWeapon);
    }
}
