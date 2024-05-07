using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{

    public string playername;
    public int playerId;
    public int playerPOS;

    public static PlayerDataHandler Instance { get; private set; }

    public PlayerData playerData = new PlayerData();

    private void Awake()
    {
        SaveObject saveObject = new SaveObject
        {
            playerId = 1,
        };
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log(json);

        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
        Debug.Log(loadedSaveObject.playerId);


        // If there is an instance, and it's not me, delete myself.

        if (Instance != null)
        {
            Debug.Log("Making Singleton");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class PlayerData
    {
        public string name;
        public int playerId;
        public int playerPOS;
    }

    private class SaveObject
    {
        public string name;
        public int playerId;
        public Vector3 playerPOS;
    }

    public void GetPlayerData(string playerName, int playerID, Vector3 POS)
    {
        SaveObject saveObject = new SaveObject
        {
            name = playerName,
            playerId = playerID,
            playerPOS = POS
        };
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log(json);

        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
        Debug.Log(loadedSaveObject.playerId);
    }
}
