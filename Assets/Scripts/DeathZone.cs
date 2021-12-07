using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    AudioSource Death;

    void Start()
    {
        Death = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("DeathZone"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            Death.Play();
        }
    }

    private static void Play()
    {
        throw new NotImplementedException();
    }
}
