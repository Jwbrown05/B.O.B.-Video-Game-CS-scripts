using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
   
   void OnCollisionEnter2D(Collision2D collision)
   {
     if (collision.gameObject.CompareTag("Bullet"))
    {
       Destroy(gameObject);
      LevelManger.instance.IncreaseScore(1);
    }
    
   }
  
}
