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

   private void Awake()
   {
      ammo = 0;
   }
   void Update()
   {
      if (SwipeController.isTouch && !Player.death)
      //if (Input.touchCount > 0 || Input.GetMouseButtonDown(0) && SwipeController.isTouch && ammo > 0)  //Input.GetKeyDown(KeyCode.Space)
      {
         TryShoot();
      }

      if (ammo > fullAmmo)
      {
         ammo = fullAmmo;
      }

      if (ammo < 0)
      {
         ammo = 0;
      }

      ammoCount.text = ammo + "/" + fullAmmo;
   }
   private void TryShoot()
   {
      if (ammo > 0)
         Shoot();
   }

   private void Shoot()
   {
      Instantiate(bullet, shot.transform.position, shot.transform.rotation);
      ammo--;
   }
}
