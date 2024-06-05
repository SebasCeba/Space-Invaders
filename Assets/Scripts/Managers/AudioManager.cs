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

    [Header("----Audio BackgroundMusicClips----")]
    public AudioClip[] Tracks; //Tracks 2, 3, 4, 6, 8

    [Header("----Audio GameOverMusicClips----")]
    public AudioClip[] gameOverTracks; 

    private int currentTrackIndex = 0;
    private bool isGameOver = false; 

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

    public void PlayGameOverMusic()
    {
        StopAllCoroutines(); //To stop any tracks that would've been playing during the game 

        if(gameOverTracks.Length > 0)
        {
            int index = Random.Range(0, gameOverTracks.Length);
            musicSource.clip = gameOverTracks[index];
            musicSource.Play();
            isGameOver = true; 
        }
    }

    public void ResetAudio()
    {
        isGameOver = false;
        currentTrackIndex = 0;
        StopAllCoroutines();
        PlayTrack(currentTrackIndex);
    }
}
