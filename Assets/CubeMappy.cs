using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMappy : MonoBehaviour
{

CubeState cubeState;

public Transform up;
public Transform down;
public Transform left;
public Transform right;
public Transform front;
public Transform back;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set()
    {
        cubeState = FindObjectOfType<CubeState>();

        UpdateMap(cubeState.front, front);
       UpdateMap(cubeState.back, back);
        UpdateMap(cubeState.up, up);
        UpdateMap(cubeState.down, down);
        UpdateMap(cubeState.left, left);
        UpdateMap(cubeState.right, right);
     }

    void UpdateMap(List<GameObject> face, Transform side)
    {

        int i=0;
        foreach(Transform map in side)
        {

            if (face[i].name[0] == 'f')
            {
                map.GetComponent<Image>().color = new Color(1,0.5f,0,1);
            }            
               if (face[i].name[0] == 'b')
            {
                map.GetComponent<Image>().color = Color.red;
            }            
            if (face[i].name[0] == 'u')
            {
                map.GetComponent<Image>().color = Color.yellow;
            }            
            if (face[i].name[0] == 'd')
            {
                map.GetComponent<Image>().color = Color.white;
            }            
            if (face[i].name[0] == 'l')
            {
                map.GetComponent<Image>().color = Color.green;
            }            
            if (face[i].name[0] == 'r')
            {
                map.GetComponent<Image>().color = Color.blue;
            }
            i++;            
        }
    }
}
