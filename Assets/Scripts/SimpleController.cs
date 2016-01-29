using UnityEngine;
using System.Collections;

public class SimpleController : MonoBehaviour
{

	public GameObject Player;

    Mountain Mountain;
    /// <summary>
    /// Input direction
    /// </summary>
    float Direction;
	Rigidbody playerBody;
	Animator playerAnimator;
	bool moving = false;

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
		Player.transform.position = ActiveCube.transform.position + new Vector3(-0.5f,0.5f,-0.5f);
		playerBody = Player.GetComponent<Rigidbody>();
		playerAnimator = Player.GetComponent<Animator>();
  }

	IEnumerator MoveChar(float direction)
	{
		if (moving)
		{
			yield break;
		}

		moving = true;

		Vector3 startPos = Player.transform.position;
		Vector3 endPos = startPos + new Vector3(direction < 0 ? 1 : 0, 0, direction > 0 ? 1 : 0);
		float dTime = 0.5f;
		float tmp = 0;
		while (tmp < dTime)
		{
			Player.transform.position = Vector3.Lerp(startPos, endPos, tmp / dTime);
			tmp += Time.smoothDeltaTime;
			yield return null;
		}

		moving = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float newDirection = Input.GetAxisRaw("Horizontal");
        if(newDirection != Direction)
        {
            Direction = newDirection;
			//playerBody.AddForce(new Vector3(50, 0, 0));
			//playerAnimator.SetTrigger("got");
			StartCoroutine(MoveChar(Direction));
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