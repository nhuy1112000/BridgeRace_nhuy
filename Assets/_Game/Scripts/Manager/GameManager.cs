using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{Mainmenu, Gameplay, Pause }
public class GameManager : Singleton<GameManager>
{
    private GameState gameState;

    public void Start()
    {
        ChangeState(GameState.Gameplay);
    }

    public void ChangeState(GameState gamestate)
    {
        this.gameState = gamestate;
    }

    public bool IsState(GameState gamestate)
    {
        return this.gameState == gamestate;
    }

}
