using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PlayerControler : MonoBehaviour
{


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Collision enetered:" + collision.gameObject.name);
	}
}
