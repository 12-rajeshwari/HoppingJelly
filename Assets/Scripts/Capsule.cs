using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
   
    private float _capsulespeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // Fire Capsule up-wards
        transform.Translate(Vector3.up *_capsulespeed * Time.deltaTime);

        // DESTROY - if certain height is reached 
        if(transform.position.y > 35f)
        {
            Destroy(this.gameObject);
        }
    }
}
