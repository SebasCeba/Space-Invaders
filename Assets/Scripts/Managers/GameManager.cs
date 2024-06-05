using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public static GameManager singleton;
    public List<Enemy> eneimesSpawned = new List<Enemy>();
    public AudioManager audioManager; 
    public ScoreManager scoreManager;
    public UIGamePlay UIGamePlay;
    public Enemy enemies;

    [SerializeField]
    private float spawnRate = 1f; 
    [SerializeField]
    private Enemy[] typesOfEnemies;
    [SerializeField]
    private Transform[] spawnPoints;

    Coroutine coroutine; 

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       StartSpawningEnemy();

        if(audioManager == null)
        {
            audioManager = gameObject.AddComponent<AudioManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawningEnemy()
    {
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        //previously 10 == 10 
        while (10 == 10)
        {
            yield return wait; 
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform randomSpawnPoint = spawnPoints[randomIndex];

            Enemy randomEnemy = typesOfEnemies[Random.Range(0, typesOfEnemies.Length)];
            enemies = Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);
            //This will add enemies to a list. 
            eneimesSpawned.Add(enemies);


            //This is for setting up the health of the enemy 
            //enemies.SetUpEnemy(5);     
        }
    }

    public void EnemyKilled(Enemy killed)
    {
        //Removing frome a list  
        eneimesSpawned.Remove(killed);
    }


    public void StopSpawning()
    {
        StopAllCoroutines();
        scoreManager.RegisterHighScore(); 
    }

    public void EndGame()
    {
        scoreManager.RegisterHighScore();
        StopSpawning();
        UIGamePlay.ShowDeathScreen(); 
        audioManager.PlayGameOverMusic();
    }
    public void RestartGame()
    {
        audioManager.ResetAudio();
        SceneManager.LoadSceneAsync(0); 
    }
}
