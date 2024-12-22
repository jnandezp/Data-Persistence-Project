using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_Text firstPlaceText;
    public TMP_Text secondPlaceText;
    public TMP_Text thirdPlaceText;

    private void Awake()
    {
        // Mostrar los puntajes cargados
        for (int i = 0; i < GameManager.Instance.saveData.Scores.Count; i++)
        {
            Debug.Log("Score Item: " + GameManager.Instance.saveData.Scores[i].Name + " Score: " + GameManager.Instance.saveData.Scores[i].Score);
            switch (i)
            {
                case 0:
                    firstPlaceText.text = GameManager.Instance.saveData.Scores[i].Name + ": " + GameManager.Instance.saveData.Scores[i].Score;
                    firstPlaceText.gameObject.SetActive(true);
                    break;
                case 1:
                    secondPlaceText.text = GameManager.Instance.saveData.Scores[i].Name + ": " + GameManager.Instance.saveData.Scores[i].Score;
                    secondPlaceText.gameObject.SetActive(true);
                    break;
                case 2:
                    thirdPlaceText.text = GameManager.Instance.saveData.Scores[i].Name + ": " + GameManager.Instance.saveData.Scores[i].Score;
                    thirdPlaceText.gameObject.SetActive(true);
                    break;
            }
        }
    }

    public void StartNewGame()
    {
        GameManager.Instance.Name = nameInputField.text;
        GameManager.Instance.Score = 0;
        
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                    Application.Quit();
        #endif
    }
}
