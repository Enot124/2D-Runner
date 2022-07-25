using System;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
   public static bool swipeUp, swipeDown;
   public static bool isTouch = false;
   private bool isDraging = false;
   private Vector2 startTouch, swipeDelta;
   private DateTime _dtStart = DateTime.UtcNow;
   private readonly TimeSpan TouchDelay = TimeSpan.FromMilliseconds(100);

   private void Update()
   {
      swipeDown = swipeUp = isTouch = false;

      #region ПК-версия
      if (Input.GetMouseButtonDown(0))
      {
         _dtStart = DateTime.UtcNow;
         isDraging = true;
         startTouch = Input.mousePosition;
      }
      else if (Input.GetMouseButtonUp(0))
      {
         if (DateTime.UtcNow - _dtStart <= TouchDelay)
            isTouch = true;
         isDraging = false;
         Reset();
      }
      #endregion

      #region Мобильная версия
      if (Input.touches.Length > 0)
      {
         if (Input.touches[0].phase == TouchPhase.Began)
         {
            isDraging = true;
            startTouch = Input.touches[0].position;
            _dtStart = DateTime.UtcNow;
         }
         else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
         {
            isDraging = false;
            if (DateTime.UtcNow - _dtStart <= TouchDelay)
               isTouch = true;
            Reset();
         }
      }
      #endregion

      swipeDelta = Vector2.zero;
      if (isDraging)
      {
         if (Input.touches.Length < 0)
            swipeDelta = Input.touches[0].position - startTouch;
         else if (Input.GetMouseButton(0))
            swipeDelta = (Vector2)Input.mousePosition - startTouch;
      }

      if (swipeDelta.magnitude > 100)
      {
         float y = swipeDelta.y;
         if (y < 0)
            swipeDown = true;
         else
            swipeUp = true;

         Reset();
      }
   }
   private void Reset()
   {
      startTouch = swipeDelta = Vector2.zero;
      isDraging = false;
   }
}