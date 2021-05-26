using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGradients : MonoBehaviour
{
    public Color red = new Color(244f / 255f, 99f / 255f, 79f / 255f, 255f / 255f);
    public Color redShadow = new Color(244f / 255f, 99f / 255f, 79f / 255f, 128f / 255f);
    public Color yellow = new Color(242f / 255f, 244f / 255f, 79f / 255f, 255f / 255f);
    public Color yellowShadow = new Color(242f / 255f, 244f / 255f, 79f / 255f, 128f / 255f);
    public Color green = new Color(78f / 255f, 244f / 255f, 167f / 255f, 255f / 255f);
    public Color greenShadow = new Color(78f / 255f, 244f / 255f, 167f / 255f, 128f / 255f);
    public Color blue = new Color(66f / 255f, 175f / 255f, 255f / 255f);
    public Color blueShadow = new Color(66f / 255f, 175f / 255f, 255f / 255f, 128f / 255f);
    public Color grey = new Color(104f / 255f, 104f / 255f, 104f / 255f);
    public Color greyShadow = new Color(104f / 255f, 104f / 255f, 104f / 255f, 128f / 255f);

    private Gradient gradient;
    private GradientColorKey[] gradientColorKey;
    private GradientAlphaKey[] gradientAlphaKey;

    public Color evaluate(Color[] colors, float time)
    {
        gradient = new Gradient();
        gradientColorKey = new GradientColorKey[colors.Length];
        gradientAlphaKey = new GradientAlphaKey[0];

        gradientColorKey[0].color = colors[0];
        gradientColorKey[0].time = 1.000001f;
        if (colors.Length > 1)
        {
            for (int i = 1; i < colors.Length; i++)
            {
                gradientColorKey[i].color = colors[i];
                gradientColorKey[i].time = time / colors.Length;
            }
        }

        gradient.SetKeys(gradientColorKey, gradientAlphaKey);

        return gradient.Evaluate(time);
    }

    // Use this for initialization
    void Start()
    {
        initializeDefaultGradient();
    }

    public void initializeDefaultGradient() {
        gradient = new Gradient();
        gradientColorKey = new GradientColorKey[3];
        gradientAlphaKey = new GradientAlphaKey[0];

        gradientColorKey[0].color = green;
        gradientColorKey[0].time = 1.000001f;

        gradientColorKey[1].color = yellow;
        gradientColorKey[1].time = 0.500001f;

        gradientColorKey[2].color = red;
        gradientColorKey[2].time = 0.200001f;

        gradient.SetKeys(gradientColorKey, gradientAlphaKey);
    }

        public Color getGreen()
    {
        return green;
    }

    public Color getGreenShadow()
    {
        return greenShadow;
    }

    public Color getYellow()
    {
        return yellow;
    }

    public Color getYellowShadow()
    {
        return yellowShadow;
    }

    public Color getRed()
    {
        return red;
    }

    public Color getRedShadow()
    {
        return redShadow;
    }

    public Color getBlue()
    {
        return blue;
    }

    public Color getBlueShadow()
    {
        return blueShadow;
    }

    public Color getGrey()
    {
        return grey;
    }

    public Color getGreyShadow()
    {
        return greyShadow;
    }

    public Gradient getGradient()
    {
        return gradient;
    }
}
