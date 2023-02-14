using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    Man inputActions;
    private Vector3 playerPosition;
    private bool touch = false;
    public GameObject mainCamera;
    private Rigidbody rb;
    private PlayerInput playerInput;
    public float moveSpeed;

    private Man playerInputActions;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        playerInputActions = new Man();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Pickup.performed += Pickup;
        playerInputActions.Player.Move.performed += Movement;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FiexedUpdate()
    {
        //Vector2 inputVecter = playerInputActions.Player.Move.ReadValue<Vector2>();
        //rb.velocity = transform.TransformVector(new Vector3(inputVecter.x, 0, inputVecter.y) * moveSpeed);
        
    }

    public void Pickup(InputAction.CallbackContext obj)
    {

    }

    public void Movement(InputAction.CallbackContext obj)
    {
        Vector2 inputVecter = obj.ReadValue<Vector2>();
        rb.velocity = transform.TransformVector(new Vector3(inputVecter.x, 0, inputVecter.y) * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pickupObject")
        {
            other.gameObject.transform.parent = mainCamera.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "pickupObject")
        {
            touch = false;
        }
    }

}
