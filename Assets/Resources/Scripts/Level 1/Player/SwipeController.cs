using System;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
   private bool _isDraging = false;
   private Vector2 _startTouch;
   private Vector2 _swipeDelta;
   private DateTime _dtStart = DateTime.UtcNow;
   private readonly TimeSpan _touchDelay = TimeSpan.FromMilliseconds(100);
   public static bool swipeUp, swipeDown;
   public static bool isTouch = false;

   private void Update()
   {
      swipeDown = swipeUp = isTouch = false;

      #region ПК-версия
      if (Input.GetMouseButtonDown(0))
      {
         _dtStart = DateTime.UtcNow;
         _isDraging = true;
         _startTouch = Input.mousePosition;
      }
      else if (Input.GetMouseButtonUp(0))
      {
         if (DateTime.UtcNow - _dtStart <= _touchDelay)
            isTouch = true;
         _isDraging = false;
         Reset();
      }
      #endregion

      #region Мобильная версия
      if (Input.touches.Length > 0)
      {
         if (Input.touches[0].phase == TouchPhase.Began)
         {
            _isDraging = true;
            _startTouch = Input.touches[0].position;
            _dtStart = DateTime.UtcNow;
         }
         else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
         {
            _isDraging = false;
            if (DateTime.UtcNow - _dtStart <= _touchDelay)
               isTouch = true;
            Reset();
         }
      }
      #endregion

      _swipeDelta = Vector2.zero;
      if (_isDraging)
      {
         if (Input.touches.Length < 0)
            _swipeDelta = Input.touches[0].position - _startTouch;
         else if (Input.GetMouseButton(0))
            _swipeDelta = (Vector2)Input.mousePosition - _startTouch;
      }

      if (_swipeDelta.magnitude > 100)
      {
         float y = _swipeDelta.y;
         if (y < 0)
            swipeDown = true;
         else
            swipeUp = true;

         Reset();
      }
   }
   private void Reset()
   {
      _startTouch = _swipeDelta = Vector2.zero;
      _isDraging = false;
   }
}