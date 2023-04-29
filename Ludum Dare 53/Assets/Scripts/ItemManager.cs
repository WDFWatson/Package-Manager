using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    [Serializable]
    public struct itemID {
        public int id;
        public BoxItem item;
    }
    [SerializeField] private itemID[] itemsArray;
    
    public int minIllegalItems = 1;
    public int maxIllegalItems = 5;
    public static ItemManager instance;
    public Dictionary<int, BoxItem> items = new Dictionary<int, BoxItem>();
    
    [HideInInspector] public List<int> itemList;
    public List<int> legalItems;
    public List<int> illegalItems;
    
    public event Action setIllegalEvent;
    private void Awake()
    {
        foreach (var itemID in itemsArray)
        {
            items.Add(itemID.id,itemID.item);
        }
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
        legalItems = new List<int>(itemList);
        int numIllegalItems = Random.Range(minIllegalItems, maxIllegalItems);
        for (int i = 0; i < numIllegalItems; i++)
        {
            int index = Random.Range(0, legalItems.Count);
            illegalItems.Add(legalItems[index]);
            legalItems.RemoveAt(index);
        }
        if (setIllegalEvent != null)
        {
            setIllegalEvent.Invoke();
        }
    }
    
}
