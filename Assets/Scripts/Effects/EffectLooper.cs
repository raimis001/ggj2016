using UnityEngine;
using System.Collections;

public class EffectLooper : MonoBehaviour 
{
    /// <summary>
    /// Stop looping for whole effect
    /// </summary>
    public void Stop(bool childrensToo = true)
    {
        Stop(transform, childrensToo);
    }

    /// <summary>
    /// Stop effect looping for this transform and its childrens
    /// </summary>
    /// <param name="transform">Objects transform to stop</param>
    public void Stop(Transform transform, bool childrensToo = true)
    {
        ParticleSystem system = transform.GetComponent<ParticleSystem>();
		system.Stop(childrensToo);
    }
}
