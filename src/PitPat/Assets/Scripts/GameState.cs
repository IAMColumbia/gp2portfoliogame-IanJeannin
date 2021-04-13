using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum StateOfGame { Menu,Play,Pause};

    public static StateOfGame stateOfGame = StateOfGame.Menu;
}
