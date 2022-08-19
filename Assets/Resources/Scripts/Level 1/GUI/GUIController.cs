using UnityEngine;

public class GUIController : MonoBehaviour
{
   [SerializeField] private GameObject _deathScreen;
   private const string DEATH_METOD_NAME = "SetDeathScreen";

   private void Awake()
   {
      GlobalEventManager.OnPlayerDied += ShowDeathScreen;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnPlayerDied -= ShowDeathScreen;
   }
   private void ShowDeathScreen()
   {
      Invoke(DEATH_METOD_NAME, 2f);
   }

   private void SetDeathScreen()
   {
      _deathScreen.SetActive(true);
   }
}
