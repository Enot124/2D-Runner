using System;

public static class GlobalEventManager
{
   public static Action OnAmmoPickedUp;
   public static Action OnBoxCollide;
   public static Action OnCoinPickedUp;
   public static Action OnEnemyCollide;
   public static Action OnStoneCollide;

   public static void SendAmmoPickedUp()
   {
      OnAmmoPickedUp?.Invoke();
   }

   public static void SendBoxCollide()
   {
      OnBoxCollide?.Invoke();
   }

   public static void SendCoinPickedUp()
   {
      OnCoinPickedUp?.Invoke();
   }
}
