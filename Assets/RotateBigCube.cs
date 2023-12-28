using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    
    public GameObject target; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
    }

    void Swipe(){
        if (Input.GetMouseButtonDown(1))
        {
            // get the 2D position of the first mouse click 
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            print(firstPressPos);
        }
        if (Input.GetMouseButtonUp(1))
        {
            // get the 2D position of the second mouse click 
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            
            // create a vector from the first and second click positions
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            currentSwipe.Normalize();


        }
    }

        bool IsSmallYMovement()
        {
            return currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
        }

        bool LeftSwipe()
        {
            return currentSwipe.x < 0 && IsSmallYMovement(); 
        }


        bool RightSwipe()
        {
            return currentSwipe.x > 0 && IsSmallYMovement(); 
        }


}
