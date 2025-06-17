using UnityEngine;

public class CleanerCollisionController : MonoBehaviour
{
    [SerializeField] private Collider2D pushCollider; // El collider físico
    [SerializeField] private LayerMask pushableLayer;
    [SerializeField] private float pushRadius = 0.5f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Detectar si hay un objeto pushable cerca
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, pushRadius, pushableLayer);
            bool foundPushable = false;

            foreach (var hit in hits)
            {
                if (hit != null && hit.gameObject != gameObject)
                {
                    foundPushable = true;
                    break;
                }
            }

            pushCollider.enabled = foundPushable;
        }
        else
        {
            pushCollider.enabled = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Para ver el área de detección en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pushRadius);
    }
}
