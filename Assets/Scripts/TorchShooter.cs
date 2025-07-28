using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TorchShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzle;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float bulletLife = 2f;

    [SerializeField] InputActionProperty trigger;

    void OnEnable()
    {
        trigger.action.Enable();
    }

    void OnDisable()
    {
        trigger.action.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        if (trigger.action.WasPerformedThisFrame())
        {
            Fire();
        }
    }

    void Fire()
    {
        var shoot = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        var rigidbdy = shoot.GetComponent<Rigidbody>();

        rigidbdy.velocity = muzzle.forward * bulletSpeed;

        Destroy(shoot, bulletLife);
    }
}
