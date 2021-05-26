using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReportPanelState : MonoBehaviour
{
    public GameObject gameStateObject;
    private GameState gameState;

    public UnityEngine.UI.Text score;
    public bool animateProgress;
    private float animationMaxTime;
    public ColorGradients colorGradients;

    public Image sliderImage;
    public Slider slider;
    public bool hasExactlyMetTarget;
    public Image continueOrRestartButtonImage;
    public Shadow continueOrRestartButtonShadow;
    public Text continueOrRestartButtonText;

    public Text targetText;
    public Text currentTotalText;
    public Text reasonText;
    public float currentPercentage;

    private void Awake()
    {
        gameState = gameStateObject.GetComponent<GameState>();
    }

    // Use this for initialization
    void Start()
    {
        slider.minValue = 0.0f;
        slider.maxValue = gameState.getCurrentTarget();
        slider.value = 0;
        animationMaxTime = 1.5f;
        animateProgress = false;
        hasExactlyMetTarget = false;
        currentPercentage = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = gameState.getCurrentTarget();
        targetText.text = gameState.getCurrentTarget().ToString();
        currentTotalText.text = gameState.getCurrentTotal().ToString();
        if (animateProgress && gameState.getCurrentGameState().Equals(CurrentGameState.REPORT))
        {
            animate();
            reasonText.text = "So close!";
        }
        else if (animateProgress && gameState.getCurrentGameState().Equals(CurrentGameState.GAME_OVER))
        {
            animate();
            reasonText.text = "Too much!";
        }
    }

    public void continueOrRestart()
    {
        if (currentPercentage > 95.0f && currentPercentage <= 100.0F)
        {
            gameState.changeGameState(CurrentGameState.CHOOSING_TARGET);
        }
        else
        {
            gameState.changeGameState(CurrentGameState.RESTART);
        }
    }

    public void resetReportPanel()
    {
        Start();
    }

    private void animate()
    {
        score.text = gameState.getCurrentScore().ToString();
        animationMaxTime -= Time.deltaTime;
        if (animationMaxTime >= 0.000001f)
        {
            slider.value = Mathf.Lerp(gameState.getCurrentTotal() / 1.0f, 0.0f, animationMaxTime / 1.0000001f);
            currentPercentage = (gameState.getCurrentTotal() * 1.0f / gameState.getCurrentTarget() * 1.0f) * 100;
            // Debug.Log("PERCENTAGE: " + currentPercentage);
            if (currentPercentage > 100.0f)
            {
                Color[] colors = { colorGradients.getYellow(), colorGradients.getRed()};
                sliderImage.color = colorGradients.evaluate(colors, animationMaxTime / 1.0000001f);
                continueOrRestartButtonText.text = "Restart";
                continueOrRestartButtonImage.color = colorGradients.getGreen();
                continueOrRestartButtonShadow.effectColor = colorGradients.getGreenShadow();
            }
            else if (currentPercentage > 95.0f)
            {
                Color[] colors = { colorGradients.getRed(), colorGradients.getYellow(), colorGradients.getGreen() };
                sliderImage.color = colorGradients.evaluate(colors, animationMaxTime / 1.0000001f);
                continueOrRestartButtonText.text = "Continue";
                continueOrRestartButtonImage.color = colorGradients.getGreen();
                continueOrRestartButtonShadow.effectColor = colorGradients.getGreenShadow();
            }
            else if (currentPercentage > 80.0f && currentPercentage <= 95)
            {
                Color[] colors = { colorGradients.getRed(), colorGradients.getYellow() };
                sliderImage.color = colorGradients.evaluate(colors, animationMaxTime / 1.0000001f);
                continueOrRestartButtonText.text = "Restart";
                continueOrRestartButtonImage.color = colorGradients.getBlue();
                continueOrRestartButtonShadow.effectColor = colorGradients.getBlueShadow();

            }
            else
            {
                Color[] colors = { colorGradients.getRed() };
                sliderImage.color = colorGradients.evaluate(colors, animationMaxTime / 1.0000001f);
                continueOrRestartButtonText.text = "Restart";
                continueOrRestartButtonImage.color = colorGradients.getBlue();
                continueOrRestartButtonShadow.effectColor = colorGradients.getBlueShadow();
            }
        }
    }
}
