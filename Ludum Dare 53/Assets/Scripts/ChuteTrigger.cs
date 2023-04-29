using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuteTrigger : MonoBehaviour
{
    public bool isLegalChute;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<BoxItem>(out BoxItem item))
        {
            Destroy(item.gameObject);
        }
        if (other.TryGetComponent<Box>(out Box box))
        {
            ScoreManager.instance.Score(box.contents,isLegalChute);
            Destroy(box.gameObject);
        }
    }
}
