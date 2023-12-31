using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.PhysicsModule;

public class ReadCube : MonoBehaviour
{

    public Transform tUp;
    public Transform tDown;
    public Transform tFront;
    public Transform tBack;
    public Transform tLeft;
    public Transform tRight;

    // mysterious thing to go with putting prefab cube faces on a layer
    private int layerMask = 1 << 8; 

    CubeState cubeState;

    // Start is called before the first frame update
    void Start()
    {
        cubeState = FindObjectOfType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {


        List<GameObject> facesHit = new List<GameObject>();
        Vector3 ray = tFront.transform.position;
        print(ray);
        RaycastHit hit;

        if (Physics.Raycast(ray, tFront.right, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(ray, tFront.right * hit.distance, Color.yellow);
            facesHit.Add(hit.collider.gameObject);
        } else {
            Debug.DrawRay(ray, tFront.right * 1000, Color.green);
        }

    }
}
