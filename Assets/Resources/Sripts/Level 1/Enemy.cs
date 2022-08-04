using UnityEngine;

public class Enemy : Item
{
   public Material matBlink;
   private Material _matDefault;
   private SpriteRenderer _spriteRend;

   void Start()
   {
      rigidbody = GetComponent<Rigidbody2D>();
      item = GetComponent<GameObject>();
      health = 3;
      _spriteRend = GetComponentInChildren<SpriteRenderer>();
      _matDefault = _spriteRend.material;
   }

   private void Update()
   {
      DestroyObject();
   }

   private void FixedUpdate()
   {
      MoveObject(rigidbody);
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag == "Player")
         Destroy(this.gameObject);
      if (other.gameObject.tag == "Bullet")
      {
         health--;
         _spriteRend.material = matBlink;
      }
      if (health == 0)
         Destroy(this.gameObject);
      else
         Invoke("ResetMaterial", .15f);
   }

   private void ResetMaterial()
   {
      _spriteRend.material = _matDefault;
   }
}
