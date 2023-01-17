using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower towerPrefab;
    public bool IsPlaceable{ get{ return isPlaceable; }}
   
     void OnMouseDown()
    {
        if (isPlaceable) {

            bool isPlaced =towerPrefab.CreateTower(towerPrefab, transform.position);
            //  Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = !isPlaced;
        }
    }
}
