using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] objects;
    public List<WeightedValue> weightedValues;

    void Start()
    {
        int random = GetRandomValue(weightedValues);
        Instantiate(objects[random], transform.position, Quaternion.identity);
    }

    int GetRandomValue(List<WeightedValue> gameObjectsList)
    {
        int output = 0;
        var totalWeight = 0;

        foreach (var gameObject in gameObjectsList)
        {
            totalWeight += gameObject.weight;
        }
        var rndWeightValue = Random.Range(0, totalWeight + 1);
        var processWeight = 0;
        foreach (var gameObject in gameObjectsList)
        {
            processWeight += gameObject.weight;
            if (rndWeightValue <= processWeight)
            {
                output = gameObject.value;
                break;
            }
        }

        return output;
    }

}
