using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public bool ismyturn = true;
    public int count = 0;
    
    public Enum.MyEnum player1;
    public Enum.MyEnum player2;
    


    public static game_manager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void chance()
    {
        if(count % 2 == 0)
        {
            ismyturn = false;
            
        }
        else
        {
            ismyturn = true;
        }
    }
   

    public void SetPlayer(Enum.MyEnum enumType)
    {
        if(ismyturn)
        {
            player1 = enumType;
            if(player1 == Enum.MyEnum.Solid)
            {
                player2 = Enum.MyEnum.Stripes;
            }
            else if (player1 == Enum.MyEnum.Stripes)
            {
                player2 = Enum.MyEnum.Solid;
            }
            
        }
    }
}
