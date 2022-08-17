using System;

public static class GlobalEventManager
{
   public static Action OnAmmoPickedUp;
   public static Action OnAmmoChanged;
   public static Action OnBoxCollide;
   public static Action OnBoxBroke;
   public static Action OnCoinPickedUp;
   public static Action OnHealthChanged;

   public static void SendAmmoPickedUp()
   {
      OnAmmoPickedUp?.Invoke();
   }

   public static void SendAmmoChanged()
   {
      OnAmmoChanged?.Invoke();
   }

   public static void SendBoxCollide()
   {
      OnBoxCollide?.Invoke();
   }

   public static void SendBoxBroke()
   {
      OnBoxBroke?.Invoke();
   }

   public static void SendCoinPickedUp()
   {
      OnCoinPickedUp?.Invoke();
   }

   public static void SendHealthChanged()
   {
      OnHealthChanged?.Invoke();
   }
}
