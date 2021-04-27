using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject markerHolder;
    [SerializeField]
    private Pathfinding pathfinding;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject attackMarker;
    [SerializeField]
    private int maxHealth;

    //Player starts the game looking down
    private Vector3 lastDirection = new Vector3(0, -1, 0);

    [Tooltip("The percentage that failure chance is increased for each beat the player misses. Maximum of 10 for 100%. Minimum of 0.")]
    [SerializeField]
    [Range(0,10)]
    private float missedBeatWeight=7.5f;
    [SerializeField]
    private float maxSuccessChance = 100;
    private float failureChance=30;

    private UnitAttack unitAttack;
    private UnitProfile unitProfile;
    private AttackManager attackManager;
    private Movement movement;

    private void Start()
    {
        if(this.gameObject.GetComponent<AttackManager>()==true)
        {
            attackManager = this.gameObject.GetComponent<AttackManager>();
        }
        else
        {
            attackManager = new AttackManager();
        }
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
        unitProfile.Initialize(maxHealth);
        movement = this.gameObject.AddComponent<Movement>(); //Enemy doesn't need to initialize
    }

    void SetMovementVector()
    {
        Vector2 nextMove = pathfinding.FindPath(this.transform.position,player.transform.position);
        Rotate(nextMove);
        this.transform.position += (Vector3)nextMove;
    }

    bool hasMovedThisBeat = false;

    private void Update()
    {
        if(GameState.stateOfGame==GameState.StateOfGame.Play)
        {
            if (BeatSpawner.aiCanMove == true && hasMovedThisBeat == false)
            {
                hasMovedThisBeat = true;
                float successChance = Random.Range(0, 100);
                float successMarker = maxSuccessChance - failureChance;
                // If the random is within the success range
                if (successChance <= successMarker)
                {
                    if (IsAdjacentToPlayer() == false)
                    {
                        SetMovementVector();
                    }
                    else if (this.transform.position + lastDirection != player.transform.position)
                    {
                        Vector2 lookDirection = player.transform.position - this.transform.position;
                        Rotate(lookDirection);
                    }
                    else
                    {
                        attackManager.GetAttack().Execute(this.gameObject);
                    }
                }
                if (BeatTrigger.beatsCounter == 10)
                {
                    //Every missed beat gives the AI a 7.5% greater chance of failure.
                    //Because this is checked every 10 beats, there is a min
                    //failureChance = maxSuccessChance - ((BeatTrigger.beatsCounter - BeatTrigger.beatsHit) * missedBeatWeight);
                }
                //BeatSpawner.aiCanMove = false;
            }
            else if(BeatSpawner.aiCanMove==false)
            {
                hasMovedThisBeat = false;
            }
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
    public void Attack(float[,] attackGrid, int damage)
    {
            unitAttack.Attack(attackGrid, lastDirection, attackMarker, damage);
    }

    public bool Rotate(Vector2 direction)
    {
        lastDirection = direction;
        return movement.Rotate(direction);
    }
}
