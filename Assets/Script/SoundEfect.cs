using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEfect : MonoBehaviour
{
    private AudioSource _audioSource;
    // Start is called before the first frame update
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            _audioSource.Play();
        }
    }
}
