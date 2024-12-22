using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   public string Name;
   public int Score;
   private int maxScores = 3;

   private void Awake()
   {
      if (Instance != null)
      {
         Destroy(gameObject);
         return;
      }
      Instance = this;
      DontDestroyOnLoad(gameObject);
      
      GameManager.Instance.LoadScore();
   }

   [System.Serializable]
   class ItemScore
   {
      public string Name;
      public int Score;
   }
   
   [System.Serializable]
   class ListScores
   {
      public List<ItemScore> Scores = new List<ItemScore>(); // Lista de puntajes
   }
   
   private ListScores saveData = new ListScores();

   public void SaveScore()
   {
      ItemScore newScore = new ItemScore { Name = Name, Score = Score };
      saveData.Scores.Add(newScore);
      saveData.Scores.Sort((a, b) => b.Score.CompareTo(a.Score));
      
      // Mantener solo los mejores puntajes con un maximo definido en maxScores
      if (saveData.Scores.Count > maxScores)
      {
         // Eliminar el puntaje más bajo
         saveData.Scores.RemoveAt(saveData.Scores.Count - 1);
      }
      
      string json = JsonUtility.ToJson(saveData);
      File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
   }

   public void LoadScore()
   {
      string path = Application.persistentDataPath + "/savefile.json";
      if (File.Exists(path))
      {
         string json = File.ReadAllText(path);
         saveData  = JsonUtility.FromJson<ListScores>(json);
         
         // Mostrar los puntajes cargados
         foreach (var score in saveData.Scores)
         {
            Debug.Log($"Jugador: {score.Name}, Puntuación: {score.Score}");
         }
      }
   }
   
}
