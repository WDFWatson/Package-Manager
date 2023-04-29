using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public bool clockMode = true;

    public float timeInterval = 5f;
    public float increaseRate = 0.9f;
    public int increaseInterval = 10;
    public int changeItemsInterval = 5;
    

    private float timeSinceLastInterval = 0;
    private int pulsesSinceLastIncrease = 0;
    private int pulsesSinceItemChange = 0;

    private void FixedUpdate()
    {
        if (clockMode)
        {
            timeSinceLastInterval += Time.fixedDeltaTime;
            if (timeSinceLastInterval >= timeInterval)
            {
                //Clock Pulse
                BoxSpawner.instance.Spawn();
                pulsesSinceLastIncrease++;
                pulsesSinceItemChange++;
                timeSinceLastInterval = 0;
                
            }

            if (pulsesSinceItemChange >= changeItemsInterval)
            {
                ItemManager.instance.SetIllegalItems();
                pulsesSinceItemChange = 0;
            }
            
            if (pulsesSinceLastIncrease >= increaseInterval)
            {
                timeInterval *= increaseRate;
                pulsesSinceLastIncrease = 0;
            }
        }
    }
}
