using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTargetPanelState : MonoBehaviour
{
    public Text targetText;
    public Text levelText;

    public GameObject gameStateObject;
    private GameState gameState;

    private int currentTarget;
    private int currentLevel;

    private void Awake()
    {
        gameState = gameStateObject.GetComponent<GameState>();
        currentTarget = -1;
        currentLevel = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public void targetUpdate()
    {
        currentTarget = generateNewTarget();
        targetText.text = currentTarget.ToString();
        levelText.text = currentLevel.ToString();
        gameState.setCurrentLevel(currentLevel);
    }

    public void targetReset() {
        currentLevel = 0;
        currentTarget = generateNewTarget();
        targetText.text = currentTarget.ToString();
        levelText.text = currentLevel.ToString();
        gameState.setCurrentLevel(currentLevel);
    }

    public void loadGamePanel()
    {
        gameState.changeGameState(CurrentGameState.PLAYING_GAME);
    }

    private int generateNewTarget()
    {
        //TODO: pass params to method instead of re-initializing the object every time
        int nextLevel = currentLevel + 1;
        currentLevel++;
        return gameState.generateAndSetTarget(currentLevel);
    }
}
