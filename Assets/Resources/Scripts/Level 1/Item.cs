using UnityEngine;

public class Item : MonoBehaviour, ICanMove
{
   #region ICanMove
   private protected Rigidbody2D _rigidbody;
   public Rigidbody2D Rigidbody { get => _rigidbody; }
   private protected Vector2 _direction = new Vector2(-0.1f, 0);
   public Vector2 Direction { get => _direction; set => _direction = value; }
   #endregion ICanMove

   private void Awake()
   {
      GlobalEventManager.OnPlayerDied += StopMove;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnPlayerDied -= StopMove;
   }

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      MoveItem.Move(this, Direction);
   }

   private void StopMove()
   {
      _direction = new Vector2(0, 0);
   }
}


