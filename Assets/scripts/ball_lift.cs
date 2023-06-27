using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_lift : MonoBehaviour
{
    public bool isInHand = true;
    public GameObject cueBall;
    public float ballMoveSpeed = 10f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isInHand)
        {
            //MoveCueBallWithMouse();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleBallInHandState();
            Debug.Log("inhand");
        }
    }

    void ToggleBallInHandState()
    {
        isInHand = !isInHand;
        // TODO: Implement logic to show/hide a visual indicator (e.g., a hand icon) to indicate the ball is in hand or not.
    }
   /* void MoveCueBallWithMouse()
    {

        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Mathf.Abs(mainCamera.transform.position.z)));

        // Move the cue ball smoothly towards the mouse position
        cueBall.transform.position = Vector3.Lerp(cueBall.transform.position, mouseWorldPosition, Time.deltaTime * ballMoveSpeed);
        Debug.Log("foul");

    }
    */


}



