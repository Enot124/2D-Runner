using UnityEngine;

public class Enemy : Item, IHaveHealth, IItem
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
      if (_lives <= 0)
         Die();
      else
         Invoke("ResetMaterial", .15f);
   }
   public void Die()
   {
      Destroy(this.gameObject);
   }

   public void Accept(ICollide collide) => collide.Visit(this);
}
