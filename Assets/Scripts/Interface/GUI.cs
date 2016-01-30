﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{

	public Text ScoreText;

	// Use this for initialization
	void Start()
	{
		if (ScoreText)
		{
			ScoreText.text = "0";
		}
		PlayerControler.OnScoreChange += OnScoreChange;
	}

	private void OnScoreChange()
	{
		if (ScoreText)
		{
			ScoreText.text = PlayerControler.Score.ToString();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
