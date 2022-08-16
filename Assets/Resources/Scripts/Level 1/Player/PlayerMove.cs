using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   [SerializeField] private Transform[] _raws;
   private int _currentRaw = 1;
   private float _speed = 5f;

   void Update()
   {
      if (SwipeController.swipeUp && (_currentRaw > 0))
      {
         _currentRaw--;
      }

      if (SwipeController.swipeDown && (_currentRaw < 2))
      {
         _currentRaw++;
      }
      transform.position = Vector3.MoveTowards(transform.position, _raws[_currentRaw].position, Time.deltaTime * _speed);
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
   }
}