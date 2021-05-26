using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GamePanelState : MonoBehaviour
{

    public GameObject gameStateObject;
    private GameState gameState;

    public UnityEngine.UI.Text leftOption;
    public UnityEngine.UI.Text rightOption;

    public int currentTotal;

    private int target;
    private int score;
    public Timer timer;
    private OptionSpawningStrategy optionSpawningStrategy;

    private void Awake()
    {
        gameState = gameStateObject.GetComponent<GameState>();
        optionSpawningStrategy = new RandomOptionSpawningStrategy(target);
        currentTotal = 0;
        score = 0;
    }

    private void Start()
    {
        (int, int) options = spawnNewOptions();
        leftOption.text = options.Item1.ToString();
        rightOption.text = options.Item2.ToString();

        target = gameState.getCurrentTarget();
        score = gameState.getCurrentScore();
    }

    public void addLeftOptionToTotal()
    {
        startTimer();

        target = gameState.getCurrentTarget();

        int total = currentTotal + int.Parse(leftOption.text);
        if (total < target)
        {
            currentTotal += int.Parse(leftOption.text);
            (int, int) options = spawnNewOptions();
            leftOption.text = options.Item1.ToString();
            rightOption.text = options.Item2.ToString();
            gameState.setCurrentScore(score++);
            gameState.setCurrentTotal(currentTotal);
            timer.resetTimer();
        }
        else if (total > target)
        {
            currentTotal += int.Parse(leftOption.text);
            gameState.setCurrentTotal(currentTotal);
            gameState.changeGameState(CurrentGameState.GAME_OVER);
            stopTimer();
            timer.resetTimer();
        }
        else if (total == target)
        {
            currentTotal += int.Parse(rightOption.text);
            gameState.setCurrentScore(score++);
            gameState.setCurrentTotal(currentTotal);
            gameState.changeGameState(CurrentGameState.CHOOSING_TARGET);
            stopTimer();
            timer.resetTimer();
        }
    }

    public void resetGamePanel()
    {
        currentTotal = 0;
        target = gameState.getCurrentTarget();
        optionSpawningStrategy = new RandomOptionSpawningStrategy(target);

        gameState.setCurrentTotal(0);

        (int, int) options = spawnNewOptions();
        leftOption.text = options.Item1.ToString();
        rightOption.text = options.Item2.ToString();

        stopTimer();
        timer.resetTimer();
    }

    public void addRightOptionToTotal()
    {

        startTimer();

        target = gameState.getCurrentTarget();

        int total = currentTotal + int.Parse(rightOption.text);
        if (total < target)
        {
            currentTotal += int.Parse(rightOption.text);
            (int, int) options = spawnNewOptions();
            leftOption.text = options.Item1.ToString();
            rightOption.text = options.Item2.ToString();
            gameState.setCurrentScore(score++);
            gameState.setCurrentTotal(currentTotal);
            timer.resetTimer();
        }
        else if (total > target)
        {
            currentTotal += int.Parse(rightOption.text);
            gameState.setCurrentTotal(currentTotal);
            gameState.changeGameState(CurrentGameState.GAME_OVER);
            stopTimer();
            timer.resetTimer();
        }
        else if (total == target)
        {
            currentTotal += int.Parse(rightOption.text);
            gameState.setCurrentScore(score++);
            gameState.setCurrentTotal(currentTotal);
            gameState.changeGameState(CurrentGameState.CHOOSING_TARGET);
            stopTimer();
            timer.resetTimer();
        }
    }

    public void donePressed()
    {
        gameState.changeGameState(CurrentGameState.REPORT);
    }

    public (int, int) spawnNewOptions()
    {
        List<(int, int)> options = optionSpawningStrategy.generateOptionsToSpawn();
        // options.ForEach((x) => Debug.Log("Options are: " + x));
        (int, int) actualOptions = options.ToArray()[0];

        // if ((actualOptions.Item1 + currentTotal > target) && (actualOptions.Item2 + currentTotal > target)) {
        //     return spawnNewOptions();
        // } 
        return options.ToArray()[0];
    }

    public void startTimer()
    {
        timer.enabled = true;
        timer.startTimer = true;
    }

    public void stopTimer()
    {
        timer.enabled = false;
        timer.startTimer = false;
    }
}
