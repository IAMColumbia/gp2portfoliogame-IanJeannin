﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack: MonoBehaviour
{
    private GameObject attackingObject;
    private AttackMarkers markerHolder;

    //private float secondsToClearMarkers;

    public void Initialize(GameObject controller)
    {
        attackingObject = controller;
        markerHolder = (AttackMarkers)FindObjectOfType(typeof(AttackMarkers));
    }

    public void Attack(float[,] attackGrid,Vector3 lastDirection,float damage)
    {
        //The space that the first index of the attackGrid aligns to. 
        Vector3 targetedSpace = attackingObject.transform.position;
        //Simulates rotation of the grid according to player direction
        bool rowIsX = false;
        bool xPositiveTowardsPlayer = false;
        bool yPositiveTowardsPlayer = false;

        //If player is facing upwards
        if (lastDirection == new Vector3(0, 1, 0))
        {
            targetedSpace.x = targetedSpace.x - 3;
            targetedSpace.y = targetedSpace.y + 3;
            //transform.position = (Vector3)targetedSpace;
            xPositiveTowardsPlayer = true;
            yPositiveTowardsPlayer = false;
            rowIsX = true;
        } //If Player is facing right
        else if (lastDirection == new Vector3(1, 0, 0))
        {
            targetedSpace.x = targetedSpace.x + 3;
            targetedSpace.y = targetedSpace.y + 3;
            //transform.position = (Vector3)targetedSpace;
            xPositiveTowardsPlayer = false;
            yPositiveTowardsPlayer = false;
            rowIsX = false;
        } //If Player is facing down
        else if (lastDirection == new Vector3(0, -1, 0))
        {
            targetedSpace.x = targetedSpace.x + 3;
            targetedSpace.y = targetedSpace.y - 3;
            //transform.position = (Vector3)targetedSpace;
            xPositiveTowardsPlayer = false;
            yPositiveTowardsPlayer = true;
            rowIsX = true;
        } //If player is facing left
        else if (lastDirection == new Vector3(-1, 0, 0))
        {
            targetedSpace.x = targetedSpace.x - 3;
            targetedSpace.y = targetedSpace.y - 3;
            //transform.position = (Vector3)targetedSpace;
            xPositiveTowardsPlayer = true;
            yPositiveTowardsPlayer = true;
            rowIsX = false;
        }
        float numberOfRows = Mathf.Sqrt(attackGrid.Length);
        float targetedSpaceX = targetedSpace.x;
        float targetedSpaceY = targetedSpace.y;
        for (int row = 0; row < 7; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (attackGrid[row, col] >0)
                {
                    Collider2D [] enemyColliders=new Collider2D[1];
                    LayerMask mask = LayerMask.GetMask("Enemies","Player");
                    ContactFilter2D filter = new ContactFilter2D();
                    filter.layerMask = mask;
                    Physics2D.OverlapCircle(targetedSpace, 0.05f, filter, enemyColliders);
                    if (enemyColliders[0]==true)
                    {
                        enemyColliders[0].gameObject.GetComponent<UnitProfile>().ChangeHealth(-damage*attackGrid[row,col]);
                        Debug.Log("Health: " + enemyColliders[0].gameObject.GetComponent<UnitProfile>().GetHealth());
                    }
                    markerHolder.AddMarker(targetedSpace);
                    //Instantiate(attackMarker, targetedSpace, Quaternion.identity, markerHolder.transform);
                }
                if (rowIsX)
                {
                    if (xPositiveTowardsPlayer)
                    {
                        targetedSpace.x++;
                    }
                    else
                    {
                        targetedSpace.x--;
                    }
                }
                else
                {
                    if (yPositiveTowardsPlayer)
                    {
                        targetedSpace.y++;
                    }
                    else
                    {
                        targetedSpace.y--;
                    }
                }
            }
            if (rowIsX)
            {
                if (yPositiveTowardsPlayer)
                {
                    targetedSpace.y++;
                }
                else
                {
                    targetedSpace.y--;
                }
                //Reset the row starting location
                targetedSpace.x = targetedSpaceX;

            }
            else
            {
                if (xPositiveTowardsPlayer)
                {
                    targetedSpace.x++;
                }
                else
                {
                    targetedSpace.x--;
                }
                //Reset the column starting location
                targetedSpace.y = targetedSpaceY;
            }
        }
    }

    public void RemoveMarkers()
    {
        foreach (Transform child in markerHolder.transform)
        {
           Destroy(child.gameObject);
        }
    }
}
