using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    public Transform target;
    
    bool moving;

    List<Transform> waypoints = new List<Transform>();
    int currWaypoint = -1;

    public float lerpTime;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] waypointArray = GameObject.FindGameObjectsWithTag("Point");

        foreach(GameObject o in waypointArray)
        {
            waypoints.Add(o.transform);
        }
    }

   IEnumerator Move()
    {
        moving = true;
        currWaypoint++;
        target = waypoints[currWaypoint];
        
        while((transform.position - target.position).magnitude > 0.5f)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, target.position, lerpTime);
            transform.position = newPosition;

            yield return new WaitForEndOfFrame();
        }

        moving = false;
    }



    private void OnTriggerStay(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            if (currWaypoint < waypoints.Count && !moving)
            {
                StopAllCoroutines();
                StartCoroutine(Move());
            }
        }
    }

}
