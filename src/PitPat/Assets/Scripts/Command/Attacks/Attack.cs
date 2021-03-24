using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Command
{
    private bool[,] attackedSpaces;
    public Attack() : base()
    {
        this.commandName = "Attack";
        attackedSpaces = new bool[7, 7];
        attackedSpaces = SetUpAttackGrid();
    }

    public override void Execute(GameObject go)
    {
        //Different Game Components may move differently check if the go is a CommandPacMan
        var target = go.GetComponent<PlayerController>();
        if (target is PlayerController)
        {
            target.Attack(attackedSpaces);
            base.Execute(go);
        }
    }

    /// <summary>
    /// Use to initialize the values of the attack grid. The targeted space is [4,4] (Most attacks will have the player as the targeted space)
    /// "True" spaces are ones that will be attacked
    /// </summary>
    /// <returns></returns>
    public virtual bool[,] SetUpAttackGrid()
    {
        bool[,] attackedSpacesX = new bool[7, 7]
        {
            {false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false},
        };
        return attackedSpacesX;
    }
}
