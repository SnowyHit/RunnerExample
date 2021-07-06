using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //TODO add more tiles.
    public Transform Player;
    public List<GameObject> ObjectsToPool;
    private Queue<GameObject> objPool = new Queue<GameObject>();
    private Queue<GameObject> carPool = new Queue<GameObject>();
    public List<GameObject> CarPool;
    private int getNextCar = 0 ;

    void Start()
    {
      foreach (GameObject obj in ObjectsToPool)
      {
        objPool.Enqueue(obj);
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      getPoints(5);
      GetNextChunk(new Vector3(0,0,93.63f));
      if(getNextCar % 5 == 0)
      {
        int getRow = Random.Range(0,3);
        float positionOfNewCar = -3.24f + (getRow * 3.24f);
        GetCar(new Vector3(positionOfNewCar , 0 , Player.position.z + 90));
        if(carPool.Peek().transform.position.z < Player.position.z - 10)
        {
          carPool.Dequeue().SetActive(false);
        }
      }
      transform.position += new Vector3(0,0,5);
      getNextCar += 1 ;
    }

    public void GetNextChunk(Vector3 pos)
    {
      GameObject temp = objPool.Dequeue();
      temp.transform.position += pos;
      objPool.Enqueue(temp);
    }

    public void GetCar(Vector3 pos)
    {
      int backUpNumber = -1;
      int randomNumber = Random.Range(0, CarPool.Count-1);
      while(CarPool[randomNumber].activeSelf)
      {
        backUpNumber += 1;
        randomNumber = backUpNumber;
      }
      carPool.Enqueue(CarPool[randomNumber]);
      GameObject temp = CarPool[randomNumber];
      temp.transform.position = pos ;
      temp.SetActive(true);
    }

    private void getPoints(int point)
    {
      int score = PlayerPrefs.GetInt("score" , 0);
      score += point;
      PlayerPrefs.SetInt("score", score);
    }
}
