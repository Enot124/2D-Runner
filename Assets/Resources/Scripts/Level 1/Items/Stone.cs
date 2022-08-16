public class Stone : Item, IItem
{
   public void Accept(ICollide collide) => collide.Visit(this);
}
