using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public Box boxPrefab;

    public int rows;

    public int columns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Box newBox = Instantiate(boxPrefab, transform.position, quaternion.identity);
        var spawnPositions = newBox.GetSpawnPositions(rows, columns);
        foreach (var position in spawnPositions)
        {
            ItemManager im = ItemManager.instance;
            int index = UnityEngine.Random.Range(0, im.itemList.Count - 1);
            int newItemID = im.itemList[index];
            newBox.contents.Add(newItemID);
            Instantiate(im.items[newItemID],position,Quaternion.identity);
        }
    }
}
