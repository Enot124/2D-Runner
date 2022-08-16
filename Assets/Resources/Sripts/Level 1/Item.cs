using UnityEngine;

public class Item : MonoBehaviour, ICanMove
{
   #region ICanMove
   private protected float _speed = 1f;
   private protected Rigidbody2D _rigidbody;
   public Rigidbody2D Rigidbody { get => _rigidbody; }
   public float Speed { get => _speed; }
   public Vector2 Direction { get => new Vector2(-0.1f, 0); }
   #endregion ICanMove

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      MoveItem.Move(this, Direction);
   }
}


