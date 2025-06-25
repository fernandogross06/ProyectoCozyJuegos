using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ErasableSetup : MonoBehaviour
{
    [SerializeField] private Sprite initialSprite; // Asignable desde el Inspector
    [SerializeField] private Color initialColor = Color.white; // Color asignable

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            if (initialSprite != null)
                sr.sprite = initialSprite;

            sr.color = initialColor;
        }
    }
}
