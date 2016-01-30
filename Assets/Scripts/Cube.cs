using UnityEngine;
using System.Collections;
using System;

public class Cube : CubeAbstract
{
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
