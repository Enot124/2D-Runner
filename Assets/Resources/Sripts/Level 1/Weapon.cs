using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
   public Transform shot;
   public GameObject bullet;
   public Text ammoCount;
   public static int ammo;
   private int _fullAmmo = 15;

   private void Awake()
   {
      ammo = 0;
   }
   void Update()
   {
      if (SwipeController.isTouch && !Player.Death)
      {
         TryShoot();
      }

      if (ammo > _fullAmmo)
      {
         ammo = _fullAmmo;
      }

      if (ammo < 0)
      {
         ammo = 0;
      }

      ammoCount.text = ammo + "/" + _fullAmmo;
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
