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
    
    public void StartNewGame()
    {
        GameManager.Instance.Name = nameInputField.text;
        GameManager.Instance.Score = 0;
        
        /*GameManager.Instance.LoadScore();
        // Mostrar los puntajes cargados
        foreach (var score in GameManager.Instance.saveData.Scores)
        {
            Debug.Log($"Jugador: {score.Name}, Puntuación: {score.Score}");
        }*/
        
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
