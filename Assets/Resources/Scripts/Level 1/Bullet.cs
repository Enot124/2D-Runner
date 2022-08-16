using UnityEngine;

public class Bullet : MonoBehaviour
{
   private float _speed = 13f;
   private Rigidbody2D _rigidbody;

   void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
   }

   void Update()
   {
      _rigidbody.velocity = transform.right * _speed;

      if (transform.position.x > 9.3f)
         Destroy(this.gameObject);

   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag != "Help" && other.gameObject.tag != "Player")
         Destroy(this.gameObject);
   }
}
