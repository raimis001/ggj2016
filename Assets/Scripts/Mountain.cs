using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mountain : MonoBehaviour
{
	public int CubesInFirstRow = 3;
	public int Rows = 10;
	/// <summary>
	/// Starts with 0
	/// </summary>
	public int StartRowIndex = 2;
	/// <summary>
	/// All cube type prefab list
	/// </summary>
	[Tooltip("All cube type prefab list")]
	public CubePrefabs Prefabs;

	public List<CubeAbstract> FirstRow
	{
		get
		{
			return _FirstRow;
		}
		private set
		{
			_FirstRow = value;
		}
	}
	List<CubeAbstract> _FirstRow = new List<CubeAbstract>();
	/// <summary>
	/// All mountain rows with cubes
	/// </summary>
	public List<List<CubeAbstract>> Content = new List<List<CubeAbstract>>();

	// Use this for initialization
	void Awake()
	{
		StartRowIndex = Mathf.Clamp(StartRowIndex, 0, Rows - 1);
		Generate();
	}

	public void Generate()
	{
		List<CubeAbstract> currentRow = null;
		List<CubeAbstract> previousRow = null;
		GameObject block;
		CubeAbstract cube;
		int cubesPerRow = CubesInFirstRow;
		//Start position for row
		Vector3 startPosition = Vector3.zero;
		Vector3 currentPosition = Vector3.zero;
		for (int row = 0; row < Rows; row++)
		{
			currentRow = new List<CubeAbstract>();
			currentPosition = startPosition;
			for (int cubeIndex = 0; cubeIndex < cubesPerRow; cubeIndex++)
			{
				//creation
				block = Prefabs.GetInstance();
				block.transform.position = currentPosition;
				block.transform.parent = transform;
				currentPosition += new Vector3(-1f, 0f, 1f);
				//assigning self as move target
				cube = block.GetComponent<CubeAbstract>();
				if (row == 0)
				{
					FirstRow.Add(cube);
				}
				else
				{
					if (cubeIndex != 0)
					{
						previousRow[cubeIndex - 1].Right = cube;
					}
					if (cubeIndex != cubesPerRow - 1)
					{
						previousRow[cubeIndex].Left = cube;
					}
				}
				currentRow.Add(cube);
			}
			Content.Add(currentRow);
			previousRow = currentRow;
			cubesPerRow++;
			startPosition += new Vector3(1f, -1f, 0f);
		}
	}

	public List<CubeAbstract> GetStartRow()
	{
		return Content[StartRowIndex];
	}
}
