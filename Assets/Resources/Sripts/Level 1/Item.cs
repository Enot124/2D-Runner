using UnityEngine;

public class Item : MonoBehaviour, ICanMove
{
   #region ICanMove
   public Rigidbody2D Rigidbody { get => _rigidbody; }
   public float Speed { get => _speed; }
   private protected float _speed = 5f;
   private protected Rigidbody2D _rigidbody;
   #endregion ICanMove

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
   }
}


