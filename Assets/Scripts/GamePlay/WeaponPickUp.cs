using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class WeaponPickUp : PickUp
{
    [SerializeField]
    private Weapon newWeapon;
    [SerializeField]
    private float weaponChangeDuration;

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
        //This stores the old weapon and set it to the old sprite 
        Weapon oldWeapon = player.GetCurrentWeapon();
        //Active and changes the sprite to the new weapon
        ActivateWeaponChange(player);

        yield return new WaitForSeconds(weaponChangeDuration);
        //Deactivate 
        DeactivateWeaponChange(player, oldWeapon);
        Destroy(gameObject);
    }

    private void ActivateWeaponChange(Player player)
    {
        player.SetWeapon(newWeapon);
        player.GetComponent<SpriteManager>().ChangeWeaponSprite(newWeapon.GetWeaponIndex()); 
    }

    private void DeactivateWeaponChange(Player player, Weapon oldWeapon)
    {
        player.SetWeapon(oldWeapon);
        player.GetComponent<SpriteManager>().ChangeWeaponSprite(oldWeapon.GetWeaponIndex());
    }
}
