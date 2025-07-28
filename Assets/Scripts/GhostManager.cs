using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GhostType 
{
    Hat,
    Plain
}

public enum BanishMethod
{
    SwordSlice,
    FlashTorch
}


public class GhostManager : MonoBehaviour
{
    public GhostType ghostType;
    public BanishMethod method;

    [SerializeField] ParticleSystem smokePrefab;
    [SerializeField] AudioClip[] deathClips;
    AudioSource sfx;

    void Awake()
    {
        sfx = gameObject.AddComponent<AudioSource>();
        sfx.spatialBlend = 1;
        sfx.rolloffMode = AudioRolloffMode.Linear;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            TryBanish(BanishMethod.SwordSlice);
        }
    }

    public void BanishGhost()
    {
        if (smokePrefab)
        {
            Instantiate(smokePrefab, transform.position, Quaternion.identity);
        }

        if(deathClips.Length > 0)
        {
            sfx.PlayOneShot(deathClips[Random.Range(0, deathClips.Length)]);
        }

        spawner?.NotifyGhostGone(myWave, this);
        Destroy(gameObject);
    }

    public void TryBanish(BanishMethod input)
    {
        bool correct = input == method;

        if(input == BanishMethod.SwordSlice || input == BanishMethod.FlashTorch)
        {
            if (correct)
            {
                GameManager.instance.AddScore();
            }
            else
            {
                GameManager.instance.HitWrongGhost();
            }

            BanishGhost();
        }
    }

    GhostSpawner spawner;
    GhostSpawner.Wave myWave;

    public void RegisterWave(GhostSpawner sp, GhostSpawner.Wave wave)
    {
        spawner = sp;
        myWave = wave;
    }
}
