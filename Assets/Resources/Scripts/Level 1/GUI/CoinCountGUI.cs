using UnityEngine;
using TMPro;

public class CoinCountGUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _textCoin;
   private const int BOX_COLLIDE = 10;
   private const int BOX_BROKE = 20;
   private int _coinCount;

   private void Awake()
   {
      GlobalEventManager.OnCoinPickedUp += AddCoin;
      GlobalEventManager.OnBoxBroke += AddBoxBrokeCoin;
      GlobalEventManager.OnBoxCollide += AddBoxCollideCoin;
      ReadKey();
   }

   private void OnDisable()
   {
      GlobalEventManager.OnCoinPickedUp -= AddCoin;
      GlobalEventManager.OnBoxBroke -= AddBoxBrokeCoin;
      GlobalEventManager.OnBoxCollide -= AddBoxCollideCoin;
      SetKey();
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

   private void ReadKey()
   {
      if (PlayerPrefs.HasKey("Coins"))
         _coinCount = PlayerPrefs.GetInt("Coins");
      _textCoin.text = _coinCount.ToString();
   }

   private void SetKey()
   {
      PlayerPrefs.SetInt("Coins", _coinCount);
   }
}
