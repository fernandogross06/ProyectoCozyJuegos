using UnityEngine;

public class GermenBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

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
