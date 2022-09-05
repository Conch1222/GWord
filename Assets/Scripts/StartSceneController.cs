using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public void onStartButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void onExitButtonClicked()
    {
        Application.Quit();
    }

    public void onScoreBoardButtonClicked()
    {
        SceneManager.LoadScene("ScoreBoardScene");
    }
}
