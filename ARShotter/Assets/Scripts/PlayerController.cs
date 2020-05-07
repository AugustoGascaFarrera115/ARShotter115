﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator anim;
    private CharacterController chararacterController;
    private CollisionFlags collisionFlags = CollisionFlags.None;

    private float moveSpeed = 1f;
    private bool canMove;
    private bool finished_Movement = true;

    private Vector3 target_Position = Vector3.zero;
    private Vector3 player_Move = Vector3.zero;

    private float player_toPointDistance;

    private float gravity = 9.8f;
    private float height;

    Touch touch;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        chararacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();

        chararacterController.Move(player_Move);

    }



    void MoveThePlayer()
    {

        //touch.phase == TouchPhase.Began

        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            //calculate where is the position in the space once click event
            //touch.position
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider is BoxCollider)
                {
                    player_toPointDistance = Vector3.Distance(transform.position, hit.point);

                    if (player_toPointDistance >= 1.0f)
                    {
                        canMove = true;
                        target_Position = hit.point;
                    }

                }
            }


        }

        if (canMove)
        {

            anim.SetFloat("Walk", 1.0f);

            Vector3 target_temporal = new Vector3(target_Position.x - transform.position.x, 0, target_Position.z - transform.position.z);

            //Vector3 relativePosition = target_temporal - target_Position;

            Quaternion playerRot = Quaternion.LookRotation(target_temporal);

            transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, 15.0f * Time.deltaTime);

            player_Move = transform.forward * moveSpeed * Time.deltaTime;


            
            if (Vector3.Distance(transform.position, target_Position) <= 0.1f)
            {
                canMove = false;
            }

        }
        else
        {
            player_Move.Set(0f, 0f, 0f);
            anim.SetFloat("Walk", 0f);
        }
    }

}
