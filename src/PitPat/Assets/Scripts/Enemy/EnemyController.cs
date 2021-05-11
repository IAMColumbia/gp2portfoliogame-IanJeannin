using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Pathfinding pathfinding;
    [SerializeField]
    private GameObject player;

    //Player starts the game looking down
    private Vector3 lastDirection = new Vector3(0, -1, 0);

    [Tooltip("The percentage that failure chance is increased for each beat the player misses. Maximum of 10 for 100%. Minimum of 0.")]
    [SerializeField]
    [Range(0,10)]
    private float missedBeatWeight=7.5f;
    [SerializeField]
    private float maxSuccessChance = 100;
    private float failureChance=30;

    //Variables used to prevent skeletons moving every single beat.
    private float beatsToMove = 2;
    private float beatCounter = 0;

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
        if(player==null)
        {
            player = GameObject.Find("Player");
        }
        unitAttack = this.gameObject.AddComponent<UnitAttack>();
        unitAttack.Initialize(this.gameObject);
        if(this.gameObject.GetComponent<UnitProfile>()==null)
        {
            unitProfile = this.gameObject.AddComponent<UnitProfile>();
            unitProfile.Initialize();
        }
        movement = this.gameObject.AddComponent<Movement>(); //Enemy doesn't need to initialize
    }

    void SetMovementVector()
    {
        Vector2 nextMove = pathfinding.FindPath(this.transform.position,player.transform.position);
        Rotate(nextMove);
        Collider2D[] enemyColliders = new Collider2D[1];
        LayerMask mask = LayerMask.GetMask("Enemies", "Player");
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = mask;
        Physics2D.OverlapCircle(this.transform.position+(Vector3)nextMove, 0.05f, filter, enemyColliders);
        if (enemyColliders[0] == false)
        {
            this.transform.position += (Vector3)nextMove;
        }
    }

    bool hasMovedThisBeat = false;

    private void Update()
    {
        if(GameState.stateOfGame==GameState.StateOfGame.Play)
        {
            if (BeatSpawner.aiCanMove == true && hasMovedThisBeat == false)
            {
                if (beatCounter < beatsToMove)
                {
                    hasMovedThisBeat = true;
                    beatCounter++;
                }
                else
                {
                    beatCounter = 0;
                    hasMovedThisBeat = true;
                    if (IsAdjacentToPlayer() == false)
                    {
                        SetMovementVector();
                    }
                    else if (this.transform.position + lastDirection != player.transform.position) //If enemy is not currently facing the player
                    {
                        Vector2 lookDirection = player.transform.position - this.transform.position;
                        Rotate(lookDirection);
                    }
                    else
                    {
                        attackManager.GetAttack().Execute(this.gameObject);
                    }
                }
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
    public void Attack(float[,] attackGrid, float damage)
    {
            unitAttack.Attack(attackGrid, lastDirection, damage);
    }

    public bool Rotate(Vector2 direction)
    {
        lastDirection = direction;
        return movement.Rotate(direction);
    }
}
