using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyTypes;
    [Tooltip("How many beats before a new enemy spawns.")]
    [SerializeField]
    private int startingBeatsBeforeSpawn = 10;

    private static List<GameObject> enemies=new List<GameObject>();
    private float beatCounter = 0;
    private bool hasBeenPressed;
    public static int enemiesKilled = 0;
    public static int highScore = 0;

    private static int beatsBeforeSpawn;
    private static int defaultBeatsBeforeSpawn; //Convert the serialized into a static

    private void Start()
    {
        SpawnEnemy();
        beatsBeforeSpawn=startingBeatsBeforeSpawn;
        defaultBeatsBeforeSpawn = startingBeatsBeforeSpawn;
    }

    public void SpawnEnemy()
    {
        Vector3 SpawnLocation = Pathfinding.GetRandomTilePosition();
        //If there are no open tiles, GetRandomTilePosition() will return 0,0, which is not a grid slot
        if(SpawnLocation!=new Vector3(0,0))
        {
            enemies.Add(Instantiate(enemyTypes[0], Pathfinding.GetRandomTilePosition(), Quaternion.identity, this.transform));
        }
    }

    private void Update()
    {
        if (GameState.stateOfGame == GameState.StateOfGame.Play)
        {
            if (BeatSpawner.canBePressed == true && hasBeenPressed == false)
            {
                beatCounter++;
                if (beatCounter >= beatsBeforeSpawn)
                {
                    beatCounter = 0;
                    SpawnEnemy();
                }
                hasBeenPressed = true;
            }
            else if (BeatSpawner.canBePressed == false && hasBeenPressed == true)
            {
                hasBeenPressed = false;
            }
        }    
    }

    public static void ClearEnemies()
    {
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemiesKilled = 0;
        beatsBeforeSpawn = defaultBeatsBeforeSpawn;
    }

    public static void KillEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        enemiesKilled++;
        if(enemiesKilled>=highScore)
        {
            highScore = enemiesKilled;
        }
        Destroy(enemy);
        if(enemiesKilled/4==1&&beatsBeforeSpawn>4)
        {
            beatsBeforeSpawn--;
        }

    }
}
