using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUIManager : MonoBehaviour
{
    public void GameStart(string str)
    {
        SceneManager.LoadScene(str);
    }
}
