using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public Transform shot;
   public GameObject bullet;

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         Shoot();
      }
   }

   private void Shoot()
   {
      Instantiate(bullet, shot.transform.position, shot.transform.rotation);
   }
}
