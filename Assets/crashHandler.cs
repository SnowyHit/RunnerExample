using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashHandler : MonoBehaviour
{
    // Start is called before the first frame update
    int hiScore;
    int currentScore;

    void Start()
    {
      hiScore = PlayerPrefs.GetInt("hiScore" , 0);

    }

    private void OnTriggerEnter(Collider other)
     {
       if(other.tag == "Player")
       {
         if(PlayerPrefs.GetInt("lives", 3) == 1)
         {
           Debug.Log("Game Over");
           PlayerPrefs.SetInt("death", 1);
           if(hiScore < PlayerPrefs.GetInt("score"))
           {
             PlayerPrefs.SetInt("hiScore", PlayerPrefs.GetInt("score"));
           }
           PlayerPrefs.SetInt("score", 0);
           PlayerPrefs.SetInt("lives", 3);
         }
         else
         {
           PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1 );
         }

       }

     }
}
