using UnityEngine;

public class Box : Item
{
   void Start()
   {
      rigidbody = GetComponent<Rigidbody2D>();
      item = GetComponent<GameObject>();
   }

   private void Update()
   {
      DestroyObject();
   }

   private void FixedUpdate()
   {
      MoveObject(rigidbody);
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag == "Player")
         GameController.CoinCount += 10;
      else if (other.gameObject.tag == "Bullet")
         GameController.CoinCount += 20;

      Destroy(this.gameObject);
   }
}