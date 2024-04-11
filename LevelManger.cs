using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
   public static LevelManger instance;
   public static LevelManger manager;
   public static int scoreValue = 0;
    public int score;
    public TextMeshProUGUI scoreText;
   private void Awake() 
   {
    if (LevelManger.instance == null) instance = this;
    else Destroy(gameObject);
   }

   public void GameOver()
   {
      UIManager _ui = GetComponent<UIManager>();
     if (_ui != null)
     {
        _ui.ToggleDeathPanel();
     }
   }
   
    // Start is called before the first frame update
    public void IncreaseScore(int amount) 
    {
      score += amount;  
      scoreText.text = "Score: " + score.ToString();
    }
}
