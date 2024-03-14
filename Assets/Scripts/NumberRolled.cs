using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NumberRolled : MonoBehaviour
{
    //private GameObject diceSide;

    public int diceRolled;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        //diceSide = GetComponent<GameObject>();
        timer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        timer -= Time.deltaTime;
        timer = Mathf.Round(timer * 100f) / 100f;
        if (timer < 0)
        {
            if (other.name == "Num1")
            {
                //StartCoroutine(DiceSider());
                diceRolled = 6; //Opposite side of 6 is 1
                timer = 5;
            }
            else if (other.name == "Num2")
            {
                diceRolled = 5; //Opposite side of 5 is 2
                timer = 5;
            }
            else if (other.name == "Num3")
            {
                diceRolled = 4; //Opposite side of 4 is 3
                timer = 5;
            }
            else if (other.name == "Num4")
            {
                diceRolled = 3; //Opposite side of 3 is 4
                timer = 5;
            }
            else if (other.name == "Num5")
            {
                diceRolled = 2; //Opposite side of 2 is 5
                timer = 5;
            }
            else if (other.name == "Num6")
            {
                diceRolled = 1; //Opposite side of 1 is 6
                timer = 5;
            }
        }
       
    }

    IEnumerator DiceSider()
    {
        yield return new WaitForSeconds(5f);

        if(gameObject.name == "Num1")
        {
            diceRolled = 1;
        }
        else if(gameObject.name == "Num2")
        {
            diceRolled = 2;
        }
        else if(gameObject.name == "Num3")
        {
            diceRolled = 3;
        }
        else if(gameObject.name == "Num4")
        {
            diceRolled = 4;
        }
        else if(gameObject.name == "Num5")
        {
            diceRolled = 5;
        }
        else if(gameObject.name == "Num6")
        {
            diceRolled = 6;
        }
    }
}
