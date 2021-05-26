using UnityEngine;
using System.Collections;

public class RandomTargetGenerationStrategy : TargetGenerationStrategy
{

    public RandomTargetGenerationStrategy()
    {}

    public int generateTarget(int currentLevel)
    {
        int nextLevel = currentLevel++;
        // Debug.Log("Generating target for CurrentLevel: " + currentLevel + " and nextLevel" + nextLevel);
        // Debug.Log("Generating target between " + ((currentLevel * 10) + 20) + " and " + ((nextLevel * 10) + 20));
        int target = Random.Range(((currentLevel * 10) + 20), ((nextLevel * 10) + 20));
        // Debug.Log("Target generated is " + target);
        return target;

    }
}
