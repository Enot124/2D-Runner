using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Item
{
   void Start()
   {
      direction = transform.position;
      item = GetComponent<GameObject>();
   }
   private void Update()
   {
      DestroyObject();
   }
   private void FixedUpdate()
   {
      MoveObject();
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag == "Player")
         GameController.coinCount += 10;
      else
         GameController.coinCount += 20;

      Destroy(this.gameObject);
   }
}