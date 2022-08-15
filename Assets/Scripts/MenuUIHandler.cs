using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public static string playerName;
    public TextMeshProUGUI BestScoreText;

    private void Start()
    {
        SceneController.Instance.LoadScore();
        if(SceneController.BestScore > 0)
        {
            BestScoreText.text = "Best Score: " + SceneController.BestPlayer + " - " + SceneController.BestScore;
        }


    }

    public void StartNew()
    {
        playerName = GameObject.Find("Player Name").GetComponent<TextMeshProUGUI>().text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneController.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
