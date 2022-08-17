public class Box : Item, IItem
{
   public void Accept(ICollide collide) => collide.Visit(this);

   public void BrokeBox()
   {
      GlobalEventManager.SendBoxBroke();
      Destroy(this.gameObject);
   }
}
