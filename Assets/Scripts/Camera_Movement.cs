using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    // IDEA - Camera should follow the player which is our target here 
    [SerializeField]
    private Transform target;
    public Vector3 offset; 
    
    void Start()
    {
        offset = transform.position - target.transform.position;  
    }

    // LATE UPDATE - is called at the end of the frame 
    void LateUpdate()
    {
        // NULL CHECK  
        if (target != null)
        {
            // ADD OFFSET - to our position in order to depict the player properly
            Vector3 newPosition = target.transform.position + offset;
            transform.position = newPosition;
        }
    }
}
