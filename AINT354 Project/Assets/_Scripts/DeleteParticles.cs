using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeleteParticles : MonoBehaviour
{
    [SerializeField] AudioClip[] deathSounds;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        int n = Random.Range(0, deathSounds.Length);

        audio.clip = deathSounds[n];
        audio.PlayOneShot(audio.clip);

        Destroy(gameObject, 2f);
    }
}
