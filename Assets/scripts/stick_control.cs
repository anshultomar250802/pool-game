using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick_control : MonoBehaviour
{
    [SerializeField]
    public Transform cueBall;  // Reference to the cue ball transform
    Rigidbody rigidbody;
    
    public float maxShotStrength = 10f;  // Maximum shot strength
    
    private Vector3 initialPosition;     // Initial position of the cue stick
    private Quaternion initialRotation;  // Initial rotation of the cue stick
    [SerializeField]
    public GameObject cuestick;
    [SerializeField]
    public GameObject cueball;

    void Start()
    {
        rigidbody = cueball.gameObject.GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        cuestick.gameObject.SetActive(false);
        
    }

    void Update()
    {
        float speed = rigidbody.velocity.magnitude;
        if (speed < 0.0205)
        {
            cueappearance();
        }
        else
        {
            cuestick.gameObject.SetActive(false);
            // Reset the cue stick to its initial position and rotation
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }
    public void cueappearance()
    {
        cuestick.gameObject.SetActive(true);

        cuestick.gameObject.transform.position = new Vector3(cueBall.position.x, 7.91f, cueBall.position.z);
    }
}
