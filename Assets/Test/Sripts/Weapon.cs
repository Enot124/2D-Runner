using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
   public Transform shot;
   public GameObject bullet;
   public Text ammoCount;
   public static int ammo;
   private int fullAmmo = 15;

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
      {
         Shoot();
      }

      if (ammo > fullAmmo)
      {
         ammo = fullAmmo;
      }

      ammoCount.text = ammo + "/" + fullAmmo;
   }

   private void Shoot()
   {
      Instantiate(bullet, shot.transform.position, shot.transform.rotation);
      ammo--;
   }
}
