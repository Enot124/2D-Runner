using System.Net.Mime;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
   public GameObject[] items;
   private Vector3 path1;
   private Vector3 path2;
   private Vector3 path3;
   private int score;
   public static int coinCount;
   public Text textScore;
   public Text coinCollected;

   void Start()
   {
      path1 = new Vector3(9.21f, -1.43f, 0);
      path2 = new Vector3(9.21f, -2.68f, 0);
      path3 = new Vector3(9.21f, -3.96f, 0);
      StartCoroutine(FirstPathItemSpawn());
      StartCoroutine(SecondPathItemSpawn());
      StartCoroutine(ThirdPathItemSpawn());
   }

   // Update is called once per frame
   void Update()
   {
      if (score > 4000)
      {
         Item.step += 0.5f;
      }
   }

   void FixedUpdate()
   {
      score++;
      textScore.text = score.ToString();
      coinCollected.text = GameController.coinCount.ToString();
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
