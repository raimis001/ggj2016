using UnityEngine;
using System.Collections;
using System;

public class Cube : CubeAbstract
{

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
	void Awake()
	{
		Renderer = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public override void Izgaismot()
	{
		if (Nāvējošs) { return; }
		Renderer.material.color = Color.green;
	}

	public override void Neizgaismot()
	{
		if (Nāvējošs) { return; }
		Renderer.material.color = Color.white;
	}

	void SpīdētSarkanā()
	{
		Renderer.material.color = Color.red;
	}

	public override void OnPlayerLanded()
	{
	}

	public override bool CanMoveTo()
	{
		return true;
	}
}
