using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontroller : MonoBehaviour
{
    [SerializeField]
    public GameObject mainball;
    Rigidbody mainRigid;
    Vector3 defaultballposition = new Vector3();
    Vector3 mouseposition = new Vector3();
    [SerializeField]
    public float power = 0.15f;
    [SerializeField]
    List<colorball> balllist = new List<colorball>();
    [SerializeField]
    Transform arrow;
    [SerializeField]
    public GameObject cuestick;
    [SerializeField]
    private GameObject cueStickInstance;
    [SerializeField]
    Transform cue;
    public float cueStickOffset = 2f;
    private bool isCueStickActive = false;
    [SerializeField]
    public float decelerationForce = 0.5f;
    [SerializeField]
    public float rotationX = 2f;
    [SerializeField]
    public float maxdistance = 10f;
    public Color linecolor = Color.white;
    public LineRenderer pathrenderer;
    [SerializeField]
    public int numpoints = 50;
    [SerializeField]
    public float spacing = 0.1f;
    [SerializeField]
    Transform mainBall;
    private Camera mainCamera;
    public float ballMoveSpeed = 10f;
    [SerializeField]
    public Transform resetpos;
    [SerializeField]
    public float sensi = 0.05f;
    private bool ballinhand = false;
    private bool hasCollidedWithOtherBalls = false;
    Vector3 startTouch = new Vector3();
    public enum States
    {
        SOLID,
        STRIPE
    }
    public static States state;

    // Start is called before the first frame update
    void Start()
    {

        mainRigid = mainball.GetComponent<Rigidbody>();
        defaultballposition = mainball.transform.localPosition;
        //mainRigid.AddForce(new Vector3(50f, 0, 0));
        arrow.gameObject.SetActive(false);
        mainCamera = Camera.main;
        resetpos = mainBall.transform.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballinhand)
        {
            if(Input.GetMouseButton(0))          
              ballInhand();
              ballstop();
              cuestick.gameObject.SetActive(false);
            if (Input.GetMouseButtonUp(0))
            {
                mainBall.position = new Vector3(mouseposition.x , 8.503f, mouseposition.z - 11.15f);
                ballinhand = false;
                ballmove();
                
            }
        }
        else
        {
            
            CueStickMovement();
            speedcontrol();
            //cuestick.gameObject.SetActive(true);
        }
        
       
    }
    public void CueStickMovement()
    {
        if (mainball.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseposition = Input.mousePosition;
                //arrow.gameObject.SetActive(true);

            }

            if (Input.GetMouseButton(0) == true)
            {
                Vector3 upposition = Input.mousePosition;
                Vector3 add = mouseposition - upposition;
                Vector3 def = new Vector3(-add.y, 0, add.x);

                var distance = def.magnitude;
                var direction = def / distance;

                Quaternion rot = Quaternion.Euler(direction.normalized);


                Quaternion rotation = Quaternion.LookRotation(direction.normalized);



                rotation *= rot;

                cuestick.gameObject.transform.rotation = rotation;
                Path();

            }

            if (Input.GetMouseButtonUp(0) == true)
            {
                // vector from start position to end position for calculating the direction of striking cue bal
                forcemove();
                game_manager.instance.count++;

            }
        }
    }
    public void forcemove()
    {
        Vector3 upposition = Input.mousePosition;
        Vector3 def = mouseposition - upposition;

        Vector3 add = new Vector3(def.x, 0, def.y);
        mainRigid.AddForce(add * power);
        arrow.gameObject.SetActive(false);
        pathrenderer.enabled = false;
    }
    public void speedcontrol()
    {
        float speed = mainRigid.velocity.magnitude;
        if (speed < 0.255)
        {
            mainRigid.velocity = new Vector3();
            mainball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        }
    }
    /*public void mouserotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limit the rotation angle

        // Apply rotation to the object (e.g., camera or player)
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Apply horizontal rotation to the parent object if necessary
        transform.parent.transform.Rotate(Vector3.up * mouseX);
    }*/
    //CREATE PATH FOR THE BALL
    public void Path()
    {
        Vector3 startingPoint = mainBall.transform.position;
        Vector3 rayDirection = cuestick.transform.right;

        // Cast a ray
        RaycastHit hit;
        if (Physics.Raycast(startingPoint, rayDirection, out hit, maxdistance))
        {
            // Get the hit point
            Vector3 hitPoint = hit.point;

            // Draw the path using Line Renderer
            DrawPath(startingPoint, hitPoint);
        }

    }
    private void DrawPath(Vector3 startPos, Vector3 endPos)
    {
        Vector3[] points = new Vector3[numpoints];

        Vector3 direction = (endPos - startPos).normalized;
        float distance = Vector3.Distance(startPos, endPos);

        for (int i = 0; i < numpoints; i++)
        {
            float t = i / (float)(numpoints - 1);
            float currentDistance = t * distance;

            Vector3 point = startPos + direction * currentDistance;
            points[i] = point;
        }

        pathrenderer.positionCount = numpoints;
        pathrenderer.SetPositions(points);
        pathrenderer.enabled = true;
        pathrenderer.startColor = linecolor;
        pathrenderer.endColor = linecolor;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("pocket"))
        {
            
            mainball.transform.position = new Vector3(-7f, 8.503f, -2.81f);
            //ballstop();
            ballinhand = true;
            Debug.Log("step1");
        }
        /*else if (!collision.gameObject.CompareTag("main"))
        {
            ballinhand = true;
        }
        else if (!collision.gameObject.CompareTag("1") && !collision.gameObject.CompareTag("2") && !collision.gameObject.CompareTag("3") && !collision.gameObject.CompareTag("4") && !collision.gameObject.CompareTag("5") && !collision.gameObject.CompareTag("6") && !collision.gameObject.CompareTag("7") || !collision.gameObject.CompareTag("wall"))
        {
            ballinhand = true;
        }
        else if(!collision.gameObject.CompareTag("9") && !collision.gameObject.CompareTag("10") && !collision.gameObject.CompareTag("11") && !collision.gameObject.CompareTag("12") && !collision.gameObject.CompareTag("13") && !collision.gameObject.CompareTag("14") && !collision.gameObject.CompareTag("15"))
        {
            ballinhand = true;
        }*/
    }
    /*private void OnMouseDrag()
    {
        Vector3 mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z + transform.position.z);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousepos);
        transform.position = objPos;
        mainRigid.isKinematic = true;
    }*/
    public void ballstop()
    {
        mainBall.GetComponent<Rigidbody>().isKinematic = true;
        mainBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        mainBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    public void ballmove()
    {
        mainBall.GetComponent<Rigidbody>().isKinematic = false;
        // mainBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // mainBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    public void ballInhand()
    {
        mouseposition = new Vector3(Input.mousePosition.x*sensi + 7f, 8.503f, Input.mousePosition.y*sensi + 2.81f);
        mainball.transform.position = mouseposition;
        mouseposition.x = Mathf.Clamp(mouseposition.x, -20.6f, 30.828f);
        mouseposition.z = Mathf.Clamp(mouseposition.z, 11.7f, -31.3f);
    }
    public void teamselection()
    {
        /*7f 2.81f*/
    }
   
}

