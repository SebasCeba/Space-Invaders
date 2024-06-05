using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        { 
            PickMe(collision.gameObject.GetComponent<Character>()); 
        }
    }

    protected virtual void PickMe(Character characterToChange)
    {
        Destroy(gameObject);
    }
}
