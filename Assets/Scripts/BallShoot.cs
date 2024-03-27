using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallShoot : MonoBehaviour
{
    public GameObject ballPrefab;

    public float speed;
    public float ballDeviation;

    bool ballHolding = true;

    //public float ballReload;

    GameObject currentBall = null;
    void Start()
    {
        BallInstantiate();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentBall != null && ballHolding != false)
        {
            BallRelease();
        }
        if(ballHolding != false)
        {
            currentBall.transform.position = transform.position + new Vector3(0, 0.8f, 0); 
        }
    }

    public void BallInstantiate()
    {
        ballHolding = true;
        currentBall = Instantiate(ballPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity, transform);
        currentBall.transform.Rotate(new Vector3(0, 0, 90));

    }

    public void BallRelease()
    {
        currentBall.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-ballDeviation, ballDeviation), Random.Range(-ballDeviation, ballDeviation)) + Vector2.down * speed;
        currentBall.transform.parent = null;

        ballHolding = false;

        //await new WaitForSeconds(ballReload);

        //currentBall = null;

        //BallInstantiate();

    }


}
