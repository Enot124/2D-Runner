using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Item
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
         Destroy(this.gameObject);
   }
}
