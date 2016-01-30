using UnityEngine;
using System.Collections;
using System;

public class GrassCube : CubeAbstract
{
	public Item Item;

	public Material[] Grass;
	public GameObject GrassObject;

	void Start()
	{
		GrassObject.GetComponent<Renderer>().sharedMaterial = Grass[UnityEngine.Random.Range(0, Grass.Length)];
	}

	public void AddItem(GameObject item)
	{
		if (Item)
		{
			Destroy(Item.gameObject);
		}

		GameObject obj = Instantiate(item);
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localScale = Vector3.one;
		obj.transform.SetParent(transform);
	}

	public override bool CanMoveTo()
	{
		return true;
	}

	public override void Izgaismot()
	{
		throw new NotImplementedException();
	}

	public override void Neizgaismot()
	{
		throw new NotImplementedException();
	}

	public override void OnPlayerLanded()
	{
		if (Item != null)
		{
			Item.OnItemTake();
    }
	}


	// Update is called once per frame
	void Update()
	{

	}
}
