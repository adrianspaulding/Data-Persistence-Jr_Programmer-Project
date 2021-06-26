using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;


[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{
    public string playerName;

    public InputField enterNameField;

    public void Start()
    {
        //Pre-fill name bar with last used (Between Scenes)
        enterNameField.GetComponent<InputField>().SetTextWithoutNotify(DataManager.Instance.playerName);
    }

    public void SetName()
    {
        playerName = enterNameField.GetComponent<InputField>().text;


        DataManager.Instance.playerName = playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        DataManager.Instance.SaveInfo();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
