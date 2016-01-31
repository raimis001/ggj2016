using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ievadekrāns : MonoBehaviour
{
	public void Play()
	{
		PlayerController.Score = 0;
		PlayerController.Goats = 0;

		SceneManager.LoadScene("Game");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
