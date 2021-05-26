using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelState : MonoBehaviour
{

    public GameObject gameStateObject;
    private GameState gameState;

    private void Awake()
    {
        gameState = gameStateObject.GetComponent<GameState>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState.changeGameState(CurrentGameState.START);
    }


    public void loadTargetPanel()
    {
        gameState.changeGameState(CurrentGameState.CHOOSING_TARGET);
    }
}
