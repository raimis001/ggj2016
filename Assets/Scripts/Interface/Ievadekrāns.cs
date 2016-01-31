using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ievadekrāns : MonoBehaviour
{
	public void Play()
	{
		SceneManager.LoadScene("Game");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
