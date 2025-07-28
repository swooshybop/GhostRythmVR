using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            other.GetComponent<GhostManager>().BanishGhost();
            GameManager.instance.MissGhost();
        }
    }
}
