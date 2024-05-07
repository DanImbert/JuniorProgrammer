using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

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
		
		SaveSelectedColor(color);
	}


	public void SaveColorButtonClicked()
	{
		// Save the currently selected color from the ColorPicker
		SaveSelectedColor(ColorPicker.SelectedColor);
	}

	public void LoadColorButtonClicked()
	{
		// Load the saved color and apply it to the ColorPicker
		LoadSelectedColor();
	}

	private void Start()
	{
		ColorPicker.Init();
		ColorPicker.onColorChanged += NewColorSelected;
		
	}

	public void StartNew()
	{
		SceneManager.LoadScene(1);
	}

	public void ExitButtonClicked()
	{
     #if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
     #else
        Application.Quit(); // original code to quit Unity player
     #endif
	}

	private void SaveSelectedColor(Color color)
	{
		// Save the selected color to PlayerPrefs
		PlayerPrefs.SetFloat(ColorKey + "_R", color.r);
		PlayerPrefs.SetFloat(ColorKey + "_G", color.g);
		PlayerPrefs.SetFloat(ColorKey + "_B", color.b);
		PlayerPrefs.SetFloat(ColorKey + "_A", color.a);
		PlayerPrefs.Save();
	}

	private void LoadSelectedColor()
	{
		// Load the selected color from PlayerPrefs
		if (PlayerPrefs.HasKey(ColorKey + "_R"))
		{
			float r = PlayerPrefs.GetFloat(ColorKey + "_R");
			float g = PlayerPrefs.GetFloat(ColorKey + "_G");
			float b = PlayerPrefs.GetFloat(ColorKey + "_B");
			float a = PlayerPrefs.GetFloat(ColorKey + "_A");
			Color selectedColor = new Color(r, g, b, a);

			// Apply the loaded color to the ColorPicker
			ColorPicker.SelectColor(selectedColor);
			
		}
	}
}
