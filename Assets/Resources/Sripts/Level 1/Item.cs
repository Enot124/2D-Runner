using UnityEngine;

public class Item : MonoBehaviour
{
   public static float Speed;
   protected GameObject item;
   protected Vector2 direction;
   protected int health;
   protected Rigidbody2D rigidbody;

   public void MoveObject(Rigidbody2D rb)
   {
      rb.velocity = transform.right * Speed;
   }

   public void DestroyObject()
   {
      if (transform.position.x < -15.5f)
         Destroy(this.gameObject);
   }
}


