using UnityEngine;

public class Bullet : MonoBehaviour
{
   private readonly float _speed = 13f;
   private Rigidbody2D _rigidbody;

   void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
      Destroy(this.gameObject, 5f);
   }

   void Update()
   {
      _rigidbody.velocity = transform.right * _speed;
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      var colliderGameObject = other.collider.gameObject;
      if (colliderGameObject.TryGetComponent(out Enemy enemy))
         enemy.TakeDamage();
      else if (colliderGameObject.TryGetComponent(out Box box))
         box.BrokeBox();

      Destroy(this.gameObject);
   }
}
