using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Item
{
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      item = GetComponent<GameObject>();
   }
   private void Update()
   {
      DestroyObject();
   }
   private void FixedUpdate()
   {
      MoveObject(rb);
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag == "Player")
         GameController.coinCount += 10;
      else if (other.gameObject.tag == "Bullet")
         GameController.coinCount += 20;

      Destroy(this.gameObject);
   }
}