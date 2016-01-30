using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mountain : MonoBehaviour
{
	public KalnaApraksts KalnaApraksts = null;
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
		KalnaApraksts.StartRowIndex = Mathf.Clamp(KalnaApraksts.StartRowIndex, 0, KalnaApraksts.Rows - 1);
		Generate();
	}

	public void Generate()
	{
		List<CubeAbstract> currentRow = null;
		List<CubeAbstract> previousRow = null;
		GameObject block;
		CubeAbstract cube;
		int cubesPerRow = KalnaApraksts.CubesInFirstRow;
		//Start position for row
		Vector3 startPosition = Vector3.zero;
		Vector3 currentPosition = Vector3.zero;
		for (int row = 0; row < KalnaApraksts.Rows; row++)
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
		return Content[KalnaApraksts.StartRowIndex];
	}
}
