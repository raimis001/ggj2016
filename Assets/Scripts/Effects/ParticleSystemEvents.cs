using UnityEngine;
using System.Collections;

public class ParticleSystemEvents : MonoBehaviour 
{
    public ParticleSystem ParticleSystem;

    private bool IsAlive = true;

    //Events
    public delegate void Event();
    public event Event OnComplete = null;

    public void Start()
    {
        //ParticleSystem = GetComponent<ParticleSystem>();
    }

    public void FixedUpdate()
    {
        if(ParticleSystem != null)
        {
            if(!ParticleSystem.IsAlive())
            {
                if(IsAlive)
                {
                    if(OnComplete != null)
                    {
                        OnComplete();
                    }
                }
                IsAlive = false;
            }
        }
    }
}
