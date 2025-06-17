using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(SpriteRenderer))]
public class MovableObject : MonoBehaviour
{
    [SerializeField] private Sprite customSprite;

    private Rigidbody2D rb;
    private Camera cam;
    private bool isHeld = false;

    private GameObject mouseAnchor;
    private Rigidbody2D anchorRb;
    private HingeJoint2D joint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        var sr = GetComponent<SpriteRenderer>();
        if (customSprite != null && sr != null)
            sr.sprite = customSprite;

        mouseAnchor = new GameObject("MouseAnchor");
        anchorRb = mouseAnchor.AddComponent<Rigidbody2D>();
        anchorRb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseAnchor.transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            if (hit != null && hit.gameObject == gameObject)
            {
                isHeld = true;

                joint = gameObject.AddComponent<HingeJoint2D>();
                joint.connectedBody = anchorRb;
                joint.autoConfigureConnectedAnchor = false;

                // Punto donde se agarra, en local del objeto
                Vector2 localAnchor = transform.InverseTransformPoint(mousePos);
                joint.anchor = localAnchor;
                joint.connectedAnchor = Vector2.zero;

                // Opcional: límites o configuración adicional
            }
        }

        if (Input.GetMouseButtonUp(0) && isHeld)
        {
            if (joint != null)
            {
                Destroy(joint);
                joint = null;
            }
            isHeld = false;

            // Asegurar que el Rigidbody2D esté activo para que caiga
            rb.simulated = true;
            rb.gravityScale = 1f; // o el valor que tengas configurado para gravedad
        }
    }
}
