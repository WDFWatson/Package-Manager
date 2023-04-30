using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxSpawner : MonoBehaviour
{
    public static BoxSpawner instance;

    public Box boxPrefab;

    public int rows;

    public int columns;
    public int activeBoxLimit = 5;
    public int activeBoxes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public void Spawn()
    {
        EffectManager.instance.Spawn();
        activeBoxes++;
        if (activeBoxes > activeBoxLimit)
        {
            LoadManager.instance.LoadGameOver();
        }
        Box newBox = Instantiate(boxPrefab, transform.position, quaternion.identity);
        newBox.rb.bodyType = RigidbodyType2D.Static;
        var spawnPositions = newBox.GetSpawnPositions(rows, columns);
        foreach (var position in spawnPositions)
        {
            ItemManager im = ItemManager.instance;
            int index = im.itemList[Random.Range(0, im.itemList.Count)];
            int newItemID = im.itemList[index];
            newBox.contents.Add(newItemID);
            Instantiate(im.items[newItemID],position,Quaternion.identity);
        }
        newBox.rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
