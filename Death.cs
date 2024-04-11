using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    public GameObject Player;
    public GameObject WaveSpawner;
    public GameObject Earth2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
        {
         PlayerDied();
          
        }
        }
    // Update is called once per frame
    private void PlayerDied() 
    {
        LevelManger.instance.GameOver();
        gameObject.SetActive(false);
        Destroy(Player);
        Destroy(WaveSpawner);
        Destroy(Earth2);
    }
}
