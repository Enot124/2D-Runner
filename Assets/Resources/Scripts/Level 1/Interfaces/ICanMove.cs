using UnityEngine;

public interface ICanMove
{
   public Rigidbody2D Rigidbody { get; }
   public float Speed { get; }
   public Vector2 Direction { get; }
}