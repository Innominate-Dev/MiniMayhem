using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward * 10f);
        Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity);

        Debug.DrawRay(transform.position, forward, Color.red);
    }
}
