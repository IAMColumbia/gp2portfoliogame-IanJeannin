using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttack : Attack
{
    private float[,] attackedSpaces;
    private float damage;
    public SpearAttack() : base()
    {
        this.commandName = "Spear Attack";
        attackedSpaces = new float[7, 7];
        attackedSpaces = SetUpAttackGrid();
        damage = 1;
    }
    public override void Execute(GameObject go)
    {
        //Different Game Components may move differently check if the go is a CommandPacMan
        if (go.GetComponent<PlayerController>() != null)
        {
            var target = go.GetComponent<PlayerController>();
            target.Attack(attackedSpaces, damage);
        }
        else if (go.GetComponent<EnemyController>() != null)
        {
            var target = go.GetComponent<EnemyController>();
            target.Attack(attackedSpaces, damage);
        }
        base.Execute(go);
    }

    /// <summary>
    /// Use to initialize the values of the attack grid. The targeted space is [4,4] (Most attacks will have the player as the targeted space)
    /// "True" spaces are ones that will be attacked
    /// </summary>
    /// <returns></returns>
    public override float[,] SetUpAttackGrid()
    {
        float[,] attackedSpacesX = new float[7, 7]
        {
            {0,0,0,3,0,0,0},
            {0,0,0,1.5f,0,0,0},
            {0,0,0,0.5f,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
        };
        return attackedSpacesX;
    }
}