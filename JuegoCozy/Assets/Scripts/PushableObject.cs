using UnityEngine;

public class PushableObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer boundaryRenderer; // SpriteRenderer que define los l�mites

    void Update()
    {
        if (boundaryRenderer == null)
            return;

        Bounds bounds = boundaryRenderer.bounds;
        Vector3 pos = transform.position;

        // Verifica si el objeto est� fuera del �rea visible del SpriteRenderer
        if (pos.x < bounds.min.x || pos.x > bounds.max.x ||
            pos.y < bounds.min.y || pos.y > bounds.max.y)
        {
            Destroy(gameObject);
        }
    }
}
