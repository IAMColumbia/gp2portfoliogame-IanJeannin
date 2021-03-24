using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap collisionTilemap;

    private Vector3 lastDirection;

    /// <summary>
    /// Recieves an attack grid. 
    /// NOTE: AttackGrid must be [7,7]
    /// </summary>
    /// <param name="attackGrid"></param>
    public void Attack(bool[,] attackGrid)
    {
        Vector3 targetedSpace = transform.position;
        //Simulates rotation of the grid according to player direction
        bool xPositiveTowardsPlayer = false;
        bool yPositiveTowardsPlayer = false;
        if (lastDirection==new Vector3(0,1,0))
        {
            targetedSpace.x = targetedSpace.x - 3;
            targetedSpace.y = targetedSpace.y + 3;
            transform.position = (Vector3)targetedSpace;
        }
        else if(lastDirection==new Vector3(1,0,0))
        {
            targetedSpace.x = targetedSpace.x + 3;
            targetedSpace.y = targetedSpace.y + 3;
            transform.position = (Vector3)targetedSpace;
        }
        else if (lastDirection == new Vector3(0, -1, 0))
        {
            targetedSpace.x = targetedSpace.x + 3;
            targetedSpace.y = targetedSpace.y - 3;
            transform.position = (Vector3)targetedSpace;
        }
        else if (lastDirection == new Vector3(-1, 0, 0))
        {
            targetedSpace.x = targetedSpace.x - 3;
            targetedSpace.y = targetedSpace.y - 3;
            transform.position = (Vector3)targetedSpace;
        }
    }

    public bool Move(Vector2 direction)
    {
        if(BeatTrigger.canBePressed&&CanMove(direction))
        {
            transform.position += (Vector3)direction;
            lastDirection = direction;
            return true;
        }
        else
        {
            lastDirection = direction;
            return false;
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridDestination = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if(!groundTilemap.HasTile(gridDestination)||collisionTilemap.HasTile(gridDestination))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool Rotate(Vector2 direction)
    {
        if(BeatTrigger.canBePressed)
        { 
            lastDirection = direction;
            return true;
        }
        else
        {
            return false;
        }
    }
}
