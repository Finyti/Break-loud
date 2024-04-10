using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
        transform.DOScale(new Vector3(1.5f, 1f, 1f), 0.5f)
            .ChangeStartValue(Vector3.zero)
            .SetEase(Ease.OutElastic);


    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;
        BrickDamage();
        transform.DOShakePosition(0.2f, 0.1f, 100);

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
    public async void BrickBreak()
    {
        transform.parent.GetComponent<WallManager>().MinusBrick(brickHealth.pointWorth);
        transform.GetComponent<BoxCollider2D>().isTrigger = true;
        await transform.DOShakePosition(0.2f, 0.1f, 100)
            .AsyncWaitForCompletion();

        await transform.DOLocalJump(new Vector3(Random.Range(transform.position.x - 3, transform.position.x + 3), -10, 0), 10f, 1, 1.5f)
        .SetEase(Ease.InOutSine)
        .AsyncWaitForCompletion();


        Destroy(gameObject);
    }
}
