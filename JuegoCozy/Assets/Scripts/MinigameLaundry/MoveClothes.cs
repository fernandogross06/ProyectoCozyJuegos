using UnityEngine;

public class MoveClothes : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            // Move object, taking into account original offset.
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        // Record the difference between the objects centre, and the clicked point on the camera plane.
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        // Stop dragging.
        dragging = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with object");
        if (collision.gameObject.CompareTag("cleaner"))
        {
            // Do something when hitting player
            Destroy(gameObject); // Destroys this object
        }
    }
}
