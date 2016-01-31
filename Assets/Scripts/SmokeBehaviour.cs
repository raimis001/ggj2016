using UnityEngine;
using System.Collections;

public class SmokeBehaviour : MonoBehaviour
{
	/// <summary>
	/// Will smoke while target is alive and follow target
	/// </summary>
	[HideInInspector]
	public Transform Target = null;

	EffectLooper Looper;
	ParticleSystemEvents ParticleEvents;

	// Use this for initialization
	void Start()
	{
		Looper = GetComponent<EffectLooper>();
		ParticleEvents = GetComponent<ParticleSystemEvents>();
		ParticleEvents.OnComplete += ParticleEvents_OnComplete;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if(Target != null)
		{
			transform.position = Target.transform.position + new Vector3(0.5f, 0.8f, 0.5f);
		}
		if(Target == null)
		{
			Looper.Stop();
		}
	}

	private void ParticleEvents_OnComplete()
	{
		GameObject.Destroy(gameObject);
	}
}
