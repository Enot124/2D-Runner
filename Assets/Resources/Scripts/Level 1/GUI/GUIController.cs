using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIController : MonoBehaviour
{
   private int _score;
   private int _highscore;
   private int _coinCount;

   [SerializeField] private TextMeshProUGUI _textScore;
   [SerializeField] private TextMeshProUGUI _textCoin;
   [SerializeField] private TextMeshProUGUI _textHighscore;
   [SerializeField] private TextMeshProUGUI _textAmmo;
   [SerializeField] private GameObject _deathScreen;

   [SerializeField] private Image[] hearts;
   [SerializeField] private Sprite aliveHeart;
   [SerializeField] private Sprite deadHeart;
   /*foreach (var h in hearts)
{
   h.sprite = deadHeart;
}*/

   //ammoCount.text = ammo + "/" + _fullAmmo;

   /*   for (int i = 0; i<hearts.Length; i++)
   {
      if (i<health)
         hearts[i].sprite = aliveHeart;
      else
         hearts[i].sprite = deadHeart;
   }*/

   /*if (!deathScreen.activeSelf)
      {
         Speed = 0;
         StartCoroutine(HitCoolDown());
         deathScreen.SetActive(true);

      }*/

   private void Awake()
   {
      GlobalEventManager.OnCoinPickedUp += AddCoin;
   }
   private void OnDisable()
   {
      GlobalEventManager.OnCoinPickedUp -= AddCoin;
   }

   private void Update()
   {
      AddScore();
   }

   private void AddCoin()
   {
      _coinCount++;
      _textCoin.text = _coinCount.ToString();
   }

   private void AddScore()
   {
      _score++;
      _textScore.text = _score.ToString();
      HighScore();
   }

   private void HighScore()
   {
      if (_score > _highscore)
      {
         _highscore = _score;
         _textHighscore.text = "Highscore: " + _highscore.ToString();
      }
   }
}
