using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Item
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
         Destroy(this.gameObject);
   }
}
