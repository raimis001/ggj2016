﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
	public Animation GirlAnimation;
	public Transform GirlTransform;

	public GameObject SoulEffectPrefab;
	public GameObject WinEffectPrefab;

	public AudioClip[] Sounds;

	[HideInInspector]
	public static bool Moving = false;
	public bool Live = true;

	public static int Score = 0;
	public delegate void ScoreChange();
	public static event ScoreChange OnScoreChange;

	public static int Goats = 0;
	public static event ScoreChange OnGoatChange;

	static PlayerController _instance = null;
	public static PlayerController Instance
	{
		get
		{
			return _instance;
		}
	}

	public static event ScoreChange OnVictory;
	public static event ScoreChange OnLose;

	CubeAbstract _cube;
	AudioSource Audio;

	void Awake()
	{
		_instance = this;
	}

	// Use this for initialization
	void Start()
	{
		Audio = GetComponent<AudioSource>();
		StopGirl();
	}

	public static void AddGoat(int score)
	{
		Goats += score;
		if (Goats < 0) Goats = 0;
		if (OnGoatChange!= null)
		{
			OnGoatChange();
		}
	}

	public static void AddScore(int score)
	{
		Score += score;
		if (Score < 0) Score = 0;
		if (OnScoreChange != null)
		{
			OnScoreChange();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Collision enetered:" + collision.gameObject.name);
		Moving = false;
		StopGirl();
		if (_cube != null)
		{
			_cube.OnPlayerLanded();

			if (_cube.Row >= Mountain.Instance.Konfigurācija.Rindas)
			{
				StartCoroutine(DecideWinConditionsAfterDelay());
			}
		}

	}

	public void MoveToDirection(CubeAbstract cube)
	{
		if (!Live) { return; }
		_cube = cube;
		StartCoroutine(MoveChar(cube));
	}

	public void StopGirl()
	{
		GirlAnimation.Play("Stand");
		GirlAnimation["EyeBlink"].layer = 1;
		GirlAnimation.Play("EyeBlink");
		GirlAnimation["EyeBlink"].weight = 0.4f;
		GirlAnimation["EyeBlink"].speed = 0.5f;

		GirlTransform.localEulerAngles = new Vector3(0, 225, 0);
	}

	public void BurnGirl()
	{
		Live = false;
		Transform effectTransform = Instantiate(SoulEffectPrefab).transform;
		effectTransform.position = transform.position;
		StartCoroutine(LooseAfterDelay());
	}

	IEnumerator DecideWinConditionsAfterDelay()
	{
		bool victory = (PlayerController.Goats > 0);
		GameObject effectPrefab = null;
		if(victory)
		{
			effectPrefab = WinEffectPrefab;
        }
		else
		{
			effectPrefab = SoulEffectPrefab;
		}
        Transform effectTransform = Instantiate(effectPrefab).transform;
		effectTransform.position = transform.position;
		yield return new WaitForSeconds(1f);
		if (victory)
		{
			if (OnVictory != null)
			{
				OnVictory();
			}
		}
		else
		{
			if (OnLose != null)
			{
				OnLose();
			}
		}
	}

	IEnumerator LooseAfterDelay()
	{
		yield return new WaitForSeconds(1f);
		if (OnLose != null)
		{
			OnLose();
		}
	}

	IEnumerator MoveChar( CubeAbstract cube)
	{
		if (Moving)
		{
			yield break;
		}
		if(cube is GrassCube && ((GrassCube)cube).Item != null)
		{
			PlaySound(0);
		}
		Moving = true;
		GirlAnimation.Play("Jump");
		GirlTransform.LookAt(new Vector3(cube.transform.position.x, GirlTransform.position.y, cube.transform.position.z));
		GirlTransform.Rotate(0, -180, 0);
		Vector3 angles = GirlTransform.localEulerAngles;
		if (angles.y > 200)
		{
			GirlTransform.Rotate(0, -30, 0);
		}
		else
		{
			GirlTransform.Rotate(0, 30, 0);
		}
		Vector3 startPos = transform.position;
		Vector3 endPos = new Vector3(cube.transform.position.x,startPos.y + 0.3f, cube.transform.position.z) - new Vector3(0f, 0, 0f);

		float dTime = 0.5f;
		float tmp = 0;
		while (tmp < dTime)
		{
			transform.position = Vector3.Lerp(startPos, endPos, tmp / dTime);
			tmp += Time.smoothDeltaTime;
			yield return null;
		}
  }
	public void PlaySound(int sound)
	{
		Audio.clip = Sounds[sound];
		Audio.Play();
	}
}
