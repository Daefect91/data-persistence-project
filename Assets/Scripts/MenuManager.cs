using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        if (ScoreManager.Instance != null
            && (ScoreManager.Instance.highScorePlayerName != null && !ScoreManager.Instance.highScorePlayerName.Equals("")))
        {
            bestScoreText.text = "Best Score: " + ScoreManager.Instance.highScorePlayerName + " - " + ScoreManager.Instance.highScore;
        }
    }

    public void StartGame()
    {
        ScoreManager.Instance.playerName = playerNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        ScoreManager.Instance.SaveHighScoreData();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
