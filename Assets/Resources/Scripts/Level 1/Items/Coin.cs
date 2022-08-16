public class Coin : Item, IItem
{
   public void Accept(ICollide collide) => collide.Visit(this);
}
