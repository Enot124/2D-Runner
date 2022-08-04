using UnityEngine;

public class Coin : Item
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

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         Destroy(this.gameObject);
         GameController.CoinCount++;
      }
   }
}
