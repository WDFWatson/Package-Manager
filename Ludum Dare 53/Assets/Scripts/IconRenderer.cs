using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconRenderer : MonoBehaviour
{
    public Image icon;
    private List<Image> currentIcons = new List<Image>();

    public void Start()
    {
        ItemManager.instance.setIllegalEvent += RenderIcons;

    }

    public void RenderIcons()
    {
        foreach (var oldIcon in currentIcons)
        {
            Destroy(oldIcon.gameObject);
        }
        currentIcons.Clear();
        foreach (var itemID in ItemManager.instance.illegalItems)
        {
            Image newIcon = Instantiate(icon, transform) as Image;
            newIcon.sprite = ItemManager.instance.items[itemID].spriteRenderer.sprite;
            currentIcons.Add(newIcon);
        }
    }
}
