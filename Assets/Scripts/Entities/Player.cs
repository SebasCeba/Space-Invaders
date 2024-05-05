using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Character, IDamageable 
{
    [SerializeField] 
    private Transform aim;
    [SerializeField] 
    private Weapon playerWeapon;

    [SerializeField]
    public TextMeshProUGUI _healthText;

    //To activate the deathscreen 
    public static Player instance;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        // playerWeapon = new Weapon(bulletPrefab);

        _healthText.text = "Health: 50"; 
        healthPoints = new Health(50);

        healthPoints.OneHealthChanged.AddListener(ChangedHealth); 
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangedHealth(int health)
    {
        Debug.Log("Player has been damaged " + health);

        _healthText.text = "Health: " + health.ToString();

        if (health <= 0)
        {
            Die(); 
        }
    }

    public override void SetWeapon(Weapon newWeapon)
    {
        base.SetWeapon(newWeapon);
        playerWeapon = newWeapon;
    }

    public override void Attack()
    {
        playerWeapon.ShootMe(aim.position, aim.rotation, "Enemy");

    }
    public override void Die()
    {
        GameManager.singleton.EndGame(); 
        Destroy(gameObject);
    }

    public override void Move(Vector2 direction, float angle)
    {
        base.Move(direction, angle);
    }

}
