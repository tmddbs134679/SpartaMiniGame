using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class LobbyPlayer : MonoBehaviour
{
    public int currentStage = 0;

    public bool isMoving = false;
    private Vector2 targetPos;
    [SerializeField] private float MoveSpeed;
    private Animator animator;

    private Vector2 endingPos = new Vector2(0, -11f);
    private Action  onArrivedCallback;

    private void Start()
    {
        animator = GetComponent<Animator>();

        transform.position = Game.GameManager.instance.lobbydata.currentpos;
    }

    public void MoveTo(Vector2 pos, int stage, System.Action onArrived = null)
    {
        currentStage = stage;
        targetPos = pos;
        isMoving = true;
        onArrivedCallback = onArrived;
    }

    public void Update()
    {
        if(isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, MoveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPos) <= 0.1f)
            {
                isMoving = false;
                Game.GameManager.instance.OnPlayerArrived();
                
            }
        }
    }


    public IEnumerator PlayerEnding()
    {
        Time.timeScale = 1;
        currentStage = 0;
        targetPos = endingPos;

        while (Vector2.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, MoveSpeed * Time.deltaTime);
            yield return null;
        }
       
    }
    public void PlayClearAnimation()
    {
        animator.SetBool("isClear", true);
    }

}
