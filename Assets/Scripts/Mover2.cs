using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2 : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 3f;

    public int playerPOS = 0;
    public bool canMove = false;

    private CharacterController pc;
    private DiceController diceController;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 InputVector = Vector2.zero;
   

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<CharacterController>();
        diceController = FindAnyObjectByType<DiceController>();
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
    }
}
