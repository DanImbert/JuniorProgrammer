using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;
    public Button StartButton;
	public Button ExitButton;

	public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
    }

	public void StartButtonClicked()
	{
		SceneManager.LoadScene("Main");
	}

	public void ExitButtonClicked()
	{
		// Close the application
		Application.Quit();
	}


	private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }
}
