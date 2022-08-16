using UnityEngine;

public class MoveItem
{
   public static void Move(ICanMove item, Vector2 direction)
   {
      item.Rigidbody.MovePosition(item.Rigidbody.position
           + direction * item.Speed);
   }
}
