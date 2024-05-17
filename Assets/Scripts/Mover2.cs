using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Mover2 : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 3f;

    public int playerPOS;
    public bool canMove = false;
    public bool isMoving = false;

    private CharacterController pc;
    private DiceController diceController;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 InputVector = Vector2.zero;

    public Transform waypointparent;
    public List<GameObject> waypoints;
    public float speed = 2;
    public int index = 0;
    public bool isLoop = true;
    Vector3 destination;
    bool changingDirection = false;

    float DistanceRay;

    //Animation
    //Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<CharacterController>();
        diceController = FindAnyObjectByType<DiceController>();
        waypointparent = GameObject.Find("Waypoints").transform;
        foreach (Transform child in waypointparent)
        {
            waypoints.Add(child.gameObject);
        }
        destination = waypoints[index].transform.position;
        //myAnim = GetComponentInChildren<Animator>();
    }

    public void SetInputVector(Vector2 direction)
    {
        InputVector = direction;
    }

    public void MoveToSquare(Vector3 pos)
    {
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == true)
        {
            moveDirection = new Vector3(InputVector.x, 0, InputVector.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= MoveSpeed;

            pc.Move(moveDirection * Time.deltaTime);
        }

        if (index < 0)
        {
            index = 0;
            playerPOS = 0;
        }

        if (isMoving)
        {
            float distance = Vector3.Distance(transform.position, destination);

            RaycastHit hit;

            Vector3 forward = transform.TransformDirection(Vector3.forward * 10f);

            Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity);

            Debug.DrawRay(transform.position, forward, Color.red);

            if (!changingDirection)
            {
                if (distance <= 0.15f)
                {
                    Debug.Log("CloseBy");
                    if (index < waypoints.Count - 1 && index < playerPOS)
                    {
                        ChangeWaypoint();
                    }
                    else if(index > playerPOS)
                    {
                        GoBack();
                    }
                    else
                    {
                        isMoving = false;
                        if (isLoop)
                        {
                            index = -1;
                        }
                        Debug.Log("Finished at destination");
                    }
                }
                else
                {
                    Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                    transform.position = newPos;
                }
            }
            else
            {
                Vector3 targetRotation = (destination - transform.position).normalized;

                transform.forward = Vector3.RotateTowards(transform.forward, targetRotation, Time.deltaTime, Time.deltaTime);
                //transform.LookAt(waypoints[index].transform.position);
                if (Vector3.Dot(transform.forward, targetRotation) > 0.95f)
                {
                    //myAnim.SetBool("isMoving", true);
                    changingDirection = false;
                }
            }
        }
    }

    void ChangeWaypoint()
    {
        index++;
        destination = waypoints[index].transform.position;
        changingDirection = true;
        //myAnim.SetBool("isMoving", false);
    }

    void GoBack()
    {
        index--;
        destination = waypoints[index].transform.position;
        changingDirection = true;
    }
}
