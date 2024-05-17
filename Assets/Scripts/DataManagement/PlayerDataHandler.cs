using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{

    public string playername;
    public int playerId;
    public int playerPOS;

    private bool updatingPOS;

    Mover2 mover;

    private void Start()
    {
        playername = gameObject.name;

        if (playername == "Player0") { playerId = 0; }
        if (playername == "Player1") { playerId= 1; }
        if (playername == "Player2") { playerId= 2; }
        if (playername == "Player3") { playerId= 3; }

        mover = GetComponent<Mover2>();
    }

    private void Update()
    {
        if (mover.playerPOS != 0 && updatingPOS == false)
        {
            playerPOS = mover.playerPOS;
        }

        Debug.Log(playerPOS + " mover POS -> " + mover.playerPOS);
    }

    public void SetPlayerPOS(int newPOS)
    {
        updatingPOS = true;
        Debug.Log(gameObject.name + playerPOS + " NEW POS ->" + newPOS);

        mover.playerPOS = newPOS;
        mover.index = newPOS;
        playerPOS = newPOS;

        updatingPOS = false;
    }
}
