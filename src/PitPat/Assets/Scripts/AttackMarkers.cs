using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMarkers : MonoBehaviour
{
    [SerializeField]
    private GameObject pooledObject;
    [SerializeField]
    private int initialSize;
    [SerializeField]
    private bool growIfFull;
    [SerializeField]
    private float timeUntilRemoval;

    private ObjectPool markerPool;
    private List<GameObject> activeMarkers=new List<GameObject>();
    private List<float> markerDeletionTimes=new List<float>();

    private float timer=0;

    // Start is called before the first frame update
    void Start()
    {
        markerPool = new ObjectPool(pooledObject, initialSize, growIfFull);
        markerPool.Initialize();
    }

    public void AddMarker(Vector3 position)
    {
        GameObject marker = markerPool.GetPooledObject();
        marker.transform.position = position;
        if(activeMarkers.Contains(marker))
        {
            markerDeletionTimes[activeMarkers.IndexOf(marker)] = timer + timeUntilRemoval;
        }
        else
        {
            activeMarkers.Add(marker);
            markerDeletionTimes.Add(timer + timeUntilRemoval);
        }
        marker.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        foreach(GameObject marker in activeMarkers)
        {
            //Compares the deletion time of every active marker and deactivates them if necessary 
            if(markerDeletionTimes[activeMarkers.IndexOf(marker)]<=timer)
            {
                marker.SetActive(false);
            }
        }
    }
}
