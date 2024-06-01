using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    public AudioClip nukeSfx; 
    //This shall be the radius of the explosion 
    public float explosionRadius = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        //Plays the NukeSFx 
        if(nukeSfx != null)
        {
            PlaySound(nukeSfx);
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        
        foreach (Collider2D nearbyObject in colliders)
        {
            if(nearbyObject.CompareTag("Enemy"))
            {
                GameManager.singleton.scoreManager.IncreaseScore(); 
                Destroy(nearbyObject.gameObject); 
            }
        }
        Destroy(gameObject); 
    }

    private void PlaySound(AudioClip clip)
    {
        GameObject soundObject = new GameObject("ExplosionSound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clip; 
        audioSource.Play();

        Destroy(soundObject, clip.length); 

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, explosionRadius); 
    }
}
