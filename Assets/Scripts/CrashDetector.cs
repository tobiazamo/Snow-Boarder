using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float timeDelayBeforeRestart = 1f;
    [SerializeField] ParticleSystem crashEffect;

    [SerializeField] ParticleSystem snowSlideEffect;

    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player Head" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", timeDelayBeforeRestart);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            snowSlideEffect.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            snowSlideEffect.Stop();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
