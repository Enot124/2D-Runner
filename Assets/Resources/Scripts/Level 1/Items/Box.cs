public class Box : Item, IItem
{
   public void Accept(ICollide collide) => collide.Visit(this);
}
