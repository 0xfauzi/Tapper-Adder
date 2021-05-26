using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RandomOptionSpawningStrategy : OptionSpawningStrategy
{

    private int target;

    public RandomOptionSpawningStrategy(int target)
    {
        this.target = target;
    }

    public List<(int, int)> generateOptionsToSpawn()
    {
        int lowerBound = 0;
        int upperBound = 0;
        if (target / 10 < 10)
        {
            lowerBound = 1;
            upperBound = 20;
        }
        else if (target / 100 < 100)
        {
            lowerBound = 1;
            upperBound = 200;
        }
        else if (target / 1000 < 1000)
        {
            lowerBound = 1;
            upperBound = 2000;
        }
        int option1 = Random.Range(lowerBound, upperBound);
        int option2 = Random.Range(lowerBound, upperBound);
        if (option1 == option2) {
            option1 = Random.Range(lowerBound, upperBound);
            option2 = Random.Range(lowerBound, upperBound);
        }

        return new List < (int, int) > { (option1, option2) };
    }
}
