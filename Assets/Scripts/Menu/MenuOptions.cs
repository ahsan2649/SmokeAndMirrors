using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] private GameObject _optionScreen;
    [SerializeField] private GameObject _optionTriggerZone;

    public void ExitGame()
    {
        Debug.Log("Exit");
    }

    public void EnterGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("HighestLevel"));
        Debug.Log("Enter");
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("HighestLevel", SceneManager.GetSceneByName("Noobtorial").buildIndex);
        SceneManager.LoadScene("Noobtorial");
        Debug.Log("New Game");
    }

    public void OpenOptionPanel()
    {
        Debug.Log("Options");
        _optionTriggerZone.SetActive(false);
        _optionScreen.SetActive(true);
        StateManager.Pause();
    }
}
