using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string direction;
    private float row;
    public float SideMoveSpeed;

    private void Awake()
    {
      SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }
    private void Start()
    {
      PlayerPrefs.SetInt("lives", 3);
    }

    void FixedUpdate()
    {
      transform.Translate(0,0,0.3f);
      if(direction == "Right")
      {
        if(row < 3.24)
        {
          row += 3.24f;
        }
        direction = "null";
        getPoints(10);
      }
      else if(direction == "Left")
      {
        if(row > -3.24)
        {
          row -= 3.24f;
        }
        direction = "null";
        getPoints(10);
      }
      transform.position = Vector3.MoveTowards(transform.position, new Vector3(row , transform.position.y ,transform.position.z ), SideMoveSpeed);
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
      direction = data.Direction.ToString() ;
    }

    private void getPoints(int point)
    {
      int score = PlayerPrefs.GetInt("score" , 0);
      score += point;
      PlayerPrefs.SetInt("score", score);
    }
}
