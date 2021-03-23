using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBeat : Command
{
    public PlayBeat() : base()
    {
        this.commandName = "Play Beat";
    }
    public override void Execute(GameObject go)
    {
            BeatMovement.Begin();
            base.Execute(go);
    }
}
