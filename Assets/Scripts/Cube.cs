using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
    [HideInInspector]
    public Cube Left = null;
    [HideInInspector]
    public Cube Right = null;
    public Renderer Renderer = null;

    public bool Nāvējošs
    {
        get
        {
            return _Nāvējošs;
        }
        set
        {
            _Nāvējošs = value;
            if (_Nāvējošs == true)
            {
                SpīdētSarkanā();
            }
        }
    }
    bool _Nāvējošs = false;

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
        if (Nāvējošs) { return; }
        Renderer.material.color = Color.green;   
    }

    public void Neizgaismot()
    {
        if (Nāvējošs) { return; }
        Renderer.material.color = Color.white;
    }

    void SpīdētSarkanā()
    {
        Renderer.material.color = Color.red;
    }
}
