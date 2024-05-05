using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon" , menuName = " Create Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField]
    private string weaponName;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int damage;
    [SerializeField]
    private Bullet bulletReference;


    public void ShootMe(Vector2 position, Quaternion direction, string tag)
    {
        Bullet temmBullet = Object.Instantiate(bulletReference, position, direction);
        temmBullet.SetUpBullet(tag, damage); 
    }

    public Weapon()
    {

    }

    public Weapon(Bullet bulletPrefab)
    {
        bulletReference = bulletPrefab; 
    }
}
