using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play1Player()
    {
        //SceneManager.LoadScene("PlaySoloMenu");
        PlayerPrefs.SetString("gameType", "solo");
        GameSceneManager.Instance.ChangeSceneInLocalGame("01 - Local Menu");
    }

    public void Play2Player()
    {
        //SceneManager.LoadScene("MultiMenu");
        GameSceneManager.Instance.ChangeSceneInLocalGame("02 - Online Menu");
    }

    public void returnToMainMenu()
    {
        GameSceneManager.Instance.ChangeSceneInLocalGame("00 - Main Menu");
    }

    public void returnToPreviousMenu()
    {
        GameSceneManager.Instance.ChangeSceneInLocalGame("00 - Main Menu");
    }
}
