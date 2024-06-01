using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will be the background music
/// It will play tracks: 2 - 4, 6, 8    
/// </summary>
public class AudioManager : MonoBehaviour
{
    [Header("----Audio Source----")]
    [SerializeField] AudioSource musicSource;

    [Header("----Audio Clips----")]
    public AudioClip[] Tracks;

    private int currentTrackIndex = 0;

    private void Start()
    {
        PlayTrack(currentTrackIndex);
    }

    private void PlayTrack(int trackIndex)
    {
        if(Tracks.Length == 0)
        {
            return;
        }

        musicSource.clip = Tracks[currentTrackIndex];
        musicSource.Play();

        StartCoroutine(WaitForTrackEnd()); 
    }

    private IEnumerator WaitForTrackEnd()
    {
        yield return new WaitForSeconds(musicSource.clip.length);
        currentTrackIndex = (currentTrackIndex + 1) % Tracks.Length; 
        PlayTrack(currentTrackIndex);

    }
}
