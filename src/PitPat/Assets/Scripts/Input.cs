using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{

    private PlayerMovement controls;

    //List of previously processed commands
    Stack<Command> Commands = new Stack<Command>();

    public GameObject CommandTarget;
    public GameObject audioManager=null;


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
        controls.Main.Mute.performed += ctx => MuteCommand();
        controls.Main.Mute.performed += ctx => Quit();
    }

    private void MoveCommand(Vector2 direction)
    {
        if(GameState.stateOfGame==GameState.StateOfGame.Menu)
        {
            GameState.stateOfGame = GameState.StateOfGame.Play;

            Command newCommand = new Move();
            newCommand.Execute(CommandTarget, direction);
        }
        else
        {
            Command newCommand = new Move();
            newCommand.Execute(CommandTarget, direction);
        }
    }
    private void RotateCommand(Vector2 direction)
    {
        if (GameState.stateOfGame == GameState.StateOfGame.Menu)
        {
            GameState.stateOfGame = GameState.StateOfGame.Play;
        }
        else
        {
            Command newCommand = new Rotate();
            newCommand.Execute(CommandTarget, direction);
        }
    }

    private void AttackCommand()
    {
        if (GameState.stateOfGame == GameState.StateOfGame.Menu)
        {
            GameState.stateOfGame = GameState.StateOfGame.Play;
        }
        else
        {
            if (CommandTarget.GetComponent<AttackManager>())
            {
                CommandTarget.GetComponent<AttackManager>().GetAttack().Execute(CommandTarget);
            }
        }
        //Command attack = AttackManager.GetAttack();
        //attack.Execute(CommandTarget);
        //Command newCommand = new Attack();
        //newCommand.Execute(CommandTarget);
    }

    private void MuteCommand()
    {
        if(audioManager!=null)
        {
            audioManager.GetComponent<Songs>().ToggleMute();
        }
    }

    private void Quit()
    {
        Application.Quit();
    }
}
