using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private float speed = 13f;
   private Rigidbody2D rb;
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
   }

   void Update()
   {
      rb.velocity = transform.right * speed;

      if (transform.position.x > 9.3f)
         Destroy(this.gameObject);

   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag != "Help" && other.gameObject.tag != "Player")
         Destroy(this.gameObject);
   }
}
