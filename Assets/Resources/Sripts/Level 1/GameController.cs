using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
   public static int CoinCount;
   public Text textScore, coinCollected, textHighscore;
   public GameObject[] items;
   private Vector2 _path1, _path2, _path3;
   private int _score, _highscore;

   private void Awake()
   {
      Reset();
      if (PlayerPrefs.HasKey("Save score"))
         _highscore = PlayerPrefs.GetInt("Save score");
   }

   void Start()
   {
      _path1 = new Vector2(15f, -0.75f);
      _path2 = new Vector2(15f, -2f);
      _path3 = new Vector2(15f, -3.25f);
      StartCoroutine(FirstPathItemSpawn());
      StartCoroutine(SecondPathItemSpawn());
      StartCoroutine(ThirdPathItemSpawn());
   }

   void FixedUpdate()
   {
      if (Item.Speed != 0)
      {
         AddScore();
         textScore.text = _score.ToString();
         textHighscore.text = "Highscore: " + _highscore.ToString();
         coinCollected.text = GameController.CoinCount.ToString();

         if (_score % 1000 == 0)
         {
            Item.Speed -= 1f;
         }
      }
   }

   private IEnumerator FirstPathItemSpawn()
   {
      while (Item.Speed != 0)
      {
         float randomPause = Random.Range(1f, 2.5f);
         yield return new WaitForSeconds(randomPause);
         CreateObject(_path1);
      }
   }

   private IEnumerator SecondPathItemSpawn()
   {
      while (Item.Speed != 0)
      {
         float randomPause = Random.Range(0.5f, 3.5f);
         yield return new WaitForSeconds(randomPause);
         CreateObject(_path2);
      }
   }

   private IEnumerator ThirdPathItemSpawn()
   {
      while (Item.Speed != 0)
      {
         float randomPause = Random.Range(1.5f, 3f);
         yield return new WaitForSeconds(randomPause);
         CreateObject(_path3);
      }
   }

   private void AddScore()
   {
      _score++;
      HighScore();
   }

   private void HighScore()
   {
      if (_score > _highscore)
         _highscore = _score;

      PlayerPrefs.SetInt("Save score", _highscore);
   }

   private void Reset()
   {
      Item.Speed = -5f;
      _score = CoinCount = 0;
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
