using UnityEngine;
using System.Collections.Generic;

public class CleanerErase : MonoBehaviour
{
    public float eraseAmount = 0.2f; // Cuánto se borra por pasada
    private HashSet<Collider2D> recentlyErased = new HashSet<Collider2D>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetMouseButton(0) && other.CompareTag("erasableObject"))
        {
            TryErase(other);
            recentlyErased.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (recentlyErased.Contains(other))
        {
            recentlyErased.Remove(other);
        }
    }

    private void TryErase(Collider2D other)
    {
        SpriteRenderer sr = other.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color c = sr.color;
            c.a = Mathf.Max(0, c.a - eraseAmount); // Disminuye opacidad una vez
            sr.color = c;

            if (c.a <= 0f)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
