using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnUFO : MonoBehaviour
{
    [SerializeField] private GameObject UFO;
    private Transform thisTransform;
    private TimeSpan spawnDelay;
    private float accumulatedTime;
    private int randomSeconds;
    private int minValue;
    private int maxValue;
    
    // Start is called before the first frame update
    void Start()
    {
        minValue = 15;
        maxValue = 25;
        randomSeconds = Mathf.RoundToInt(Random.Range(minValue, maxValue));
        spawnDelay = new TimeSpan(0, 0, randomSeconds);

        thisTransform = gameObject.transform;
        accumulatedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        randomSeconds = Mathf.RoundToInt(Random.Range(minValue, maxValue));
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime >= spawnDelay.Seconds)
        {
            Instantiate(UFO, thisTransform);
            accumulatedTime = 0f;
            spawnDelay = new TimeSpan(0, 0, randomSeconds);
            Debug.Log("Next UFO Spawn: " + spawnDelay.Seconds);
        }
    }
}
