using UnityEngine;

public class Enemy : Item, IHaveHealth
{
   [SerializeField] private Material _matBlink;
   private Material _matDefault;
   private SpriteRenderer _spriteRend;
   private int _lives = 3;

   public int Lives { get => _lives; set => _lives = value; }

   void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
      _spriteRend = GetComponentInChildren<SpriteRenderer>();
      _matDefault = _spriteRend.material;
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag == "Bullet")
      {
         TakeDamage();

         if (_lives == 0)
            Die();
         else
            Invoke("ResetMaterial", .15f);
      }
   }
   private void ResetMaterial()
   {
      _spriteRend.material = _matDefault;
   }

   public void TakeDamage()
   {
      _lives--;
      _spriteRend.material = _matBlink;
   }
   public void Die()
   {
      Destroy(this.gameObject);
   }
}
