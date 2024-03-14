using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberRolled : MonoBehaviour
{
    //private GameObject diceSide;

    public int diceRolled;
    // Start is called before the first frame update
    void Start()
    {
        //diceSide = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Num1")
        {
            //StartCoroutine(DiceSider());
            diceRolled = 1;
        }
        else if (other.name == "Num2")
        {
            diceRolled = 2;
        } 
        else if (other.name == "Num3")
        {
            diceRolled = 3;
        } 
        else if (other.name == "Num4")
        {
            diceRolled = 4;
        } 
        else if (other.name == "Num5")
        {
            diceRolled = 5;
        } 
        else if (other.name == "Num6")
        {
            diceRolled = 6;
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
