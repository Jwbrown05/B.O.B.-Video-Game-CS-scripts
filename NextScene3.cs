using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene3 : MonoBehaviour

{
     [SerializeField] private bool triggerActive = false;
     [SerializeField] private List<Scene> _sceneList;
     public Scene SceneName;
   
    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
        {
         triggerActive = true;
        }     
        }
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
    {
   SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }
    }
}