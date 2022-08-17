using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIController : MonoBehaviour
{
   private const int BOX_COLLIDE = 10;
   private const int BOX_BROKE = 20;
   private int _score;
   private int _highscore;
   private int _coinCount;

   [SerializeField] private TextMeshProUGUI _textScore;
   [SerializeField] private TextMeshProUGUI _textCoin;
   [SerializeField] private TextMeshProUGUI _textHighscore;
   [SerializeField] private TextMeshProUGUI _textAmmo;
   [SerializeField] private Weapon _weapon;
   [SerializeField] private GameObject _deathScreen;

   [SerializeField] private Player _player;
   [SerializeField] private Image[] hearts;
   [SerializeField] private Sprite aliveHeart;
   [SerializeField] private Sprite deadHeart;

   private void Awake()
   {
      GlobalEventManager.OnCoinPickedUp += AddCoin;
      GlobalEventManager.OnHealthChanged += SetLives;
      GlobalEventManager.OnAmmoChanged += SetTextAmmo;
      GlobalEventManager.OnBoxBroke += AddBoxBrokeCoin;
      GlobalEventManager.OnBoxCollide += AddBoxCollideCoin;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnCoinPickedUp -= AddCoin;
      GlobalEventManager.OnHealthChanged -= SetLives;
      GlobalEventManager.OnAmmoChanged -= SetTextAmmo;
      GlobalEventManager.OnBoxBroke -= AddBoxBrokeCoin;
      GlobalEventManager.OnBoxCollide -= AddBoxCollideCoin;
   }

   private void Update()
   {
      AddScore();
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

   private void SetTextAmmo()
   {
      _textAmmo.text = $"{_weapon._ammo}/{_weapon._fullAmmo}";
   }

   private void AddCoin()
   {
      _coinCount++;
      _textCoin.text = _coinCount.ToString();
   }

   private void AddBoxBrokeCoin()
   {
      _coinCount += BOX_BROKE;
      _textCoin.text = _coinCount.ToString();
   }

   private void AddBoxCollideCoin()
   {
      _coinCount += BOX_COLLIDE;
      _textCoin.text = _coinCount.ToString();
   }

   private void AddScore()
   {
      _score++;
      _textScore.text = _score.ToString();

      if (_score > _highscore)
         ChangeHighScore();
   }

   private void ChangeHighScore()
   {
      _highscore = _score;
      _textHighscore.text = "Highscore: " + _highscore.ToString();
   }
}
