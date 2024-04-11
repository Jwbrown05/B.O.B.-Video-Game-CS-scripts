using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AutoScroll : MonoBehaviour
{
    float speed =200f;
    float textPosBegin =-8000f;
    float boundaryTextEnd =8865f;

    RectTransform myGorectTransform;
    public GameObject mainText;
    [SerializeField] bool isLooping = false;

    // Start is called before the first frame update
    void Start()
    {
       myGorectTransform =gameObject.GetComponent<RectTransform>(); 
       StartCoroutine(AutoScrollText());  
    }
     
     IEnumerator AutoScrollText()
     {
        while(myGorectTransform.localPosition.y< boundaryTextEnd)
            {
                 myGorectTransform.Translate(Vector3.up*speed*Time.deltaTime);
                 yield return null;
            }
     }
}
