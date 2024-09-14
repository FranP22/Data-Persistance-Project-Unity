using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;

    private Animator animator;
    private Rigidbody playerRB;
    private GameObject cam;
    public float cameraHeight = 20;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Game.timeLeft < 0) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed;
        float speedRes = Mathf.Sqrt(Mathf.Pow(horizontalInput, 2) + Mathf.Pow(verticalInput, 2)) * speed;

        animator.SetFloat("Speed", speedRes);

        if (movement != Vector3.zero)
        {
            playerRB.AddForce(movement * Time.deltaTime * 200);

            transform.rotation = Quaternion.LookRotation(movement);
        }

        cam.transform.position = new Vector3(transform.position.x, cameraHeight, transform.position.z);
    }
}
