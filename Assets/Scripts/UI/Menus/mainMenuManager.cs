using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _LocalMenuFirst;
    [SerializeField] private GameObject _OnlineMenuFirst;
    [SerializeField] private GameObject _HostMenuFirst;
    [SerializeField] private GameObject _JoinMenuFirst;
    [SerializeField] private GameObject _EncyclopediaMenuFirst;
    [SerializeField] private GameObject _OptionMenuFirst;
    [SerializeField] private GameObject _LocalLobbyMenuFirst;

    public void MenuMain()
    {
        PlayerPrefs.SetString("gameType", "");
        GameSceneManager.Instance.ChangeSceneInLocalGame("00 - Main Menu");

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }
    public void MenuLocal()
    {
        PlayerPrefs.SetString("gameType", "local");
        GameSceneManager.Instance.ChangeSceneInLocalGame("01 - Local Menu");
        EventSystem.current.SetSelectedGameObject(_LocalMenuFirst);
    }

    public void MenuMulti()
    {
        PlayerPrefs.SetString("gameType", "multi");
        GameSceneManager.Instance.ChangeSceneInLocalGame("02 - Online Menu");
        EventSystem.current.SetSelectedGameObject(_OnlineMenuFirst);
    }
    public void MenuMultiHost()
    {
        GameSceneManager.Instance.ChangeSceneInLocalGame("02.01 - Host Menu");
    }
    public void MenuMultiJoin()
    {
        GameSceneManager.Instance.ChangeSceneInLocalGame("02.02 - Join Menu");
    }
    public void MenuEncyclopedia()
    {
        GameSceneManager.Instance.ChangeSceneInLocalGame("03 - Encyclopedia Menu");
    }
    public void MenuOptions()
    {
        GameSceneManager.Instance.ChangeSceneInLocalGame("04 - Options Menu");
    }

    public void MenuLobbyLocal()
    {
        GameSceneManager.Instance.ChangeSceneInLocalGame("LocalSelection");
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
