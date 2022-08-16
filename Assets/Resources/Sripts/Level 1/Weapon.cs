using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
   public Transform shot;
   public GameObject bullet;

   public static int ammo;
   private int _fullAmmo = 15;

   private void Awake()
   {
      ammo = 0;
   }
   void Update()
   {
      if (SwipeController.isTouch)
      {
         TryShoot();
      }

      if (ammo > _fullAmmo)
      {
         ammo = _fullAmmo;
      }


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
