using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button button;
    public Slider slider;
    public Dropdown dropdown;
    private void Start()
    {
        button.onClick.AddListener(StartGame);
        slider.onValueChanged.AddListener((float value) => { Debug.Log(value); });
        var text = dropdown.options[dropdown.value].text;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {

    }

    public void OpenMenu()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
