using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ErasableSetup : MonoBehaviour
{
    [SerializeField] private Sprite initialSprite; // Asignable desde el Inspector

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && initialSprite != null)
        {
            sr.sprite = initialSprite;
        }
    }
}