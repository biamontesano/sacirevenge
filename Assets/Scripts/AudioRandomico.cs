using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomico : MonoBehaviour
{
    public AudioSource _as;
    public float timeInterval;

    public AudioClip[] audioClipArray;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();

    }

    private void Start()
    {
        _as.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        _as.PlayOneShot(_as.clip);
    }
}
