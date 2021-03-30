using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : Command
{
    public Mute() : base()
    {
        this.commandName = "Mute";
    }
    public override void Execute(GameObject go, Vector2 direction)
    {
        //Different Game Components may move differently check if the go is a CommandPacMan
        var target = go.GetComponent<PlayerController>();
        if (target is PlayerController)
        {
            if (target.Move(direction))
            {
                base.Execute(go);
            }
        }
    }
}
