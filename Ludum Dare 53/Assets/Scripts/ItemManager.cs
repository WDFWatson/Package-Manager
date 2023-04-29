using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    public int minIllegalItems = 1;
    public int maxIllegalItems = 5;
    public static ItemManager instance;
    public Dictionary<int, BoxItem> items;
    
    [HideInInspector] public List<int> itemList;
    public List<int> legalItems;
    public List<int> illegalItems;

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
        itemList = items.Keys.ToList();
    }

    public void SetIllegalItems()
    {
        illegalItems.Clear();
        legalItems = itemList;
        int numIllegalItems = Random.Range(minIllegalItems, maxIllegalItems);
        for (int i = 0; i < numIllegalItems; i++)
        {
            int index = Random.Range(0, legalItems.Count-1);
            illegalItems.Add(legalItems[index]);
            legalItems.RemoveAt(index);
        }
    }
    
}
