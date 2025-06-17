using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CleanerSetup : MonoBehaviour
{
    [SerializeField] private Sprite sprite; // Asignable desde el Inspector

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && sprite != null)
        {
            sr.sprite = sprite;
        }
    }
}
