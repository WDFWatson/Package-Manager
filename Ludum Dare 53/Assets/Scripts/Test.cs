using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private BoxSpawner boxSpawner;
    private void Awake()
    {
        boxSpawner = FindObjectOfType<BoxSpawner>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            boxSpawner.Spawn();
            ItemManager.instance.SetIllegalItems();
        }
    }
}
