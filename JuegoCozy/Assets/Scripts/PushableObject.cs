using UnityEngine;

public class PushableObject : MonoBehaviour
{
    [SerializeField] private float horizontalMargin = 0.05f;
    [SerializeField] private float verticalMargin = 0.1f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);

        if (viewportPos.x < -horizontalMargin || viewportPos.x > 1 + horizontalMargin ||
            viewportPos.y < -verticalMargin || viewportPos.y > 1 + verticalMargin)
        {
            Destroy(gameObject);
        }
    }
}
