using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;

    public bool gameOver;
    public float scrollSpeed = 3.5f;


    [Header("ObstacleSpawner")]
    public GameObject[] obstacles;
    public float spawnFrequency; //# per minute
    private float spawnTime;
    private float elapsedTime = 0;
    private SpawnPoint[] spawnPoints;


    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null) Instance = this;

        spawnPoints = FindObjectsOfType<SpawnPoint>();

        spawnTime = 1 / spawnFrequency * 60;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObstacles();
    }

    void SpawnObstacles()
    {
        //we have different types of obstacles and obstacles should have timers 
        //after spawning in a lane can't spawn for a bit
        if (elapsedTime > spawnTime)
        {
            elapsedTime = 0;

            //int index = Random.Range(0, spawnPoints.Length);
            
            //find an unoccupied lane
           for(int i = 0; i < spawnPoints.Length; i++)
           {
                if (!spawnPoints[i].occupied)
                {
                    int obstacleIndex = Random.Range(0, obstacles.Length);

                    GameObject obs = Instantiate(obstacles[obstacleIndex], spawnPoints[i].transform.position, Quaternion.identity);
                    obs.GetComponent<Obstacle>().lane = spawnPoints[i];
                    spawnPoints[i].occupied = true;
                    break;
                }
           }
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }
    }
}
