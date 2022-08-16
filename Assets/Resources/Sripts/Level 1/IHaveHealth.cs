public interface IHaveHealth
{
   public int Lives { get; set; }
   public void TakeDamage();
   public void Die();
}
