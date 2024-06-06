using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp
{
    [SerializeField]
    private Weapon newWeapon;
    [SerializeField]
    private float weaponChangeDuration;

    [SerializeField]
    private GameObject spriteRendererObject = null;
    //private SpriteRenderer spriteRenderer; 

    private void Start()
    {
        Destroy(gameObject, 10f);
        //if (spriteRendererObject != null)
        //{
        //    spriteRenderer = spriteRendererObject.GetComponent<SpriteRenderer>();
        //}
        //else
        //{
        //    Debug.LogError("SpriteRendererObject is not assigned in the inspector."); 
        //}
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
        //Sprite oldSprite = spriteRenderer.sprite;

        //Soft Disable 
        spriteRendererObject.SetActive(false);

        //Active and changes the sprite to the new weapon
        ActivateWeaponChange(player);
        //if(newWeapon.weaponSprite != null)
        //{
        //    Debug.Log("Changing sprite to new weapon sprite."); 
        //    spriteRenderer.sprite = newWeapon.weaponSprite;
        //}
        //else
        //{
        //    Debug.LogError("New weapon sprite is null."); 
        //}
         

        yield return new WaitForSeconds(weaponChangeDuration);

        //Deactivate 
        DeactivateWeaponChange(player, oldWeapon);
        //spriteRenderer.sprite = oldSprite; 


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
