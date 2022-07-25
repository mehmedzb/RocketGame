using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public ParticleSystem successParticle;
    public ParticleSystem crashParticle;
    public AudioClip success;
    public AudioClip crash;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start() 
    {
        audioSource = gameObject.GetComponent<AudioSource>();    
    }

    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly" :
                break;
            case "Finish" :
                StartSuccessSequence();
                break;
            case "Fuel" :
                break;    
            default:
                StartCrashSequence();
                break;
        }    
    }

    void StartCrashSequence()
    {
        if(!isTransitioning)
        {
            isTransitioning = true;
            audioSource.PlayOneShot(crash);
            crashParticle.Play();
        }
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel" , 1f);
    }

    void StartSuccessSequence()
    {
        if(!isTransitioning)
        {
            isTransitioning = true;
            audioSource.PlayOneShot(success);
            successParticle.Play();
        }
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel" , 1f);
    }

    void ReloadLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }

    void LoadNextLevel()
    {
        int getCurrentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = getCurrentLevel + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
