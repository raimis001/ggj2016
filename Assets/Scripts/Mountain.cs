using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mountain : MonoBehaviour
{
    public int Rows;
    public GameObject BlockModel;

	// Use this for initialization
	void Start ()
    {
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
        int cubesPerRow = 1;
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
                if (cubeIndex != 0)
                {
                    previousRow[cubeIndex - 1].Right = cube;
                }
                if(cubeIndex != cubesPerRow - 1)
                {
                    previousRow[cubeIndex].Left = cube;
                }
                currentRow.Add(cube);
            }
            previousRow = currentRow;
            cubesPerRow++;
            startPosition += new Vector3(1f, -1f, 0f);
        }
    }
}
