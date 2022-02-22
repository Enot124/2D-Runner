using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Item
{
   public Material matBlink;
   private Material matDefault;
   private SpriteRenderer spriteRend;
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      item = GetComponent<GameObject>();
      health = 3;
      spriteRend = GetComponentInChildren<SpriteRenderer>();
      matDefault = spriteRend.material;
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
      if (other.gameObject.tag == "Bullet")
      {
         health--;
         spriteRend.material = matBlink;
      }
      if (health == 0)
         Destroy(this.gameObject);
      else
         Invoke("ResetMaterial", .15f);
   }

   private void ResetMaterial()
   {
      spriteRend.material = matDefault;
   }
}
