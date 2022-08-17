using UnityEngine;
using TMPro;

public class ScoreCountGUI : MonoBehaviour
{
   private const int SCORE_STAGE = 10000;
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

   private void Update()
   {
      if (!_isDied)
         AddScore();
   }

   private void AddScore()
   {
      _score++;
      _textScore.text = _score.ToString();

      if (_score % SCORE_STAGE == 0)
      {
         GlobalEventManager.SendScoreAchieved();
      }

      if (_score > _highscore)
         ChangeHighScore();
   }

   private void ChangeHighScore()
   {
      _highscore = _score;
      _textHighscore.text = "Highscore: " + _highscore.ToString();
   }

   private void StopScore()
   {
      _isDied = true;
   }
}
