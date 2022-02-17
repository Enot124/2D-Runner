using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Item
{
   private int lives = 3;
   private int Raw = 0;
   [SerializeField] private Image[] hearts;
   [SerializeField] private Sprite aliveHeart;
   [SerializeField] private Sprite deadHeart;
   void Start()
   {
      direction = transform.position;
      health = lives;
   }

   // Update is called once per frame
   void Update()
   {
      if (SwipeController.swipeUp && Raw < 1)  //Input.GetKeyDown(KeyCode.UpArrow)
      {
         SwitchPath(1);
      }

      if (SwipeController.swipeDown && Raw > -1)
      {
         SwitchPath(-1);
      }

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

   private void SwitchPath(int equals)
   {
      float YPos = 1.25f * equals;
      direction.y += YPos;
      transform.position = direction;
      Raw += equals;
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
         foreach (var h in hearts)
         {
            h.sprite = deadHeart;
         }
      }
   }
}
