using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public ParticleSystem boosterParticles; 
    AudioSource audioSource;
    Rigidbody rg;
    public AudioClip roketboosterParticles;
    [SerializeField] float hiz = 1000f;
    [SerializeField] float rotationThrust = 100f; 
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody>() ;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessInput();
        ProcessRotation();
    }

    void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rg.AddRelativeForce(Vector3.up * hiz * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(roketboosterParticles);
            }
            if(!boosterParticles.isPlaying)
            {
                boosterParticles.Play();
            }
        }
        else
        {
            boosterParticles.Stop();
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
    }

    void ApplyRotation(float rotation)
    {
        rg.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotation);
        rg.freezeRotation = false;
    }
}