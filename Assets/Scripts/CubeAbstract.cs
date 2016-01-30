using UnityEngine;
using System.Collections;

public abstract class CubeAbstract : MonoBehaviour
{
	public CubeAbstract Left  { get; set; }
	public CubeAbstract Right { get; set; }
	/*public Renderer Renderer
	{
		get
		{
			return _Renderer;
		}
		set
		{
			_Renderer = value;
		}
	}*/
	public Renderer Renderer = null;

	// Use this for initialization
	void Awake()
	{
		Renderer testRenderer = GetComponent<Renderer>();
		if (testRenderer != null)
		{
			Renderer = testRenderer; 
        }
	}

	public bool Nāvējošs
	{
		get
		{
			return _Nāvējošs;
		}
		set
		{
			_Nāvējošs = value;
		}
	}
	bool _Nāvējošs = false;

	public abstract void OnPlayerLanded();
	public abstract bool CanMoveTo();

	public virtual void Izgaismot()
	{
		Renderer.material.color = Color.green;
	}
	public virtual void Neizgaismot()
	{
		Renderer.material.color = Color.white;
	}
}
