using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorball : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> color = new List<GameObject>();
    Rigidbody rigidBody;
    Vector3 defaultposition = new Vector3();
    public string type;

    [SerializeField]
    private bool isfirst = true;
    public enum Player
    {
        One,
        Two
    }

    public Enum.MyEnum enumType;

    
    public Player player;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        defaultposition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        speedcontrol();
        //Reset();
        
    }
    public void Reset()
    {
        gameObject.SetActive(true);
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        this.transform.localPosition = defaultposition;
    }
    public void speedcontrol()
    {
        
        float speed = rigidBody.velocity.magnitude;
        if (speed < 0.255)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; ;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
    public void AssignToPlayer(Player player)
    {
        this.player = player;
        // Additional logic for ball assignment to player
    }

    /*public void AssignToGroup(BallGroup group)
    {
        this.group = group;
        // Additional logic for ball assignment to group
    }*/
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("pocket"))
        {
            if(type == "solid")
            {
                ballcontroller.state = ballcontroller.States.SOLID;
            }
            else if(type == "stripe")
            {
                ballcontroller.state = ballcontroller.States.STRIPE;
            }
        }
    }*/
    public void ballassign()
    {
        for (int i = 0; i < color.Count; i++)
        {
            if(i < 8)
            {
                
            }
        }
    }
    


}
