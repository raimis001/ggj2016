using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleController : MonoBehaviour
{
	public static SimpleController Instance;
	
	public PlayerController Player;

	Mountain Mountain;
	/// <summary>
	/// Input direction
	/// </summary>
	float Direction;
	Rigidbody playerBody;
	Animator playerAnimator;

	public CubeAbstract ActiveCube
	{
		get
		{
			return _ActiveCube;
		}
		protected set
		{
			_ActiveCube = value;
		}
	}
	CubeAbstract _ActiveCube = null;

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start()
	{
		Mountain = GameObject.FindGameObjectWithTag("Mountain").GetComponent<Mountain>();
		ActiveCube = GetStartCube();
		Player.transform.position = ActiveCube.transform.position + new Vector3(0f, 1f, 0f);
	}

	

	// Update is called once per frame
	void Update()
	{
		float newDirection = Input.GetAxisRaw("Horizontal");
		if (newDirection != 0)
		{
			Direction = newDirection;
			MoveToCube(Direction);
		}
	}

	public void MoveGui(int direction)
	{
		Direction = direction;
		MoveToCube(direction);
	}

	public void MoveToCube(float direction)
	{
		if (PlayerController.Moving)
		{
			return;
		}
		CubeAbstract cube = null;
		if (ActiveCube.Row < Mountain.Konfigurācija.Rindas - 1)
		{
			cube = direction > 0 ? ActiveCube.Right : ActiveCube.Left;
		}
		if(ActiveCube.Row == Mountain.Konfigurācija.Rindas - 1)
		{
			cube = direction > 0 ? ActiveCube.RightToPlain : ActiveCube.LeftToPlain;
		}
		if (cube != null && cube.CanMoveTo())
		{
			ActiveCube = cube;
			Player.MoveToDirection(cube);
		}
	}

	public void DropToCube(float direction)
	{
		if (PlayerController.Moving)
		{
			return;
		}
		CubeAbstract cube = null;
		if (ActiveCube.Row < Mountain.Konfigurācija.Rindas - 1)
		{
			cube = direction > 0 ? ActiveCube.Right : ActiveCube.Left;
		}
		if (ActiveCube.Row == Mountain.Konfigurācija.Rindas - 1)
		{
			cube = direction > 0 ? ActiveCube.RightToPlain : ActiveCube.LeftToPlain;
		}
		if (cube != null)
		{
			ActiveCube = cube;
			Player.MoveToDirection(cube);
		}
	}

	CubeAbstract GetStartCube()
	{
		if (Mountain == null) { return null; }
		if (Mountain.Konfigurācija.SagatavotieKubi.Count == 0)
		{
			return CalculateStartCube();
		}
		KubaApraksts apraksts = Mountain.Konfigurācija.SagatavotieKubi[0];
        return Mountain.Content[apraksts.RindasIndeks][apraksts.IndeksRindā];
	}

	CubeAbstract CalculateStartCube()
	{
		List<CubeAbstract> startRow = Mountain.GetStartRow();
		int count = startRow.Count;
		//modify number if its even
		int modifier = 0;
		int random = 0;
		int index = 0;
		if (count % 2 == 0)
		{
			random = Random.Range(0, 2);
			if (random == 0)
			{
				modifier = 1;
			}
			else
			{
				modifier = 0;
			}
			index = count / 2 - modifier;
		}
		//gets middle element index
		else
		{
			index = count / 2;
		}
		//return middle element
		return startRow[index];
	}
}