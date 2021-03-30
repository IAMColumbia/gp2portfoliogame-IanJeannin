using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Player starts the game looking down
    private Vector3 lastDirection = new Vector3(0, -1, 0);
    private Tilemap groundTilemap;
    private Tilemap collisionTilemap;

    public void Initialize(Tilemap ground,Tilemap collision)
    {
        groundTilemap = ground;
        collisionTilemap = collision;
    }
    public bool Move(Vector2 direction)
    {
        if (CanMove(direction))
        {
            transform.position += (Vector3)direction;
            Rotate(direction);
            return true;
        }
        else
        {
            Rotate(direction);
            return false;
        }
    }

    private bool CanMove(Vector2 direction)
    {
        LayerMask mask = LayerMask.GetMask("Enemies","Player");
        Vector2 worldDesination = ((Vector2)transform.position + direction);
        Vector3Int gridDestination = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridDestination) || collisionTilemap.HasTile(gridDestination) || Physics2D.OverlapCircle(worldDesination, 0.05f, mask))
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
            lastDirection = direction;
            this.gameObject.GetComponent<Animator>().SetFloat("xDir", lastDirection.x);
            this.gameObject.GetComponent<Animator>().SetFloat("yDir", lastDirection.y);
            return true;
    }
}
