using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Command
{
    public Attack() : base()
    {
        this.commandName = "Attack";
    }
    public override void Execute(GameObject go)
    {
        //Different Game Components may move differently check if the go is a CommandPacMan
        var target = go.GetComponent<PlayerController>();
        if (target is PlayerController)
        {
            target.Attack();
            base.Execute(go);
        }
    }
}
