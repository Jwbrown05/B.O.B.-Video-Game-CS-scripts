using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene2 : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    [SerializeField] private List<Scene> _sceneList;
    public Scene SceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            triggerActive = true;
            Invoke("LoadNextSceneWithDelay", 5f); // Invoke LoadNextSceneWithDelay after 5 seconds
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code, if needed
    }

    private void LoadNextSceneWithDelay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}