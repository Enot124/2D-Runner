using UnityEngine;
using TMPro;

public class AmmoCountGUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _textAmmo;
   [SerializeField] private Weapon _weapon;

   private void Awake()
   {
      GlobalEventManager.OnAmmoChanged += SetTextAmmo;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnAmmoChanged -= SetTextAmmo;
   }

   private void SetTextAmmo()
   {
      _textAmmo.text = $"{_weapon._ammo}/{_weapon._fullAmmo}";
   }
}
