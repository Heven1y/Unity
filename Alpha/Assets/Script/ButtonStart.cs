using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public Button start, exit;
    void Start()
    {
        start.onClick.AddListener(function);
        exit.onClick.AddListener(functionExit);
    }
    void function()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void functionExit()
    {
        Application.Quit();
    }
}
