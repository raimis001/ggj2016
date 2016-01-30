using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PlayerController : MonoBehaviour
{
	public Animation GirlAnimation;
	public Transform GirlTransform;

	[HideInInspector]
	public static bool Moving = false;

	public static int Score = 0;
	public delegate void ScoreChange();
	public static event ScoreChange OnScoreChange;

	static PlayerController _instance = null;
	public static PlayerController Instance
	{
		get
		{
			return _instance;
		}
	}

	CubeAbstract _cube;

	void Awake()
	{
		_instance = this;
	}

	// Use this for initialization
	void Start()
	{

		StopGirl();
  
		
		}

	// Update is called once per frame
	void Update()
	{

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
		}

	}

	public void MoveToDirection(CubeAbstract cube)
	{
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

	}

	public void SlopeGirl(CubeAbstract cube)
	{
		MoveToDirection(cube);
  }

	IEnumerator MoveChar( CubeAbstract cube)
	{
		if (Moving)
		{
			yield break;
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
}
