using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0.25f;
    SaveDataJSON playerData;
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

        if (sceneName == "Game" || sceneName == "Board")
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.GameStatusHandler(sceneName);
        }
        else
        {
            playerData = GameObject.Find("GameManager").GetComponent<SaveDataJSON>();
            playerData.SavePlayerData();
        }
    }
}
