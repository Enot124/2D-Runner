using UnityEngine;

public class Weapon : MonoBehaviour
{
   private const int AMMO_COUNT = 5;
   internal readonly int _fullAmmo = 20;
   internal int _ammo = 0;
   [SerializeField] private Transform _shot;
   [SerializeField] private GameObject _bullet;

   private void Start()
   {
      GlobalEventManager.OnAmmoPickedUp += PickUpAmmo;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnAmmoPickedUp -= PickUpAmmo;
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
}
