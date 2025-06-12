using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CleanerSetup : MonoBehaviour
{
    [SerializeField] private Sprite cleanerSprite; // Asignable desde el Inspector

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && cleanerSprite != null)
        {
            sr.sprite = cleanerSprite;
        }
    }
}
