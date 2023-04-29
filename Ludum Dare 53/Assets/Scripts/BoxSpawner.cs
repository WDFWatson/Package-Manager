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
        Box newBox = Instantiate(boxPrefab, transform.position, quaternion.identity);
        var spawnPositions = newBox.GetSpawnPositions(rows, columns);
        foreach (var position in spawnPositions)
        {
            ItemManager im = ItemManager.instance;
            int index = im.itemList[Random.Range(0, im.itemList.Count)];
            int newItemID = im.itemList[index];
            newBox.contents.Add(newItemID);
            Instantiate(im.items[newItemID],position,Quaternion.identity);
        }
    }
}
