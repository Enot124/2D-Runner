using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : Item
{
   public static bool Death;
   public GameObject deathScreen;
   [SerializeField] private Image[] hearts;
   [SerializeField] private Sprite aliveHeart;
   [SerializeField] private Sprite deadHeart;
   private int _lives = 3;
   private int Raw = 0;
   private float step = 5f;
   private Animator _animator;


   private void Awake()
   {
      Death = false;
      deathScreen.SetActive(false);
      _animator = GetComponent<Animator>();
   }

   void Start()
   {
      direction = transform.position;
      health = _lives;
   }

   void Update()
   {
      if (!Death)
      {
         if (SwipeController.swipeUp && Raw < 1)
         {
            direction.y += 1.25f;
            Raw++;
         }

         if (SwipeController.swipeDown && Raw > -1)
         {
            direction.y -= 1.25f;
            Raw--;
         }

         transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * step);

         if (health > _lives)
            health = _lives;
         for (int i = 0; i < hearts.Length; i++)
         {
            if (i < health)
               hearts[i].sprite = aliveHeart;
            else
               hearts[i].sprite = deadHeart;
         }
      }
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.tag != "Box" && other.gameObject.tag != "Bullet")
         GetDamage();
   }

   public void GetDamage()
   {
      health--;
      if (health == 0)
         Die();
   }

   private void Die()
   {
      Death = true;
      _animator.SetBool("isDead", true);
      foreach (var h in hearts)
      {
         h.sprite = deadHeart;
      }

      if (!deathScreen.activeSelf)
      {
         Speed = 0;
         StartCoroutine(HitCoolDown());
         deathScreen.SetActive(true);

      }
   }


   private IEnumerator HitCoolDown()
   {
      yield return new WaitForSeconds(0.4f);
   }
}
