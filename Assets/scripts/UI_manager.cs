using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_manager : MonoBehaviour
{
    // Start is called before the first frame update
   public void Playpvp()
    {
        SceneManager.LoadScene(1);
    }
}
