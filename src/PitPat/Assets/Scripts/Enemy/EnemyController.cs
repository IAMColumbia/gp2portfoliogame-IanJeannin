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

    [SerializeField]
    private float minSuccessChance=30;
    [SerializeField]
    private float maxSuccessChance = 100;
    private float failureChance=30;

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
            float successChance = Random.Range(0, 100);
            float successMarker = maxSuccessChance - failureChance;
            if(successMarker<minSuccessChance)
            {
                successMarker = minSuccessChance;
            }
            // If the random is within the success range
            if (successChance<= successMarker)
            {
                if (IsAdjacentToPlayer() == false)
                {
                    SetMovementVector();
                }
            }
            hasMovedThisBeat = true;
        }
        else if(BeatTrigger.canBePressed==false&&hasMovedThisBeat==true)
        {
            hasMovedThisBeat = false;
        }
    }

    private bool IsAdjacentToPlayer()
    {
        float xDistance = player.transform.position.x - this.gameObject.transform.position.x;
        float yDistance = player.transform.position.y - this.gameObject.transform.position.y;
        //Check if enemy is adjacent to player
        if(xDistance<=1 && xDistance>=-1 && yDistance<=1 && yDistance>=-1&&(Mathf.Abs(xDistance)> Mathf.Abs(yDistance) || Mathf.Abs(yDistance) > Mathf.Abs(xDistance)))
        {
            Debug.Log("X Distance: "+xDistance);
            Debug.Log("Y Distance: " + yDistance);
            return true;
        }
        else
        {
            return false;
        }
    }
}
