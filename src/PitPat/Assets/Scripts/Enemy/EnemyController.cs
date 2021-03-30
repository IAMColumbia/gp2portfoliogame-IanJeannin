using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private UnitAttack unitAttack;
    private UnitProfile unitProfile;
    [SerializeField]
    private GameObject markerHolder;
    [SerializeField]
    private Pathfinding pathfinding;
    [SerializeField]
    private GameObject player;

    private void Start()
    {
        if(markerHolder==null)
        {
            markerHolder = Instantiate(new GameObject("Marker Holder"));
        }
        if(player==null)
        {
            player = GameObject.Find("Player");
        }
        unitAttack = this.gameObject.AddComponent<UnitAttack>();
        unitAttack.Initialize(this.gameObject, markerHolder);
        unitProfile = this.gameObject.AddComponent<UnitProfile>();
        unitProfile.Initialize(3);
    }

    void SetMovementVector()
    {
        Vector2 nextMove = pathfinding.FindPath(this.transform.position,player.transform.position);
        this.transform.position += (Vector3)nextMove;
        Debug.Log("Enemy moves: " + nextMove);
    }

    bool hasMovedThisBeat = false;
    private void Update()
    {
        if(BeatTrigger.canBePressed==true&&hasMovedThisBeat==false)
        {
            hasMovedThisBeat = true;
            SetMovementVector();
        }
        else if(BeatTrigger.canBePressed==false&&hasMovedThisBeat==true)
        {
            hasMovedThisBeat = false;
        }
    }
}
