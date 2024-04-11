using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class RocketMoveUp : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private bool triggerActive = false;
    [SerializeField] private List<Scene> _sceneList;
     public Scene SceneName;
    // Start is called before the first frame update
    void Start()
    {
    }
     
        void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.gameObject.CompareTag("Player"))
           {
            triggerActive = true;
             Invoke("LoadNextSceneWithDelay", 10f);   
           }
     }
    private void Update()
    {
         if (triggerActive)
         {
                 Destroy(Player);
                transform.Translate(Vector3.up * Time.deltaTime, Space.World);
         }
    }
    private void LoadNextSceneWithDelay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}