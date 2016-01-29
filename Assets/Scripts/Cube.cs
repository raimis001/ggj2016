using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
    [HideInInspector]
    public Cube Left = null;
    [HideInInspector]
    public Cube Right = null;
    Renderer Renderer = null;

	// Use this for initialization
	void Awake ()
    {
	    Renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Izgaismot()
    {
        Renderer.material.color = Color.green;   
    }

    public void Neizgaismot()
    {
        Renderer.material.color = Color.white;
    }
}
