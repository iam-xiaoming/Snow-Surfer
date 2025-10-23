using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] ParticleSystem surferParticleSystem;
    [SerializeField] ParticleSystem pickUpParticleSystem;

    void OnCollisionEnter2D(Collision2D other)
    {
        surferParticleSystem.Play();
    }

    void OnCollisionExit2D(Collision2D other)
    {
        surferParticleSystem.Stop();    
    }

    public void ActivatePickupParticle()
    {
        pickUpParticleSystem.Play();
    }

    public void DeactivatePickupParticle()
    {
        pickUpParticleSystem.Stop();
    }
}
