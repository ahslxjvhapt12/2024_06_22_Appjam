using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUIManager : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;

    [SerializeField] GameObject brain;
    [SerializeField] Canvas canvas;
    public void GameStart()
    {

        canvas.gameObject.SetActive(false);

        brain.transform.DOMove(Vector3.zero, 1f);
        brain.transform.DOScale(40, 1f);
        Invoke("LoadScene", 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("PlayScene");
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
