using UnityEngine;

public class hole : MonoBehaviour
{
    [SerializeField]
    public GameObject cueball;
    [SerializeField]
    public GameObject[] colorballArray = new GameObject[15];
    [SerializeField]
    public Transform wiremesh;
    public bool isfirsthit = true;
    public bool legalbreak = false;
    [SerializeField]
    public Transform blackball;
    public int ballsleft;
    public bool islasthit = false;
    public Enum.MyEnum enumType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("fn called");
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("solid") || other.gameObject.CompareTag("stripes") && !other.gameObject.CompareTag("8") && !other.gameObject.CompareTag("mainball"))
        {
            
            legalbreak = true;
            enumType = other.gameObject.GetComponent<colorball>().enumType;
            if (isfirsthit)
            {
                isfirsthit = false;
                game_manager.instance.SetPlayer(enumType);
            }
            
            Destroy(other.gameObject);
            enumType = Enum.MyEnum.None;
            legalbreak = false;
        }




        else if (other.gameObject.CompareTag("8") && isfirsthit == true)
        {
            other.transform.position = blackball.position;
        }
        else if (other.gameObject.CompareTag("1") )
        {

        }
        else if (other.gameObject.CompareTag("4"))
        {

        }
        else if (other.gameObject.CompareTag("5"))
        {

        }
        else if (other.gameObject.CompareTag("6"))
        {

        }
        else if (other.gameObject.CompareTag("7"))
        {

        }
        else if (other.gameObject.CompareTag("8"))
        {

        }
        else if (other.gameObject.CompareTag("9"))
        {

        }
        else if (other.gameObject.CompareTag("10"))
        {

        }
        else if (other.gameObject.CompareTag("11"))
        {

        }
        else if (other.gameObject.CompareTag("12"))
        {

        }
        else if (other.gameObject.CompareTag("13"))
        {

        }
        else if (other.gameObject.CompareTag("14"))
        {

        }
        else if (other.gameObject.CompareTag("15"))
        {
         
        }
        else if (other.gameObject.CompareTag("1"))
        {

        }
        
    }
    /*public BallGroup CheckBallGroup(GameObject ball)
    {
        
        if (ball.CompareTag("Solid"))
            return BallGroup.Solids;
        else if (ball.CompareTag("Stripes"))
            return BallGroup.Stripes;
        else
            return BallGroup.black;
    }*/
}
