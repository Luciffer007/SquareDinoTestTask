using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Projectile"))
        {
            gameObject.GetComponentInParent<EnemyController>().Hit();
        }
    }
}
