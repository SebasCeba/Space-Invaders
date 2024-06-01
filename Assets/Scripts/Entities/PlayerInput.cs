using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("---Movement + Aim---")]
    private Player myPlayer;
    public Vector2 direction;
    public float angleToRotate;

    [Header("---Bullet's Stats---")]
    public float fireRate;
    private float fireTimer;


    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && fireTimer <= 0f)
        {
            myPlayer.Attack();
            fireTimer = fireRate; 
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical"); 

        direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,  -10));
       

        angleToRotate = Mathf.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg;

        //Sending the input as coodirnates 
        myPlayer.Move(new Vector2 (horizontalInput, verticalInput), angleToRotate);
    }
}
