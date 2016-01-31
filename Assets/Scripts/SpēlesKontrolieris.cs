using UnityEngine;
using System.Collections;

public class SpēlesKontrolieris : MonoBehaviour
{
	public static SpēlesKontrolieris Instance;

	public Līmeņi Līmeņi;

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
