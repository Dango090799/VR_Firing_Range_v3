using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlyController : MonoBehaviour
{
    public Transform target, pivot;
    public float mouseSensitivity, playerSpeed, walkSpeed, sprintSpeed, jumpHeight;

    private Vector3 moveDirection;
    private float xRot, yRot;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
        xRot += Input.GetAxis("Mouse Y") * mouseSensitivity;
        if(xRot > 90f)
        {
            xRot = 90f;
        }else if (xRot < -90f)
        {
            xRot = -90f;
        }
        
        transform.localEulerAngles = new Vector3(-xRot, yRot, transform.localEulerAngles.z);

        if (Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                moveDirection = transform.forward * Input.GetAxis("Vertical") * sprintSpeed;
                moveDirection.y = 0;
            }
            else
            {
                moveDirection = transform.forward * Input.GetAxis("Vertical") * walkSpeed;
                moveDirection.y = 0;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                moveDirection = transform.forward * Input.GetAxis("Vertical") * sprintSpeed;
                moveDirection.y = 0;
            }
            else
            {
                moveDirection = transform.forward * Input.GetAxis("Vertical") * walkSpeed;
                moveDirection.y = 0;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                moveDirection = transform.right * Input.GetAxis("Horizontal") * sprintSpeed;
                moveDirection.y = 0;
            }
            else
            {
                moveDirection = transform.right * Input.GetAxis("Horizontal") * walkSpeed;
                moveDirection.y = 0;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                moveDirection = transform.right * Input.GetAxis("Horizontal") * sprintSpeed;
                moveDirection.y = 0;
            }
            else
            {
                moveDirection = transform.right * Input.GetAxis("Horizontal") * walkSpeed;
                moveDirection.y = 0;
            }
        }
        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            moveDirection = new Vector3(0, 0, 0);
        }

        transform.position = transform.position + (moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("NoVRExitDoor"))
        {
            Application.Quit();
        }
        if (collider.CompareTag("NoVRShootingHouseDoor"))
        {
            SceneManager.LoadScene("NoVRShootingHouse");
        }
    }
}
