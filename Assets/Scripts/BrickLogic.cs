using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLogic : MonoBehaviour
{

    public BrickStates brickHealth = new BrickStates();
    public int currentState = 0;

    [System.Serializable]
    public class BrickStates
    {
        public int pointWorth = 1;
        public List<BrickState> states;
    }
    [System.Serializable]
    public class BrickState
    {
        public int stateHealth = 1;
        public Sprite stateSprite;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;
        BrickDamage();

    }

    public void BrickDamage()
    {
        var brickState = brickHealth.states[currentState];
        if (brickState.stateHealth <= 0) BrickNextState();

        brickHealth.states[currentState].stateHealth--;

        if (brickState.stateHealth <= 0) BrickNextState();
    }

    public void BrickNextState()
    {
        if(brickHealth.states.Count - 1 > currentState)
        {
            currentState++;
        }
        else
        {
            BrickBreak();
        }
    }
    public void BrickBreak()
    {
        transform.parent.GetComponent<WallManager>().MinusBrick(brickHealth.pointWorth);
        Destroy(gameObject);
    }
}
