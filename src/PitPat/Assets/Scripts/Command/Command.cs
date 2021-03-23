using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public string commandName;

    public Command()
    {
        this.commandName = "Base Command";
    }
    public virtual void Execute(GameObject go)
    {
        this.Log();
    }

    public virtual void Execute(GameObject go, Vector2 vector)
    {
        this.Log();
    }

    protected virtual void Log()
    {
        Debug.Log(string.Format("{0} executed.", commandName));
    }
}
