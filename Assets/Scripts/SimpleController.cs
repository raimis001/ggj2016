using UnityEngine;
using System.Collections;

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

            Debug.Log("AC");
            if (_ActiveCube != null && _ActiveCube != value)
            {
                Debug.Log("neizg");
                _ActiveCube.Neizgaismot();
            }
            _ActiveCube = value;
            if(_ActiveCube != null)
            {
                Debug.Log("izg");
                _ActiveCube.Izgaismot();
            }
        }
    }
    Cube _ActiveCube = null;

	// Use this for initialization
	void Start ()
    {
        Mountain = GameObject.FindGameObjectWithTag("Mountain").GetComponent<Mountain>();
        ActiveCube = Mountain.Root;
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
            else
            {
                Debug.Log("nav labā");
            }
        }
        if(direction < 0f)
        {
            if (ActiveCube.Left != null)
            {
                ActiveCube = ActiveCube.Left;
            }
            else
            {
                Debug.Log("nav kreisā");
            }
        }
    }
}