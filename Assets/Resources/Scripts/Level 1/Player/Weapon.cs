using UnityEngine;

public class Weapon : MonoBehaviour
{
   [SerializeField] private Transform _shot;
   [SerializeField] private GameObject _bullet;
   private const int AMMO_COUNT = 5;
   internal readonly int _fullAmmo = 20;
   internal int _ammo = 0;

   private void Start()
   {
      GlobalEventManager.OnAmmoPickedUp += PickUpAmmo;
      GlobalEventManager.OnPlayerDied += StopShoot;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnAmmoPickedUp -= PickUpAmmo;
      GlobalEventManager.OnPlayerDied -= StopShoot;
   }

   void Update()
   {
      if (SwipeController.isTouch)
      {
         TryShoot();
      }
   }

   private void PickUpAmmo()
   {
      _ammo += AMMO_COUNT;
      if (_ammo > _fullAmmo)
         _ammo = _fullAmmo;

      GlobalEventManager.SendAmmoChanged();
   }

   private void TryShoot()
   {
      if (_ammo > 0)
         Shoot();
   }

   private void Shoot()
   {
      Instantiate(_bullet, _shot.transform.position, _shot.transform.rotation);
      _ammo--;
      GlobalEventManager.SendAmmoChanged();
   }

   private void StopShoot()
   {
      Destroy(this);
   }
}
