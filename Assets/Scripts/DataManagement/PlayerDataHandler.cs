using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{

    public string playername;
    public int playerId;
    public int playerPOS;

    Mover2 mover;

    private void Start()
    {
        playername = gameObject.name;

        if (playername == "Player0") { playerId = 0; }
        if (playername == "Player1") { playerId= 1; }

        mover = GetComponent<Mover2>();
    }

    private void Update()
    {
        playerPOS = mover.playerPOS;
    }
}
