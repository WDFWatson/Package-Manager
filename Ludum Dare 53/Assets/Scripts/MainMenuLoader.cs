using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoader : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadManager.instance.LoadMenu();
        }
    }
}
