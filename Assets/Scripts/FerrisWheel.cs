using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheel : MonoBehaviour
{

    public float speed;

    [SerializeField] private Transform pivot;
    [SerializeField] private Transform cab;

    [SerializeField] private bool useX;
    [SerializeField] private bool useZ;
    [SerializeField] private bool useY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z < 0.1)
        {
            speed = +transform.rotation.z;
        }
        else if(transform.rotation.z > 0.1)
        {
            speed -= transform.rotation.z;
        }

        if (useX)
        {
            transform.Rotate(speed * pivot.rotation.x, 0, 0);
        }
        else if (useZ)
        {
            transform.Rotate(0, 0, speed * pivot.rotation.z);
        }
        else if (useY)
        {
            transform.Rotate(0, speed * pivot.rotation.y , 0);
        }


    }
}
