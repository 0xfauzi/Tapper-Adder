using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//PURPOSE: This class will handle the timer when the scene starts.
// It will send messages to the appropriate scripts when the timer
// is in the red and when the timer runs out, or it may
// perform appropriate actions for those two milestones
// itself.
public class Timer : MonoBehaviour
{
    public float maxTime = 10.0f;
    public Slider slider;
    public Image sliderImage;
    public GameObject gameStateObject;

    public bool startTimer;

    private GameState gameState;

    public ColorGradients colorGradients;


    private void Awake()
    {
        gameState = gameStateObject.GetComponent<GameState>();
    }


    // Use this for initialization
    void Start()
    {
        slider.value = maxTime;
        slider.minValue = 0.0F;
        slider.maxValue = maxTime;
        sliderImage.color = colorGradients.getGreen();
    }

    public void resetTimer()
    {
        slider.value = maxTime;
        slider.minValue = 0.0F;
        maxTime = 10.0F;
        slider.maxValue = maxTime;
        sliderImage.color = colorGradients.getGreen();
        colorGradients.initializeDefaultGradient();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            maxTime -= Time.deltaTime;
            if (maxTime <= 0.000001f)
            {
                gameState.changeGameState(CurrentGameState.REPORT);
            }
            else
            {
                slider.value = maxTime;
                sliderImage.color = colorGradients.getGradient().Evaluate(maxTime / 10.000001f);
            }
        }
    }
}
