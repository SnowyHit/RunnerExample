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
         Debug.Log("Game Over");
         PlayerPrefs.SetInt("death", 1);
         if(hiScore < PlayerPrefs.GetInt("score"))
         {
           PlayerPrefs.SetInt("hiScore", PlayerPrefs.GetInt("score"));
         }
         PlayerPrefs.SetInt("score", 0);
       }

     }
}
