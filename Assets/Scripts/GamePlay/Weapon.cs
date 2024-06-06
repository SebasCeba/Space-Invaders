using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon" , menuName = " Create Weapon")]
public class Weapon : ScriptableObject
{
    [Header("---Weapon---")]
    [SerializeField]
    private string weaponName;
    [SerializeField]
    private Sprite icon;
    public Sprite weaponSprite; 

    [Header("---Bullet---")]
    [SerializeField]
    private Bullet bulletReference;
    [SerializeField]
    private int damage;

    public void ShootMe(Vector2 position, Quaternion direction, string tag)
    {    
        Bullet temmBullet = Object.Instantiate(bulletReference, position, direction);
        temmBullet.SetUpBullet(tag, damage); 
    }

    public void EnemyShoot(Vector2 position , Quaternion direction, string tag)
    {
        Bullet EnemytemmBullet = Object.Instantiate(bulletReference, position, direction);
        EnemytemmBullet.SetUpBullet(tag, damage); 
    }

    public Weapon()
    {

    }

    public Weapon(Bullet bulletPrefab)
    {
        bulletReference = bulletPrefab; 
    }
}
