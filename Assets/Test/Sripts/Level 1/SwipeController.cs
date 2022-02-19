using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
   public static bool swipeUp, swipeDown;
   private bool isDraging = false;
   public static bool isTouch = false;
   private Vector2 startTouch, swipeDelta;

   private void Update()
   {
      swipeDown = swipeUp = isTouch = false;
      #region ПК-версия
      if (Input.GetMouseButtonDown(0))
      {
         isDraging = true;
         startTouch = Input.mousePosition;
      }
      else if (Input.GetMouseButtonUp(0))
      {
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
         }
         else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
         {
            isDraging = false;
            Reset();
         }
         else if (Input.touches[0].phase == TouchPhase.Stationary)
         {
            isTouch = true;
         }
      }
      #endregion

      //Просчитать дистанцию
      swipeDelta = Vector2.zero;
      if (isDraging)
      {
         if (Input.touches.Length < 0)
            swipeDelta = Input.touches[0].position - startTouch;
         else if (Input.GetMouseButton(0))
            swipeDelta = (Vector2)Input.mousePosition - startTouch;
      }

      //Проверка на пройденность расстояния
      if (swipeDelta.magnitude > 100)
      {
         //Определение направления
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