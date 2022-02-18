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
   private int score;
   public static int coinCount;
   public Text textScore;
   public Text coinCollected;

   void Start()
   {
      path1 = new Vector2(9.3f, -0.75f);
      path2 = new Vector2(9.3f, -2f);
      path3 = new Vector2(9.3f, -3.25f);
      StartCoroutine(FirstPathItemSpawn());
      StartCoroutine(SecondPathItemSpawn());
      StartCoroutine(ThirdPathItemSpawn());
   }

   void FixedUpdate()
   {
      score++;
      textScore.text = score.ToString();
      coinCollected.text = GameController.coinCount.ToString();

      if (score % 1000 == 0)
      {
         Item.speed -= 1f;
      }
   }

   private IEnumerator FirstPathItemSpawn()
   {
      while (true)
      {
         float randomPause = Random.Range(1f, 2.5f);
         yield return new WaitForSeconds(randomPause);
         int randomItem = Random.Range(0, items.Length);
         Instantiate(items[randomItem], path1, Quaternion.identity);
      }
   }

   private IEnumerator SecondPathItemSpawn()
   {
      while (true)
      {
         float randomPause = Random.Range(0.5f, 3.5f);
         yield return new WaitForSeconds(randomPause);
         int randomItem = Random.Range(0, items.Length);
         Instantiate(items[randomItem], path2, Quaternion.identity);
      }
   }

   private IEnumerator ThirdPathItemSpawn()
   {
      while (true)
      {
         float randomPause = Random.Range(1.5f, 3f);
         yield return new WaitForSeconds(randomPause);
         int randomItem = Random.Range(0, items.Length);
         Instantiate(items[randomItem], path3, Quaternion.identity);
      }
   }
}
