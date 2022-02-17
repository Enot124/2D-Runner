using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : Item
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

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         Destroy(this.gameObject);
         GameController.coinCount++;
      }
   }
}
