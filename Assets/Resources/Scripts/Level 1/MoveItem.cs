using UnityEngine;

public class MoveItem
{
   private static float _speed = 1f;

   private void Awake()
   {
      GlobalEventManager.OnScoreAchieved += BoostSpeed;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnScoreAchieved -= BoostSpeed;
   }

   private void BoostSpeed()
   {
      _speed *= 3.2f;
      Debug.Log(_speed);
   }

   public static void Move(ICanMove item, Vector2 direction)
   {
      item.Rigidbody.MovePosition(item.Rigidbody.position
           + direction * _speed);
   }

}
