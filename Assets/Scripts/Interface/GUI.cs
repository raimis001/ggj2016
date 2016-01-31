using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
	public Text ScoreText;
	public Text GoatText;

	public EasyTween Victory;

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
	}

	void OnDisable()
	{
		PlayerController.OnScoreChange -= OnScoreChange;
		PlayerController.OnGoatChange -= OnGoatChange;
		PlayerController.OnVictory -= OnVictory;
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


	private void OnVictory()
	{
		Victory.OpenCloseObjectAnimation();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
