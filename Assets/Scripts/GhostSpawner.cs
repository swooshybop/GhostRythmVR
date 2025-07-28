using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField] Transform[] lanes;

    [SerializeField] GameObject[] hatPrefab;
    [SerializeField] GameObject[] plainPrefab;

    [SerializeField] float rowSpacing = 2f;
    [SerializeField] int rowsAlive = 2;

    readonly Queue<Wave> activeWaves = new();
    float nextZ;
    void Start()
    {
        nextZ = lanes[0].position.z;

        for(int i = 0; i < rowsAlive; i++)
        {
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        var wave = new Wave();

        int ghostCount = Random.Range(1,3);
        for(int i = 0; i < ghostCount; i++)
        {
            bool hat = Random.value < 0.5f; // 50% spawn chance
            GameObject prefab = hat ? hatPrefab[Random.Range(0, hatPrefab.Length)] : plainPrefab[Random.Range(0, plainPrefab.Length)];

            Transform laneTr = lanes[i];
            Vector3 spawnPos = laneTr.position;
            spawnPos.z = nextZ;

            GameObject spawns = Instantiate(prefab, spawnPos, laneTr.rotation, laneTr);
            GhostManager gm = spawns.GetComponent<GhostManager>();
            gm.RegisterWave(this, wave);

            wave.ghosts.Add(gm);
        }

        activeWaves.Enqueue(wave);
        nextZ += rowSpacing;
    }

    public void NotifyGhostGone(Wave wave, GhostManager who)
    {
        wave.ghosts.Remove(who);

        if(wave.ghosts.Count == 0 && activeWaves.Peek() == wave)
        {
            activeWaves.Dequeue();
            SpawnWave();
        }
    }

    public class Wave
    {
        public readonly List<GhostManager> ghosts = new();
    }

}
