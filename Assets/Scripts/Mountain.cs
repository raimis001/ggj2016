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
    public GameObject BlockModel;

    public List<Cube> FirstRow
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
    List<Cube> _FirstRow = new List<Cube>();
    /// <summary>
    /// All mountain rows with cubes
    /// </summary>
    public List<List<Cube>> Content = new List<List<Cube>>();

    // Use this for initialization
    void Awake()
    {
        StartRowIndex = Mathf.Clamp(StartRowIndex, 0, Rows - 1);
        Generate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Generate()
    {
        List<Cube> currentRow = null;
        List<Cube> previousRow = null;
        GameObject block;
        Cube cube;
        int cubesPerRow = CubesInFirstRow;
        //Start position for row
        Vector3 startPosition = Vector3.zero;
        Vector3 currentPosition = Vector3.zero;
        for(int row = 0; row < Rows; row++)
        {
            currentRow = new List<Cube>();
            currentPosition = startPosition;
            for (int cubeIndex = 0; cubeIndex < cubesPerRow; cubeIndex++)
            {
                //creation
                block = Instantiate(BlockModel);
                block.transform.position = currentPosition;
                currentPosition += new Vector3(-1f, 0f, 1f);
                //assigning self as move target
                cube = block.GetComponent<Cube>();
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

    public List<Cube> GetStartRow()
    {
        return Content[StartRowIndex];
    }
}
