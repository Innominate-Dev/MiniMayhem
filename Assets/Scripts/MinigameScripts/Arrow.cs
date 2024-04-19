using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float DespawnTime = 10f;
    public float speed = 8f;

    private float DespawnTimer;
    private bool hasCollided;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        DespawnTimer = DespawnTime;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward * 10f);
        Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity);

        Debug.DrawRay(transform.position, forward, Color.red);

     

        /////////// DESPAWNS arrows //////////
        DespawnTimer -= Time.deltaTime;
        if (DespawnTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            hasCollided = true;

            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        }
        else
        {
            Debug.Log("hit nothing brev");
        }
    }
}
