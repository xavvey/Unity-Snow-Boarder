using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadSceneDelay = 1f;
    [SerializeField] ParticleSystem finishParticle;
    int nextSceneIndex;

    private void Start() 
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {   
            finishParticle.Play();
            Invoke("LoadNextScene", loadSceneDelay); 
        }
    }

    void LoadNextScene()
    {
        if (SceneManager.sceneCountInBuildSettings < nextSceneIndex + 1)
        {
            SceneManager.LoadScene(0); // for now load IntroScene upon completion
        } 
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
