using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PlayerControler : MonoBehaviour
{
	public Animation GirlAnimation;
	public Transform GirlTransform;

	[HideInInspector]
	public bool Moving = false;

	public static int Score = 0;
	public delegate void ScoreChange();
	public static event ScoreChange OnScoreChange;

	CubeAbstract _cube;

	// Use this for initialization
	void Start()
	{
		GirlAnimation.Play("Stand");
	}

	// Update is called once per frame
	void Update()
	{

	}

	public static void AddScore(int score)
	{
		Score += score;
		if (OnScoreChange != null)
		{
			OnScoreChange();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Collision enetered:" + collision.gameObject.name);
		Moving = false;
		GirlAnimation.Play("Stand");
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

	IEnumerator MoveChar( CubeAbstract cube)
	{
		if (Moving)
		{
			yield break;
		}

		Moving = true;
		GirlAnimation.Play("Jump");
		GirlTransform.LookAt(new Vector3(cube.transform.position.x, GirlTransform.position.y, cube.transform.position.z));
		Vector3 startPos = transform.position;
		Vector3 endPos = new Vector3(cube.transform.position.x,startPos.y + 0.3f, cube.transform.position.z) - new Vector3(0f, 0, 0f); 
		//startPos + new Vector3(direction < 0 ? 1 : 0, 0, direction > 0 ? 1 : 0);
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
