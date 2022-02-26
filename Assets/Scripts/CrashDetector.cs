using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadSceneDelay = 1f;
    [SerializeField] ParticleSystem crashParticle;
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground")
        {
            crashParticle.Play();
            Invoke("ReloadScene", loadSceneDelay);        
        }    
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
