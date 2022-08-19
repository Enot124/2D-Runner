using UnityEngine;

public class Player : MonoBehaviour, IHaveHealth
{
   private int _lives = 3;
   private Animator _animator;
   public int Lives { get => _lives; set => _lives = value; }

   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }

   public void TakeDamage()
   {
      _lives--;
      GlobalEventManager.SendHealthChanged();
      if (_lives == 0)
         Die();
   }

   public void Die()
   {
      _animator.SetBool("isDead", true);
      GlobalEventManager.SendPlayerDied();
   }

}
