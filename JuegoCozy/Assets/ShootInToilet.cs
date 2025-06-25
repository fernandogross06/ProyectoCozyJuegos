using System.Collections;
using UnityEngine;

public class ToiletBullet : MonoBehaviour
{


    // Unity forums: https://discussions.unity.com/t/how-to-make-gameobject-gradually-decrease-in-size/823179/2
    // Time it takes in seconds to shrink from starting scale to target scale.
    public float ShrinkDuration;

    // The target scale
    public Vector3 TargetScale;

    // The starting scale
    Vector3 startScale;

    private float t = 0;

    private bool objectExists = true;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initialize stuff in OnEnable
        startScale = transform.localScale;
        t = 0;
        //StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        if (objectExists) { 
            t += Time.deltaTime / ShrinkDuration;

            // Lerp wants the third parameter to go from 0 to 1 over time. 't' will do that for us.
            Vector3 newScale = Vector3.Lerp(startScale, TargetScale, t);
            transform.localScale = newScale;

            // We're done! We can disable this component to save resources.
            if (t > 1)
            {
                
                objectExists = false;
                Destroy(gameObject);
            }
        }
    }


    //IEnumerator SelfDestruct()
    //{
    //    yield return new WaitForSeconds(2f);
    //    
    //}
}
