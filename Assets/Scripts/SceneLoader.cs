using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0.25f;
    SaveDataJSON loadPlayerData;
    GameManager gameManager;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            LoadScene("CountTheEggs");
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);

        yield return new WaitForSeconds(1f);

        if(sceneName == "Game" || sceneName == "Board")
        {
            Debug.Log("Loading player Data");
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            
            gameManager.updatePlayerList();

            // loads players data

            loadPlayerData = GameObject.Find("GameManager").GetComponent<SaveDataJSON>();
            loadPlayerData.LoadPlayerData();
        }
        else
        {
            loadPlayerData.SavePlayerData();
        }
    }
}
