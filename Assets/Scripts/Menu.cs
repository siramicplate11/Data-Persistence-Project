using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField InputField;
    void Start()
    {
        
    }
    public void PlayerName()
    {
        MainHandler.Instance.temporaryName = InputField.text;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        MainHandler.Instance.LoadGame();
    }
    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
