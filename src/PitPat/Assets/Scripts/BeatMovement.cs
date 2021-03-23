using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMovement : MonoBehaviour
{
    [SerializeField]
    private float beatTempo=60;

    private static bool hasStarted=false;
    private float beatSpeed;

    // Start is called before the first frame update
    void Start()
    {
        beatSpeed = beatTempo / 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted)
        {
            transform.position -= new Vector3(beatSpeed*Time.deltaTime, 0f, 0f);
        }
    }

    public static void Begin()
    {
        if(!hasStarted)
        {
            hasStarted = true;
        }
    }
}
