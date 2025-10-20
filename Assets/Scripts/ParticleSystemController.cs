using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    ParticleSystem myParticleSystem;

    void Start()
    {
        myParticleSystem = GetComponentInChildren<ParticleSystem>();    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        myParticleSystem.Play();
    }

    void OnCollisionExit2D(Collision2D other)
    {
        myParticleSystem.Stop();    
    }
}
