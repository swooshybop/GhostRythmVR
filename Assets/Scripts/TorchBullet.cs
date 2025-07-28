using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TorchBullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            other.GetComponent<GhostManager>()?.TryBanish(BanishMethod.FlashTorch);
            Destroy(gameObject);
        }
    }
}
