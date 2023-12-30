using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
