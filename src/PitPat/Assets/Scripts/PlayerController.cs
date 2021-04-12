﻿using System.Collections;
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
    [SerializeField]
    private int maxHealth=10;

    //Player starts the game looking down
    private Vector3 lastDirection = new Vector3(0, -1, 0);

    private UnitAttack unitAttack;
    private UnitProfile unitProfile;
    private Movement movement;

    private bool beatHit = false;

    private void Start()
    {
        unitAttack=this.gameObject.AddComponent<UnitAttack>();
        unitAttack.Initialize(this.gameObject,markerHolder);
        unitProfile = this.gameObject.AddComponent<UnitProfile>();
        unitProfile.Initialize(maxHealth);
        movement = this.gameObject.AddComponent<Movement>();
        movement.Initialize(groundTilemap, collisionTilemap);
    }
    
    private void Update()
    {
        if (GameState.stateOfGame == GameState.StateOfGame.Menu)
        {

        }
        else
        {
            if (BeatTrigger.beatEntered)
            {
                BeatTrigger.beatEntered = false;
                unitAttack.RemoveMarkers();
            }
            if (BeatTrigger.canBePressed == false)
            {
                beatHit = false;
            }
        }
    }
    
    /// <summary>
    /// Recieves an attack grid. 
    /// NOTE: AttackGrid must be [7,7]
    /// </summary>
    /// <param name="attackGrid"></param>
    public void Attack(bool[,] attackGrid,int damage)
    {
        if(BeatTrigger.canBePressed==true && beatHit == false)
        {
            beatHit = true;
            BeatTrigger.beatsHit++;
            unitAttack.Attack(attackGrid, lastDirection, attackMarker,damage);
        }
    }
    public bool Move(Vector2 direction)
    {
        if(BeatTrigger.canBePressed && beatHit == false)
        {
            beatHit = true;
            BeatTrigger.beatsHit++;
            lastDirection = direction;
            return movement.Move(direction);
        }
        else
        {
            return false;
        }
    }

    public bool Rotate(Vector2 direction)
    {
        if (BeatTrigger.canBePressed&&beatHit==false)
        {
            beatHit = true;
            BeatTrigger.beatsHit++;
            lastDirection = direction;
            return movement.Rotate(direction);
        }
        else
        {
            return false;
        }
    }
}
