using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
   public static int CoinCount;
   public Text textScore, coinCollected, textHighscore;
   private int _score, _highscore;
   private GameObject _deathScreen;
   public Text ammoCount;

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
      Reset();
      if (PlayerPrefs.HasKey("Save score"))
         _highscore = PlayerPrefs.GetInt("Save score");
   }

   private void Update()
   {
      AddScore();
      textScore.text = _score.ToString();
      textHighscore.text = "Highscore: " + _highscore.ToString();
      coinCollected.text = CoinCount.ToString();
   }
   private void AddScore()
   {
      _score++;
      HighScore();
   }

   private void HighScore()
   {
      if (_score > _highscore)
         _highscore = _score;

      PlayerPrefs.SetInt("Save score", _highscore);
   }

   private void Reset()
   {
      _score = CoinCount = 0;
   }
}
