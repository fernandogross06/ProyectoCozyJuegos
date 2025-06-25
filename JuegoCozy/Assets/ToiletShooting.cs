using UnityEngine;

public class ToiletShooting : MonoBehaviour
{
    public GameObject projectile;
    private Camera myCam;
    private Vector3 screenPos;
    private Collider2D col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCam = Camera.main;
        col = GetComponent<Collider2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

            // El mouse está dentro del Collision2D del objeto
            int layerMask = ~LayerMask.GetMask("Germs");
            if (col == Physics2D.OverlapPoint(mousePos, layerMask))
            {
                mousePos = new Vector3 (mousePos.x, mousePos.y, 0);   
                Instantiate(projectile, mousePos, Quaternion.identity); // Using object, vector3, rotation  
                
            }
        }
    }
}
