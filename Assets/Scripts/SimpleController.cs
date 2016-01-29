using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleController : MonoBehaviour
{
    Mountain Mountain;
    /// <summary>
    /// Input direction
    /// </summary>
    float Direction;

    Cube ActiveCube
    {
        get
        {
            return _ActiveCube;
        }
        set
        {
            if (_ActiveCube != null && _ActiveCube != value)
            {
                _ActiveCube.Neizgaismot();
            }
            _ActiveCube = value;
            if(_ActiveCube != null)
            {
                _ActiveCube.Izgaismot();
            }
        }
    }
    Cube _ActiveCube = null;

	// Use this for initialization
	void Start ()
    {
        Mountain = GameObject.FindGameObjectWithTag("Mountain").GetComponent<Mountain>();
        ActiveCube = GetStartCube();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float newDirection = Input.GetAxisRaw("Horizontal");
        if(newDirection != Direction)
        {
            Direction = newDirection;
            MoveToCube(Direction);
        }
	}

    void MoveToCube(float direction)
    {
        if (direction > 0f)
        {
            if (ActiveCube.Right != null)
            {
                ActiveCube = ActiveCube.Right;
            }
        }
        if(direction < 0f)
        {
            if (ActiveCube.Left != null)
            {
                ActiveCube = ActiveCube.Left;
            }
        }
    }

    Cube GetStartCube()
    {
        if (Mountain == null) { return null; }
        List<Cube> startRow = Mountain.GetStartRow();
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