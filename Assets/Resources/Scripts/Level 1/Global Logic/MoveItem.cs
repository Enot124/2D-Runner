using UnityEngine;

public class MoveItem
{
   public static float s_speed = 5f;
   public static void SubEvent()
   {
      GlobalEventManager.OnBoostedSpeed += BoostSpeed;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnBoostedSpeed -= BoostSpeed;
   }

   public static void Move(ICanMove item, Vector2 direction)
   {
      item.Rigidbody.MovePosition(item.Rigidbody.position
           + direction * s_speed * Time.fixedDeltaTime);
   }


   private static void BoostSpeed()
   {
      s_speed *= 1.1f;
      Debug.Log("Speed: " + s_speed);
   }
}
