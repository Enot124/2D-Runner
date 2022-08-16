using UnityEngine;

public class PlayerCollide : MonoBehaviour, ICollide
{
   private Player _player;

   private void Start()
   {
      _player = GetComponent<Player>();
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      var colliderGameObject = other.collider.gameObject;
      if (colliderGameObject.TryGetComponent(out IItem item))
         item.Accept(this);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      var colliderGameObject = other.gameObject;
      if (colliderGameObject.TryGetComponent(out IItem item))
         item.Accept(this);
   }

   public void Visit(Ammo ammo)
   {
      GlobalEventManager.SendAmmoPickedUp();
      Destroy(ammo.gameObject);
   }
   public void Visit(Box box)
   {
      GlobalEventManager.SendBoxCollide();
      Destroy(box.gameObject);
   }
   public void Visit(Coin coin)
   {
      GlobalEventManager.SendCoinPickedUp();
      Destroy(coin.gameObject);
   }
   public void Visit(Enemy enemy)
   {
      Destroy(enemy.gameObject);
      _player.TakeDamage();
   }
   public void Visit(Stone stone)
   {
      Destroy(stone.gameObject);
      _player.TakeDamage();
   }
}