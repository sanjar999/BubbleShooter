using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    [SerializeField] private Material _mat;
    LaserBeam beam;

    void Update()
    {
        if (beam!= null)
        {
            Destroy(beam.laserObj);            
        }
        beam = new LaserBeam(transform.position, transform.up, _mat);
    }
}
