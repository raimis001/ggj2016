using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
	public Text ScoreText;
	public Text GoatText;



	public EasyTween Victory;
	public guiVictory VictoryPanel;
	public guiLose LosePanel;

	// Use this for initialization
	void Start()
	{
		if (ScoreText)
		{
			ScoreText.text = "0";
		}
		if (GoatText)
		{
			GoatText.text = "0";
		}
		PlayerController.OnScoreChange += OnScoreChange;
		PlayerController.OnGoatChange += OnGoatChange;
		PlayerController.OnVictory += OnVictory;
		PlayerController.OnLose += OnLose;
	}

	void OnDisable()
	{
		PlayerController.OnScoreChange -= OnScoreChange;
		PlayerController.OnGoatChange -= OnGoatChange;
		PlayerController.OnLose -= OnLose;
	}

	private void OnScoreChange()
	{
		if (ScoreText)
		{
			ScoreText.text = PlayerController.Score.ToString();
		}
	}

	private void OnGoatChange()
	{
		if (GoatText)
		{
			GoatText.text = PlayerController.Goats.ToString();
		}
	}

	public void GotoMenu()
	{
		SceneManager.LoadScene("Game");
	}

	public void GotoNext()
	{
		if (SpēlesKontrolieris.LīmeņaIndeks >= SpēlesKontrolieris.Instance.Līmeņi.Skaits - 1)
		{
			GotoMenu();
			return;

		}
		SpēlesKontrolieris.LīmeņaIndeks++;
		ReloadGame();
  }

	public void ReloadGame()
	{
		PlayerController.Score = 0;
		PlayerController.Goats = 0;
		SceneManager.LoadScene("Game");
	}
	private void OnVictory()
	{
		LosePanel.gameObject.SetActive(false);
    VictoryPanel.Open();
		Victory.OpenCloseObjectAnimation();
	}
	private void OnLose()
	{
		VictoryPanel.gameObject.SetActive(false);
		LosePanel.Open();
		Victory.OpenCloseObjectAnimation();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
