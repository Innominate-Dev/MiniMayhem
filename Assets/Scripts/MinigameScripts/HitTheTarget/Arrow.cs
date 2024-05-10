using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public AudioSource dingsfx;

    public float DespawnTime = 10f;
    public float speed = 8f;

    private int amountTargetHit;
    private float DespawnTimer;
    private bool hasCollided;
    private Rigidbody rb;

    HitTheTarget hitTheTargetManager;
    // Start is called before the first frame update
    void Start()
    {
        DespawnTimer = DespawnTime;
        rb = GetComponent<Rigidbody>();
        hitTheTargetManager = GameObject.Find("MinigameManager").GetComponent<HitTheTarget>();
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
            bool hasHit = true;
            hitTheTargetManager.TargetHitChecker(hasHit);
            
            Destroy(other.gameObject);

            if (amountTargetHit == 6)
            {
                //dingsfx.Play();
                Debug.LogWarning(amountTargetHit);
            }

        }
        else
        {
            Debug.Log("hit nothing brev");


            float cooldown = 1.5f;

            cooldown -= Time.deltaTime;
            if (cooldown <= 0f)
            {
                hasCollided = true;

                rb.isKinematic = true;
                rb.velocity = Vector3.zero;
            }


        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// 
    /*private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            hasCollided = true;

            rb.isKinematic = true;
            rb.velocity = Vector3.zero;

            if (amountTargetHit < 6)
            {
                //dingsfx.Play();
                Debug.LogWarning("You hit the target");
                amountTargetHit++;
                targetsHitText.text = amountTargetHit.ToString() + "/6";
                Destroy(other.gameObject);
            }
        }
    }*/
}
