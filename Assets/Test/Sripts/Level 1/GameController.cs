using System.Net.Mime;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
   public GameObject[] items;
   //public GameObject path1, path2, path3;
   private Vector2 path1, path2, path3;
   private int score, highscore;
   public static int coinCount;
   public Text textScore, coinCollected, textHighscore;

   private void Awake()
   {
      Reset();
      if (PlayerPrefs.HasKey("Save score"))
         highscore = PlayerPrefs.GetInt("Save score");
   }

   void Start()
   {
      path1 = new Vector2(15f, -0.75f);
      path2 = new Vector2(15f, -2f);
      path3 = new Vector2(15f, -3.25f);
      StartCoroutine(FirstPathItemSpawn());
      StartCoroutine(SecondPathItemSpawn());
      StartCoroutine(ThirdPathItemSpawn());
   }

   void FixedUpdate()
   {
      if (Item.speed != 0)
      {
         AddScore();
         textScore.text = score.ToString();
         textHighscore.text = "Highscore: " + highscore.ToString();
         coinCollected.text = GameController.coinCount.ToString();

         if (score % 1000 == 0)
         {
            Item.speed -= 1f;
         }
      }
   }

   private IEnumerator FirstPathItemSpawn()
   {
      while (Item.speed != 0)
      {
         float randomPause = Random.Range(1f, 2.5f);
         yield return new WaitForSeconds(randomPause);
         CreateObject(path1);
      }
   }

   private IEnumerator SecondPathItemSpawn()
   {
      while (Item.speed != 0)
      {
         float randomPause = Random.Range(0.5f, 3.5f);
         yield return new WaitForSeconds(randomPause);
         CreateObject(path2);
      }
   }

   private IEnumerator ThirdPathItemSpawn()
   {
      while (Item.speed != 0)
      {
         float randomPause = Random.Range(1.5f, 3f);
         yield return new WaitForSeconds(randomPause);
         CreateObject(path3);
      }
   }

   private void AddScore()
   {
      score++;
      HighScore();
   }

   private void HighScore()
   {
      if (score > highscore)
         highscore = score;

      PlayerPrefs.SetInt("Save score", highscore);
   }

   private void Reset()
   {
      Item.speed = -5f;
      score = coinCount = 0;
   }

   private void CreateObject(Vector2 path)
   {
      int randomItem = Random.Range(0, 101);

      if (randomItem > 0 && randomItem < 26) //Stone
         Instantiate(items[0], path, Quaternion.identity);

      if (randomItem > 25 && randomItem < 61) //Coin
         Instantiate(items[1], path, Quaternion.identity);

      if (randomItem > 60 && randomItem < 93) // Snake
         Instantiate(items[2], path, Quaternion.identity);

      if (randomItem > 92 && randomItem < 96) //Box
         Instantiate(items[3], path, Quaternion.identity);

      if (randomItem > 95 && randomItem < 101) //Ammo
         Instantiate(items[4], path, Quaternion.identity);
   }
}
