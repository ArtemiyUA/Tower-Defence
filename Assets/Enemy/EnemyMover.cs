using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;

     void Start()
    {
        enemy = GetComponent<Enemy>();  
    }
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FolloPath());
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(waypoint != null)
            {
                path.Add(waypoint);
            }
            
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    IEnumerator FolloPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 starPosition = transform.position;
            Vector3 endPossition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPossition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
               transform.position = Vector3.Lerp(starPosition, endPossition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            
        }

        FinishPath();
    }
}
