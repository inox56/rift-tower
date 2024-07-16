using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void MenuMain()
    {
        //SceneManager.LoadScene("PlaySoloMenu");
        PlayerPrefs.SetString("gameType", "local");
        GameSceneManager.Instance.ChangeSceneInLocalGame("00 - Main Menu");
    }
    public void MenuLocal()
    {
        //SceneManager.LoadScene("PlaySoloMenu");
        PlayerPrefs.SetString("gameType", "local");
        GameSceneManager.Instance.ChangeSceneInLocalGame("01 - Local Menu");
    }

    public void MenuMulti()
    {
        //SceneManager.LoadScene("MultiMenu");
        PlayerPrefs.SetString("gameType", "multi");
        GameSceneManager.Instance.ChangeSceneInLocalGame("02 - Online Menu");
    }
    public void MenuMultiHost()
    {
        //SceneManager.LoadScene("MultiMenu");
        PlayerPrefs.SetString("gameType", "multi");
        GameSceneManager.Instance.ChangeSceneInLocalGame("02.01 - Host Menu");
    }
    public void MenuMultiJoin()
    {
        //SceneManager.LoadScene("MultiMenu");
        PlayerPrefs.SetString("gameType", "multi");
        GameSceneManager.Instance.ChangeSceneInLocalGame("02.02 - Join Menu");
    }
    public void MenuEncyclopedia()
    {
        //SceneManager.LoadScene("MultiMenu");
        GameSceneManager.Instance.ChangeSceneInLocalGame("03 - Encyclopedia Menu");
    }
    public void MenuOptions()
    {
        GameSceneManager.Instance.ChangeSceneInLocalGame("04 - Options Menu");
    }



    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
