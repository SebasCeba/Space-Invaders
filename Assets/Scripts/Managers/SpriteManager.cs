using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [SerializeField] private Sprite[] arrayofWeaponSprites;
    [SerializeField] private SpriteRenderer spriteRR; 

    public void ChangeWeaponSprite(int index)
    {
        spriteRR.sprite = arrayofWeaponSprites[index];
    }
}
