using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public SongData song;
    public AudioSource audioSource;

    void Start()
    {
        transform.position = Vector3.forward * (song.speed * GameManager.instance.startTime);
        Invoke("StartSong", GameManager.instance.startTime - song.startTime);
    }

    void StartSong()
    {
        audioSource.PlayOneShot(song.song);
        Invoke("SongIsOver", song.song.length);
    }

    void Update()
    {
        transform.position += Vector3.back * song.speed * Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        for(int i = 0; i < 100; i++)
        {
            float beatLength = 60f / (float)song.bpm;
            float beatDist = beatLength * song.speed;

            Gizmos.DrawLine(transform.position + new Vector3(-1, 0, i * beatDist), transform.position + new Vector3(1, 0, i * beatDist));
        }
    }

    void SongIsOver()
    {
        GameManager.instance.WinGame();
    }
}
