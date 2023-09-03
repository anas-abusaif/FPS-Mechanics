using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private Controller controller;
    Vector3 MoveDirection = Vector3.zero;
    PlayerOnGroundController GroundController;
    PlayerLadderController LadderController;
    void Start()
    {
        GroundController = GetComponent<PlayerOnGroundController>();
        LadderController = GetComponent<PlayerLadderController>();
        controller = GroundController;
    }
    private void Update()
    {
        MoveDirection = Input.GetAxisRaw("Horizontal") * transform.right + Input.GetAxisRaw("Vertical") * transform.forward;
        if (Input.GetAxis("Jump") == 1)
        {
            controller.Jump();
        }
    }
    private void FixedUpdate()
    {
        controller.ApplyMovement(MoveDirection);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            controller = LadderController;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            controller = GroundController;

        }
    }



}
