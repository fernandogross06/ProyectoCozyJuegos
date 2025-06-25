using UnityEngine;

public class RotatePan : MonoBehaviour
{
    public Collider2D deadZoneCollider;
    private Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;
    private Collider2D col;

    //Vector3 accumulateRotation, oldRotation, currentRotation;

    private float oldRotationZ;
    private float totalRotation = 0f; // Total accumulated rotation

    public float scoreToBeat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreToBeat = 5000;
        myCam = Camera.main;
        col = GetComponent<Collider2D>();
        oldRotationZ = transform.rotation.eulerAngles.z;
        //Debug.Log("Starting rotation: " + oldRotationZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckVictoryCondition())
        {
            GameStateManager.Instance.WinMinigame();

        }
        // coordenada en la simulación del mouse calculado desde la pantalla, se calcula para verificar las colisiones
        // con el objeto
        Vector3 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);

        bool mouseInDeadZone = deadZoneCollider != null && deadZoneCollider.OverlapPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            if (mouseInDeadZone)
            {
                Debug.Log("Dead zone has priority - no rotation");
                return;
            }
            // El mouse está dentro del Collision2D del objeto
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                
                screenPos = myCam.WorldToScreenPoint(transform.position); // posicion de la camara en la pantalla
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x)  - Mathf.Atan2(vec3.y, vec3.x )) * Mathf.Rad2Deg;
                //Debug.Log("Angle offset: " + angleOffset);
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (mouseInDeadZone)
            {
                Debug.Log("Dead zone has priority - no rotation");
                return;
            }
            // El mouse está dentro del Collision2D del objeto
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x)*Mathf.Rad2Deg;
                //Debug.Log("Angle: " + angle);
                transform.eulerAngles = new Vector3(0,0,angle + angleOffset);
                //Debug.Log("Euler angle" + transform.rotation.eulerAngles);
            }
        }
        // Track total rotation with proper wrap-around handling
        float currentRotationZ = transform.rotation.eulerAngles.z;
        if (currentRotationZ != oldRotationZ)
        {
            float angleDifference = GetShortestAngleDifference(oldRotationZ, currentRotationZ);
            float positiveAngle = Mathf.Abs(angleDifference); 
            totalRotation += Mathf.Min(positiveAngle, 15f); // Always add positive difference
            oldRotationZ = currentRotationZ;

            //Debug.Log($"Current angle: {currentRotationZ:F1}°, Total rotation: {totalRotation:F1}°");
        }

        Debug.Log("Total rotation " + totalRotation);


    }
    private float GetShortestAngleDifference(float fromAngle, float toAngle)
    {
        float difference = toAngle - fromAngle;

        // Handle wrap-around cases
        if (difference > 180f)
        {
            difference -= 360f;
        }
        else if (difference < -180f)
        {
            difference += 360f;
        }

        return difference;
    }


    bool CheckVictoryCondition()
    {
        return totalRotation > scoreToBeat;
    }

}
