using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDataJSON : MonoBehaviour
{

    private PlayerDataHandler playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerData = PlayerDataHandler.Instance;
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using(StreamWriter sw = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            sw.Write(json);
        }
    }
}
