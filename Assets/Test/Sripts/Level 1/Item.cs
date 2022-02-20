using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   public static float speed;
   public GameObject item;
   public Vector2 direction;
   public int health;
   public Rigidbody2D rb;
   public void MoveObject(Rigidbody2D rb)
   {
      rb.velocity = transform.right * speed;
   }

   public void DestroyObject()
   {
      if (transform.position.x < -15.5f)
         Destroy(this.gameObject);
   }
}


