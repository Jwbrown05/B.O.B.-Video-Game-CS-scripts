using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Blackness : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    public GameObject MyPrefab;
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
        if (triggerActive)
    {
       Instantiate(MyPrefab, new Vector3 (0f ,0f, 0), MyPrefab.transform.rotation);
    }
    }
}
