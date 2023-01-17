using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectTileParticles;
    [SerializeField] float range = 15f;
     Transform targed;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void AimWeapon()
    {
        float targedDistance = Vector3.Distance(transform.position, targed.position);
        weapon.LookAt(targed);

        if(targedDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void  FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closesTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targedDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targedDistance < maxDistance)
            {
                closesTarget = enemy.transform;
                maxDistance = targedDistance;
            }
        }
        
        targed = closesTarget;

    }

    void Attack(bool isActive)
    {
       var emissionModule = projectTileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
