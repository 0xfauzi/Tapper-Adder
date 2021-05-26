using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{

    public GameObject sceneManagerObject;
    private SceneManager sceneManager;

    public GameObject startPanelObject;
    private StartPanelState startPanelState;

    public GameObject targetPanelObject;
    private CurrentTargetPanelState targetPanelState;

    public GameObject gamePanelObject;
    private GamePanelState gamePanelState;

    public GameObject reportPanelObject;
    private ReportPanelState reportPanelState;
    
    private CurrentGameState currentGameState;
    public int currentTarget;
    public int currentLevel;
    public int score;
    public int currentTotal;
    public Timer timer;

    private RandomTargetGenerationStrategy randomTargetGeneration;

    void Awake()
    {
        sceneManager = sceneManagerObject.GetComponent<SceneManager>();
        startPanelState = startPanelObject.GetComponent<StartPanelState>();
        targetPanelState = targetPanelObject.GetComponent<CurrentTargetPanelState>();
        gamePanelState = gamePanelObject.GetComponent<GamePanelState>();
        reportPanelState = reportPanelObject.GetComponent<ReportPanelState>();
        currentGameState = CurrentGameState.START;
        currentTarget = -1;
        currentLevel = 0;
        score = 0;
        randomTargetGeneration = new RandomTargetGenerationStrategy();
    }

    public void changeGameState(CurrentGameState newGameState)
    {
        this.currentGameState = newGameState;
        if (CurrentGameState.CHOOSING_TARGET.Equals(currentGameState))
        {
            targetPanelState.targetUpdate();
            gamePanelState.resetGamePanel();
        }
        if (CurrentGameState.RESTART.Equals(currentGameState))
        {
            targetPanelState.targetReset();
            // reportPanelState.resetReportPanel();
            gamePanelState.resetGamePanel();
            setCurrentScore(0);
        }
        if (CurrentGameState.REPORT.Equals(currentGameState) || CurrentGameState.GAME_OVER.Equals(currentGameState))
        {
            // reportPanelState.resetReportPanel();
            reportPanelState.animateProgress = true;
            reportPanelState.hasExactlyMetTarget = true;
        }
        if (CurrentGameState.PLAYING_GAME.Equals(currentGameState))
        {
            reportPanelState.resetReportPanel();
            gamePanelState.resetGamePanel();
        }
    }

    private void Update()
    {
        if (CurrentGameState.START.Equals(currentGameState))
        {
            sceneManager.loadStartPanel();
        }
        else if (CurrentGameState.CHOOSING_TARGET.Equals(currentGameState))
        {
            sceneManager.loadTargetPanel();
        }
        else if (CurrentGameState.RESTART.Equals(currentGameState))
        {
            sceneManager.loadTargetPanel();
        }
        else if (CurrentGameState.PLAYING_GAME.Equals(currentGameState))
        {
            sceneManager.loadGamePanel();
        }
        else if (CurrentGameState.REPORT.Equals(currentGameState))
        {
            sceneManager.loadReportPanel();
        }
        else if (CurrentGameState.GAME_OVER.Equals(currentGameState))
        {
            sceneManager.loadReportPanel();
        }
    }

    public CurrentGameState getCurrentGameState()
    {
        return currentGameState;
    }

    public void setCurrentTarget(int newTarget)
    {
        // Debug.Log("GAME_STATE:: Current target is changing from " + currentTarget + " to " + newTarget);
        this.currentTarget = newTarget;
    }

    public int getCurrentTarget()
    {
        return currentTarget;
    }

    public void setCurrentLevel(int newLevel)
    {
        // Debug.Log("GAME_STATE:: Current level is changing from " + currentLevel + " to " + newLevel);
        this.currentLevel = newLevel;
    }

    public int getCurrentLevel()
    {
        return currentLevel;
    }

    public int getCurrentScore()
    {
        return score;
    }

    public void setCurrentScore(int newScore)
    {
        this.score = newScore;
    }

    public void setCurrentTotal(int currentTotal)
    {
        this.currentTotal = currentTotal;
    }

    public int getCurrentTotal()
    {
        return currentTotal;
    }

    public int generateAndSetTarget(int level)
    {
        int currentTarget = randomTargetGeneration.generateTarget(level);
        setCurrentTarget(currentTarget);
        return currentTarget;
    }







    //	public GameObject sceneManager;

    //	public UnityEngine.UI.Text leftOption;
    //	public UnityEngine.UI.Text rightOption;

    //	public UnityEngine.UI.Slider gameOverSlider;
    //	public int currentTotal;

    //	int target;
    //	int tempTotal;
    //	int currentLevel;
    //	int nextLevel;
    //	int currentLowerLimit, currentUpperLimit;
    //	bool isTargetTens, isTargetThousands, isTargetHundreds;
    //	bool optionSelected;

    //	void Start () 
    //	{
    //        target = 1;
    //		currentLevel = 0;
    //		nextLevel = currentLevel + 1;
    //		isTargetTens = false;
    //		isTargetHundreds = false;
    //		isTargetThousands = false;
    //		currentLowerLimit = 1;
    //		currentUpperLimit = 50;
    //		optionSelected = false;
    //		tempTotal = 0;


    //		/// <ACTION 1>
    //		/// Load target screen with target number and current level
    //		/// Target number will be randomly generated between:
    //		/// (currentLevel*10)+20 and (nextLevel*10)+20

    //		//Generating random target number
    //		createNewTarget();
    //		//Loading target screen
    //		sceneManager.GetComponent<SceneManager> ().loadTargetPanel (target, currentLevel);
    //		/// </ACTION 1>


    //		//Determine if the target is in tens, hundreds or thousands,
    //		//and spawn numbers using appropriate lower and upper limits.
    //		if(target / 10 < 10)
    //		{
    //			isTargetTens = true;
    //			isTargetHundreds = false;
    //			isTargetThousands = false;
    //			currentLowerLimit = 1;
    //			currentUpperLimit = 20;
    //			spawnNumbers(currentLowerLimit, currentUpperLimit);
    //			Debug.Log("Spawning at TENS");
    //		}
    //		else if(target / 100 < 100)
    //		{
    //			isTargetTens = false;
    //			isTargetHundreds = true;
    //			isTargetThousands = false;
    //			currentLowerLimit = 1;
    //			currentUpperLimit = 200;
    //			spawnNumbers(currentLowerLimit, currentUpperLimit);
    //			Debug.Log("Spawning at HUNDREDS");
    //		}
    //		else if(target / 1000 < 1000)
    //		{
    //			isTargetTens = false;
    //			isTargetHundreds = false;
    //			isTargetThousands = true;
    //			currentLowerLimit = 1;
    //			currentUpperLimit = 2000;
    //			spawnNumbers(currentLowerLimit, currentUpperLimit);
    //		}

    //	}

    //    private void Awake()
    //    {

    //    }

    //    /// <summary>
    //    /// Method to spawn the actual numbers
    //    /// </summary>
    //    public void spawnNumbers(int lower_limit, int upper_limit)
    //	{
    //		int op1, op2;
    //		op1 = Random.Range (lower_limit, upper_limit);
    //		op2 = Random.Range (lower_limit, upper_limit);
    //		leftOption.text = op1 + "";
    //		rightOption.text = op2 + "";
    //		Debug.Log ("Spawning numbers: "+leftOption.text+","+rightOption.text);
    //	}

    //	/// <summary>
    //	/// Methods to tally up actual total
    //	/// </summary>
    //	public void add_option1_to_total()
    //	{
    //		int total = currentTotal + int.Parse (rightOption.text);
    //		if( total <= target)
    //		{
    //			currentTotal += int.Parse (leftOption.text);
    //			Debug.Log ("Adding "+int.Parse (leftOption.text)+" to total which is now "+currentTotal);
    //			optionSelected = true;
    //		}
    //		else
    //		{
    //			round_over();
    //			sceneManager.GetComponent<SceneManager> ().loadGameOverPanel();
    //		}
    //	}
    //	public void add_option2_to_total()
    //	{
    //		int total = currentTotal + int.Parse (rightOption.text);
    //		Debug.Log ("CURRENT TOTAL: "+total);
    //		if(total <= target)
    //		{
    //			currentTotal += int.Parse (rightOption.text);
    //			Debug.Log ("Adding "+int.Parse (rightOption.text)+" to total which is now "+currentTotal);
    //			optionSelected = true;
    //		}
    //		else
    //		{
    //			round_over();
    //			sceneManager.GetComponent<SceneManager> ().loadGameOverPanel();
    //		}
    //	}

    //	/// <summary>
    //	/// Method called when done button is pressed.
    //	/// </summary>
    //	public void done_pressed()
    //	{
    //		createNewTarget();
    //		Debug.Log("Done pressed");
    //		round_over();
    //		sceneManager.GetComponent<SceneManager> ().loadTargetPanel (target, currentLevel);
    //		tempTotal = currentTotal;
    //		//current_total = 0;

    //	}

    //	/// <summary>
    //	/// Methods to create a new target
    //	/// </summary>
    //	int createNewTarget()
    //	{
    //		target = Random.Range (((currentLevel*10)+20), ((nextLevel*10)+20));
    //		Debug.Log ("New target created");
    ////		main_slider.maxValue = target;
    ////		main_slider.value = 1;
    //		gameOverSlider.maxValue = target;
    //		gameOverSlider.value = 1;
    //		currentLevel++;
    //		return target;
    //	}

    //	/// <summary>
    //	/// This method will display the report for the just ended round.
    //	/// i.e. with the progress bar
    //	/// </summary>
    //	public void round_over()
    //	{
    //		Debug.Log ("Round over");
    //		tempTotal = currentTotal;
    //		//current_total = 0;
    //	}

    //	void Update()
    //	{
    //		if(currentTotal == target)
    //		{
    //			Debug.Log("Target reached");
    //			createNewTarget();
    //			tempTotal = currentTotal;
    //			currentTotal = 0;
    //			round_over();
    //			sceneManager.GetComponent<SceneManager> ().loadTargetPanel(target, currentLevel);
    //		}

    //		if(optionSelected == true)
    //		{
    //			spawnNumbers(currentLowerLimit, currentUpperLimit);
    //			optionSelected = false;
    //		}

    ////		main_slider.value = temp_total;
    //		gameOverSlider.value = tempTotal;
    //	}
}
