using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUIManager : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    public void GameStart(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
