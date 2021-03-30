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
    [SerializeField]
    private GameObject attackMarker;
    [Tooltip("The empty game object that will hold the instantiated attack markers")]
    [SerializeField]
    private GameObject markerHolder;

    //Player starts the game looking down
    private Vector3 lastDirection=new Vector3(0,-1,0);

    private UnitAttack unitAttack;
    private UnitProfile unitProfile;

    private void Start()
    {
        unitAttack=this.gameObject.AddComponent<UnitAttack>();
        unitAttack.Initialize(this.gameObject,markerHolder);
        unitProfile = this.gameObject.AddComponent<UnitProfile>();
        unitProfile.Initialize(10);
    }
    
    private void Update()
    {
        if(BeatTrigger.beatEntered)
        {
            BeatTrigger.beatEntered = false;
            unitAttack.RemoveMarkers();
        }
    }
    
    /// <summary>
    /// Recieves an attack grid. 
    /// NOTE: AttackGrid must be [7,7]
    /// </summary>
    /// <param name="attackGrid"></param>
    public void Attack(bool[,] attackGrid,int damage)
    {
        if(BeatTrigger.canBePressed==true)
        {
            unitAttack.Attack(attackGrid, lastDirection, attackMarker,damage);
        }
    }

    public bool Move(Vector2 direction)
    {
        if(BeatTrigger.canBePressed&&CanMove(direction))
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
        LayerMask mask = LayerMask.GetMask("Enemies");
        Vector2 worldDesination=((Vector2)transform.position+direction);
        Vector3Int gridDestination = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridDestination)||collisionTilemap.HasTile(gridDestination)|| Physics2D.OverlapCircle(worldDesination, 0.05f,mask))
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
            this.gameObject.GetComponent<Animator>().SetFloat("xDir", lastDirection.x);
            this.gameObject.GetComponent<Animator>().SetFloat("yDir", lastDirection.y);
            return true;
        }
        else
        {
            return false;
        }
    }
}
