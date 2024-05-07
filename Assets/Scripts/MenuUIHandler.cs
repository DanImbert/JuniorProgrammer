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
	public Button SaveColorButton;
	public Button LoadColorButton;

	private const string ColorKey = "SelectedColor";

	public void NewColorSelected(Color color)
	{
		// No need to save the color immediately, as the ColorPicker component should handle it internally
	}

	public void StartButtonClicked()
	{
		SceneManager.LoadScene("Main");
	}

	public void ExitButtonClicked()
	{
		
		Application.Quit();
	}


	private void Start()
    {
        
		ColorPicker.Init();
		ColorPicker.onColorChanged += NewColorSelected;
		LoadSelectedColor();

	}

	public void SaveColorButtonClicked()
	{
		// Save the currently selected color from the ColorPicker
		SaveSelectedColor(ColorPicker.CurrentColor);
	}

	public void LoadColorButtonClicked()
	{
		// Load the saved color and apply it to the ColorPicker
		LoadSelectedColor();
	}

	void SaveSelectedColor(Color color)
	{
		// Save the selected color to PlayerPrefs
		PlayerPrefs.SetFloat(ColorKey + "_R", color.r);
		PlayerPrefs.SetFloat(ColorKey + "_G", color.g);
		PlayerPrefs.SetFloat(ColorKey + "_B", color.b);
		PlayerPrefs.SetFloat(ColorKey + "_A", color.a);
		PlayerPrefs.Save();
	}

	 void LoadSelectedColor()
	{
		// Load the selected color from PlayerPrefs
		if (PlayerPrefs.HasKey(ColorKey + "_R"))
		{
			float r = PlayerPrefs.GetFloat(ColorKey + "_R");
			float g = PlayerPrefs.GetFloat(ColorKey + "_G");
			float b = PlayerPrefs.GetFloat(ColorKey + "_B");
			float a = PlayerPrefs.GetFloat(ColorKey + "_A");
			Color selectedColor = new Color(r, g, b, a);

			
		}
	}
}
