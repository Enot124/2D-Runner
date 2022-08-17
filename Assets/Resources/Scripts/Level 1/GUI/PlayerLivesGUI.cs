using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesGUI : MonoBehaviour
{
   [SerializeField] private Player _player;
   [SerializeField] private Image[] hearts;
   [SerializeField] private Sprite aliveHeart;
   [SerializeField] private Sprite deadHeart;

   private void Awake()
   {
      GlobalEventManager.OnHealthChanged += SetLives;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnHealthChanged -= SetLives;
   }

   private void SetLives()
   {
      for (int i = hearts.Length; i > 0; i--)
      {
         if (i > _player.Lives)
            hearts[i - 1].sprite = deadHeart;
         else
            hearts[i - 1].sprite = aliveHeart;
      }
   }
}
