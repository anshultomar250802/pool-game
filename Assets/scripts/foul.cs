using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foul : MonoBehaviour
{
    [SerializeField]
    List<GameObject> pockets;
    [SerializeField]
    GameObject cueball;
    bool IsCueBallPocketed()
    {
        foreach (GameObject pocket in pockets)
        {
            // Calculate the distance between the cue ball and the pocket
            float distance = Vector3.Distance(cueball.gameObject.transform.position, pocket.transform.position);

            // Assuming the pocket has a trigger collider, check if the cue ball is inside the pocket
            if (distance < pocket.GetComponent<Collider>().bounds.size.x / 2f)
            {
                return true; // Cue ball is pocketed
                Debug.Log("cueball pocket");
            }
        }

        return false; // Cue ball is not pocketed
    }
}
