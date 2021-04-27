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

    [Tooltip("How long before the player can attempt another input. ")]
    [SerializeField]
    private float inputLockTime=0.5f;

    float timer;
    private bool inputBlock=false;

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
        controls.Main.Quit.performed += ctx => Quit();
        controls.Main.SwitchAttackLeft.performed += ctx => SwitchAttackLeft();
        controls.Main.SwitchAttackRight.performed += ctx => SwitchAttackRight();
    }

    private void MoveCommand(Vector2 direction)
    {
        if (GameState.stateOfGame == GameState.StateOfGame.Pause)
        {
            GameState.stateOfGame = GameState.StateOfGame.Play;
        }
        if(GameState.stateOfGame==GameState.StateOfGame.Play&&inputBlock==false)
        {
            Command newCommand = new Move();
            newCommand.Execute(CommandTarget, direction);
            LockInput();
        }
    }
    private void RotateCommand(Vector2 direction)
    {
        if (GameState.stateOfGame == GameState.StateOfGame.Pause)
        {
            GameState.stateOfGame = GameState.StateOfGame.Play;
        }
        if(GameState.stateOfGame==GameState.StateOfGame.Play&&inputBlock==false)
        {
            Command newCommand = new Rotate();
            newCommand.Execute(CommandTarget, direction);
            LockInput();
        }
    }

    private void AttackCommand()
    {
        if (GameState.stateOfGame == GameState.StateOfGame.Pause)
        {
            GameState.stateOfGame = GameState.StateOfGame.Play;
        }
        if (GameState.stateOfGame==GameState.StateOfGame.Play && CommandTarget.GetComponent<AttackManager>()&&inputBlock==false)
        {
            CommandTarget.GetComponent<AttackManager>().GetAttack().Execute(CommandTarget);
            LockInput();
        }
        //Command attack = AttackManager.GetAttack();
        //attack.Execute(CommandTarget);
        //Command newCommand = new Attack();
        //newCommand.Execute(CommandTarget);
    }

    private void SwitchAttackLeft()
    {
        //AttackManager atkManager = CommandTarget.GetComponent<AttackManager>();
        CommandTarget.GetComponent<AttackManager>().SwitchAttack(CommandTarget.GetComponent<AttackManager>().GetAttackIndex()-1);
    }

    private void SwitchAttackRight()
    {
        //AttackManager atkManager = CommandTarget.GetComponent<AttackManager>();
        CommandTarget.GetComponent<AttackManager>().SwitchAttack(CommandTarget.GetComponent<AttackManager>().GetAttackIndex() + 1);
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

    public IEnumerator InputDelay()
    {
        inputBlock = true;
        yield return new WaitForSeconds(inputLockTime);
        inputBlock = false;
    }

    public void LockInput()
    {
        if(BeatSpawner.canBePressed==false)
        {
            inputBlock = true;
            timer -= timer;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(inputBlock==true)
        {
            if(timer>=inputLockTime)
            {
                timer -= timer;
                inputBlock = false;
            }
        }
    }
}
