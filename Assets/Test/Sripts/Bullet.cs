using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private float speed = 10f;
   private Rigidbody2D rb;
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
   }

   // Update is called once per frame
   void Update()
   {
      rb.velocity = transform.right * speed;
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag != "Help" && other.gameObject.tag != "Player")
         Destroy(this.gameObject);
   }
}
