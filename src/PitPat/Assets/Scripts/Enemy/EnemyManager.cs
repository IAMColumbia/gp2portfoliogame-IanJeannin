using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyTypes;
    [Tooltip("How many beats before a new enemy spawns.")]
    [SerializeField]
    private int beatsBeforeSpawn = 10;

    private List<GameObject> enemies=new List<GameObject>();
    private float beatCounter = 0;
    private bool hasBeenPressed;

    private void Start()
    {
        SpawnEnemy();
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
        if(BeatSpawner.canBePressed==true&&hasBeenPressed==false)
        {
            beatCounter++;
            if(beatCounter>=beatsBeforeSpawn)
            {
                beatCounter = 0;
                SpawnEnemy();
            }
            hasBeenPressed = true;
        }
        else if(BeatSpawner.canBePressed==false&&hasBeenPressed==true)
        {
            hasBeenPressed = false;
        }
    }
}
