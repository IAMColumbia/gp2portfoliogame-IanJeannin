using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{

    private PlayerMovement controls;

    //List of previously processed commands
    Stack<Command> Commands = new Stack<Command>();

    public GameObject CommandTarget;


    private void Awake()
    {
        controls = new PlayerMovement();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Main.Movement.performed += ctx => MoveCommand(ctx.ReadValue<Vector2>());
        controls.Main.Rotate.performed += ctx => RotateCommand(ctx.ReadValue<Vector2>());
        controls.Main.Attack.performed += ctx => AttackCommand();
    }

    private void MoveCommand(Vector2 direction)
    {
        Command newCommand = new Move();
        newCommand.Execute(CommandTarget,direction);
    }
    private void RotateCommand(Vector2 direction)
    {
        Command newCommand = new Rotate();
        newCommand.Execute(CommandTarget, direction);
    }

    private void AttackCommand()
    {
        Command newCommand = new Attack();
        newCommand.Execute(CommandTarget);
    }

}
