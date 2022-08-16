using System.Collections;
using UnityEngine;

public class InstantiateItems : MonoBehaviour
{
   public GameObject[] items;
   [SerializeField] private Transform _path1;
   [SerializeField] private Transform _path2;
   [SerializeField] private Transform _path3;

   void Start()
   {
      StartCoroutine(FirstPathItemSpawn());
      StartCoroutine(SecondPathItemSpawn());
      StartCoroutine(ThirdPathItemSpawn());
   }

   private IEnumerator FirstPathItemSpawn()
   {
      while (true)
      {
         float randomPause = Random.Range(1f, 2.5f);
         yield return new WaitForSeconds(randomPause);
         CreateObject(_path1.position);
      }
   }

   private IEnumerator SecondPathItemSpawn()
   {
      while (true)
      {
         float randomPause = Random.Range(0.5f, 3.5f);
         yield return new WaitForSeconds(randomPause);
         CreateObject(_path2.position);
      }
   }

   private IEnumerator ThirdPathItemSpawn()
   {
      while (true)
      {
         float randomPause = Random.Range(1.5f, 3f);
         yield return new WaitForSeconds(randomPause);
         CreateObject(_path3.position);
      }
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
