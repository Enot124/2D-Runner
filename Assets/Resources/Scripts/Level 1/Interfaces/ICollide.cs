public interface ICollide
{
   void Visit(Ammo ammo);
   void Visit(Box box);
   void Visit(Coin coin);
   void Visit(Enemy enemy);
   void Visit(Stone stone);
}
