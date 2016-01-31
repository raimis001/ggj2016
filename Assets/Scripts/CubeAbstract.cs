using UnityEngine;
using System.Collections;

public abstract class CubeAbstract : MonoBehaviour
{
	/// <summary>
	/// Index for row
	/// </summary>
	public int Row = 0;
	/// <summary>
	/// Index for place in row
	/// </summary>
	public int Index = 0;

	public CubeAbstract Left
	{
		get
		{
			if (Mountain == null) { return null; }
			if (Row >= Mountain.Konfigurācija.Rindas - 1) { return null; }
			return Mountain.Content[Row + 1][Index];
		}
	}
	public CubeAbstract Right
	{
		get
		{
			if (Mountain == null) { return null; }
			if (Row >= Mountain.Konfigurācija.Rindas - 1) { return null; }
			return Mountain.Content[Row + 1][Index + 1];
		}
	}
	/// <summary>
	/// From last mountain row to plain
	/// </summary>
	public CubeAbstract LeftToPlain
	{
		get
		{
			if (!IsInLastRow()) { return null; }
			int count = Mountain.Plains.Count;
            return Mountain.Plains[Index];
		}
	}
	/// <summary>
	/// From last mountain row to plain
	/// </summary>
	public CubeAbstract RightToPlain
	{
		get
		{
			if (!IsInLastRow()) { return null; }
			return Mountain.Plains[Index + 1];
		}
	}

	public Renderer Renderer = null;

	protected Mountain Mountain = null;

	// Use this for initialization
	void Awake()
	{
		Renderer testRenderer = GetComponent<Renderer>();
		if (testRenderer != null)
		{
			Renderer = testRenderer;
		}
	}

	protected virtual void Start()
	{
		Mountain = GameObject.FindGameObjectWithTag("Mountain").GetComponent<Mountain>();
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
		if (Renderer == null) { return; }
		Renderer.material.color = Color.green;
	}
	public virtual void Neizgaismot()
	{
		if (Renderer == null) { return; }
		Renderer.material.color = Color.white;
	}

	/// <summary>
	/// Death animation
	/// </summary>
	public virtual void Burn()
	{

	}

	/// <summary>
	/// Cube in last mountain row
	/// </summary>
	bool IsInLastRow()
	{
		if (Mountain == null) { return false; }
		if (Row != Mountain.Konfigurācija.Rindas - 1) { return false; }
		return true;
	}
}
