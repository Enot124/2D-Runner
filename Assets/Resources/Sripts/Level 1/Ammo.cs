using UnityEngine;

public class Ammo : Item
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
         Weapon.ammo += 5;
         Destroy(this.gameObject);
      }
   }
}
