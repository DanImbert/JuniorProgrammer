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
	//public Button StartButton;
	//public Button ExitButton;
	//public Button SaveColorButton;
	//public Button LoadColorButton;

	//private const string ColorKey = "SelectedColor";

	public void NewColorSelected(Color color)
	{

		MainManager.Instance.TeamColor = color;
	}


	public void SaveColorButtonClicked()
	{
		MainManager.Instance.SaveColor();

	}

	public void LoadColorButtonClicked()
	{
		MainManager.Instance.LoadColor();
		ColorPicker.SelectColor(MainManager.Instance.TeamColor);

	}

	private void Start()
	{
		ColorPicker.Init();
		ColorPicker.onColorChanged += NewColorSelected;
		ColorPicker.SelectColor(MainManager.Instance.TeamColor);

	}

	public void StartNew()
	{
		SceneManager.LoadScene(1);
	}

	public void ExitButtonClicked()
	{
		
		MainManager.Instance.SaveColor();

     #if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
     #else
        Application.Quit(); // original code to quit Unity player
     #endif

      
	}

	
}
