public class Ammo : Item, IItem
{
   public void Accept(ICollide collide) => collide.Visit(this);
}
