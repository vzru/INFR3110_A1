using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float moveSpeed = 5.0f;
    private Vector3 moveDir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(characterController.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDir = moveDir * moveSpeed;
        }

        moveDir.y -= 10.0f * Time.deltaTime;

        characterController.Move(moveDir * Time.deltaTime);
    }
}
