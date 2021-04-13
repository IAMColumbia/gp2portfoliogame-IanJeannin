using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Command
{
    private float[,] attackedSpaces;
    private int damage;
    public Attack() : base()
    {
        this.commandName = "Attack";
        attackedSpaces = new float[7, 7];
        attackedSpaces = SetUpAttackGrid();
        damage = 0;
    }

    public override void Execute(GameObject go)
    {
        //Different Game Components may move differently check if the go is a CommandPacMan
        var target = go.GetComponent<PlayerController>();
        if (target is PlayerController)
        {
            target.Attack(attackedSpaces,damage);
            base.Execute(go);
        }
    }

    /// <summary>
    /// Use to initialize the values of the attack grid. The targeted space is [4,4] (Most attacks will have the player as the targeted space)
    /// The number is the percent of damage
    /// </summary>
    /// <returns></returns>
    public virtual float[,] SetUpAttackGrid()
    {
        float[,] attackedSpacesX = new float[7, 7]
        {
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
        };
        return attackedSpacesX;
    }
}
