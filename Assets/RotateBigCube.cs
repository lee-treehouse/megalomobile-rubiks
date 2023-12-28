using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public GameObject target;

    float speed = 200f;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        Swipe();

        // automatically move to the target position
        if (transform.rotation != target.transform.rotation)
        {
            var step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                target.transform.rotation,
                step
            );
        }
    }

    void Swipe()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // get the 2D position of the first mouse click
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(1))
        {
            // get the 2D position of the second mouse click
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            // create a vector from the first and second click positions
            currentSwipe = new Vector2(
                secondPressPos.x - firstPressPos.x,
                secondPressPos.y - firstPressPos.y
            );

            currentSwipe.Normalize();

            if (IsLeftSwipe())
            {
                target.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (IsRightSwipe())
            {
                target.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (IsUpLeftSwipe())
            {
                target.transform.Rotate(90, 0, 0, Space.World);
            }
            else if (IsUpRightSwipe())
            {
                target.transform.Rotate(0, 0, -90, Space.World);
            }
            else if (IsDownLeftSwipe())
            {
                target.transform.Rotate(0, 0, 90, Space.World);
            }
            else if (IsDownRightSwipe())
            {
                target.transform.Rotate(-90, 0, 0, Space.World);
            }
        }
    }

    bool IsSmallYMovement()
    {
        return currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool IsLeftSwipe()
    {
        return currentSwipe.x < 0 && IsSmallYMovement();
    }

    bool IsRightSwipe()
    {
        return currentSwipe.x > 0 && IsSmallYMovement();
    }

    bool IsUpLeftSwipe()
    {
        // seems to overlap with isleftswipe
        // and why do we sometimes compare with 0 and sometimes with 0f
        return currentSwipe.y > 0 && currentSwipe.x < 0f;
    }

    bool IsUpRightSwipe()
    {
        return currentSwipe.y > 0 && currentSwipe.x > 0f;
    }

    bool IsDownLeftSwipe()
    {
        return currentSwipe.y < 0 && currentSwipe.x < 0f;
    }

    bool IsDownRightSwipe()
    {
        return currentSwipe.y < 0 && currentSwipe.x > 0f;
    }
}
