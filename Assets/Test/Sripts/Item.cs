using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   public static float step = 0.1f;
   public GameObject item;
   public Vector2 direction;
   public int health;
   public void MoveObject()
   {
      direction.x -= step;
      transform.position = direction;
   }

   public void DestroyObject()
   {
      if (direction.x < -9.5f)  //3.3
         Destroy(this.gameObject);
   }
}


