using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface OptionSpawningStrategy
{
    List<(int, int)> generateOptionsToSpawn();
}
