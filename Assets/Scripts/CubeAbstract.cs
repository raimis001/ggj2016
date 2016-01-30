using UnityEngine;
using System.Collections;

public abstract class CubeAbstract : MonoBehaviour
{
	

	public CubeAbstract Left  { get; set; }
	public CubeAbstract Right { get; set; }

	public abstract void OnPlayerLanded();
	public abstract bool CanMoveTo();
	public abstract void Izgaismot();
	public abstract void Neizgaismot();
}
