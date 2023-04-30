using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour
{
    public void GameScene()
    {
        LoadManager.instance.LoadGameScene();
    }

    public void MainMenu()
    {
        LoadManager.instance.LoadMenu();
    }

    public void Guide()
    {
        LoadManager.instance.LoadGuide();
    }
}
