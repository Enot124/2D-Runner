using UnityEngine;

public class DestroyItems : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      Destroy(other.gameObject);
   }
}
