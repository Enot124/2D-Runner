using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesGUI : MonoBehaviour
{
   [SerializeField] private Player _player;
   [SerializeField] private Image[] _hearts;
   [SerializeField] private Sprite _aliveHeart;
   [SerializeField] private Sprite _deadHeart;

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
      for (int i = _hearts.Length; i > 0; i--)
      {
         if (i > _player.Lives)
            _hearts[i - 1].sprite = _deadHeart;
         else
            _hearts[i - 1].sprite = _aliveHeart;
      }
   }
}
