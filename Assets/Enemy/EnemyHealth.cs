using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to Maxhitpoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;

    Enemy enemy;


     void Start()
    {
        enemy = GetComponent<Enemy>();  
    }
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
   
    
    void OnParticleCollision(GameObject other)
    {
        ProccesHit();   
    }

    void ProccesHit()
    {
        currentHitPoints--;
        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
