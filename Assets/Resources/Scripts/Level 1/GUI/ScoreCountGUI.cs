using UnityEngine;
using TMPro;

public class ScoreCountGUI : MonoBehaviour
{
   public static float s_speed = 1f;
   private const int SCORE_STAGE = 1000;
   private int _score;
   private int _highscore;
   private bool _isDied;
   [SerializeField] private TextMeshProUGUI _textScore;
   [SerializeField] private TextMeshProUGUI _textHighscore;

   private void Awake()
   {
      GlobalEventManager.OnPlayerDied += StopScore;
   }

   private void OnDisable()
   {
      GlobalEventManager.OnPlayerDied -= StopScore;
   }

   private void FixedUpdate()
   {
      if (!_isDied)
         AddScore();

      if (_score % SCORE_STAGE == 0)
      {
         BoostSpeed();
      }
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

   private void BoostSpeed()
   {
      s_speed += 0.1f;
   }

   private void StopScore()
   {
      _isDied = true;
   }
}
