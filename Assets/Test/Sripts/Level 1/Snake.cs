using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Item
{
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      item = GetComponent<GameObject>();
      health = 3;
   }
   private void Update()
   {
      DestroyObject();
      if (health == 0)
         Destroy(this.gameObject);
   }
   private void FixedUpdate()
   {
      MoveObject(rb);
   }
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag == "Player")
         Destroy(this.gameObject);
      if (other.gameObject.tag == "Bullet")
         health--;
   }
}
