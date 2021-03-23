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

    public void Attack()
    {

    }

    public bool Move(Vector2 direction)
    {
        if(CanMove(direction))
        {
            transform.position += (Vector3)direction;
            return true;
        }
        else
        {
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
}
