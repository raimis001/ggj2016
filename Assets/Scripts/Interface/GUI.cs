using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
	public Text ScoreText;
	public Text GoatText;

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
	}

	void OnDisable()
	{
		PlayerController.OnScoreChange -= OnScoreChange;
		PlayerController.OnGoatChange -= OnGoatChange;
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
	// Update is called once per frame
	void Update()
	{

	}
}
