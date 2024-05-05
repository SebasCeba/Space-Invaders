using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    public ScoreManager scoreManager;

    public UIGamePlay UIGamePlay; 

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawningEnemy()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (10 == 10)
        {
            yield return new WaitForSeconds(3f); 
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform randomSpawnPoint = spawnPoints[randomIndex];

            Enemy randomEnemy = typesOfEnemies[Random.Range(0, typesOfEnemies.Length)];
            Enemy enemy = Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);
            enemy.SetUpEnemy(1);
            //This is for setting up the health of the enemy 
        }
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
    }

}
