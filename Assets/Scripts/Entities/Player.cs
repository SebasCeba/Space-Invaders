using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class Player : Character, IDamageable 
{
    [SerializeField] 
    private Transform aim;
    [SerializeField] 
    private Weapon playerWeapon;

    [Header("Health")]
    [SerializeField]
    public TextMeshProUGUI _healthText;

    public float timer;
    private bool isRegenerating;
    private bool isCoroutineRunning; 

    //To activate the deathscreen 
    public static Player instance;
    private float fireRate;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        healthPoints = new Health(100);

        healthPoints.OneHealthChanged.AddListener(ChangedHealth); 
    }
    private void Update()
    {
        if (timer < 3.5)
        {
            timer += Time.deltaTime; 
        }
        else
        {
            isRegenerating = true;
            if(!isCoroutineRunning)
            {
                StartCoroutine(HealthRegen());
                timer = 0;
            }
        }
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
        //Debug.Log("Player has been damaged " + health);
        timer = 0; 
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
        //Player input decides when the bullet is shoot 
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            IDamageable damageable = GetComponent<IDamageable>();
            damageable.PlayerhasTaken(collision.gameObject.GetComponent<Bullet>().GetDamage());
            ChangedHealth(healthPoints.GetPlayerHP());
        }
    }

    private IEnumerator HealthRegen()
    {
        isCoroutineRunning = true;
        while(100 > healthPoints.GetPlayerHP() && isRegenerating)
        {
            //We can change how quick we health here 
            yield return new WaitForSeconds(1);
            //The number value increases the amount of health we receive 
            healthPoints.SetCurrentHP(healthPoints.GetPlayerHP() + 1);
            _healthText.text = "Health: " + healthPoints.GetPlayerHP().ToString();
        }
        isRegenerating = false; 
        isCoroutineRunning = false;
        Debug.Log("Getting Better"); 
    }
}
