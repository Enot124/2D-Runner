using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Item
{
   private int lives = 3;
   private int Raw = 0;
   private float step = 5f;
   [SerializeField] private Image[] hearts;
   [SerializeField] private Sprite aliveHeart;
   [SerializeField] private Sprite deadHeart;
   public GameObject deathScreen;
   private bool death;

   private void Awake()
   {
      deathScreen.SetActive(false);
   }

   void Start()
   {
      direction = transform.position;
      health = lives;
   }

   // Update is called once per frame
   void Update()
   {
      if (!death)
      {
         if (SwipeController.swipeUp && Raw < 1)  //Input.GetKeyDown(KeyCode.UpArrow)
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

         if (health > lives)
            health = lives;
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
      {
         death = true;
         foreach (var h in hearts)
         {
            h.sprite = deadHeart;
         }

         if (!deathScreen.activeSelf)
         {
            speed = 0;
            StartCoroutine(HitCoolDown());
            deathScreen.SetActive(true);

         }
      }
   }

   private IEnumerator HitCoolDown()
   {
      yield return new WaitForSeconds(0.4f);
   }
}
