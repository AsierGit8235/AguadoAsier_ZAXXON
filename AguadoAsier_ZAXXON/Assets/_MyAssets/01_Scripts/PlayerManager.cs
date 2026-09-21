using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float desplSpeed;

    //Input System
    MyInputActions inputActions;

    //movimiento en x
    float MoveX;

    //movimiento en y
    float MoveY;

    //movimiento vertical
    float MoveUp;
    float MoveDown;


    //rotacion del player
    float Rotation;

    //velocidad de rotacion
    float rotationSpeed = 4f;

    private void Awake()
    {
        inputActions = new MyInputActions();

        inputActions.Player.Fire.started += _ => Shoot();

        inputActions.Player.MoveX.performed += ctx => MoveX = ctx.ReadValue<float>();
        inputActions.Player.MoveX.canceled += _ => MoveX = 0f;

        inputActions.Player.MoveY.performed += ctx => MoveY = ctx.ReadValue<float>();
        inputActions.Player.MoveY.canceled += _ => MoveY = 0f;

        inputActions.Player.Rotate.performed += ctx => Rotation = ctx.ReadValue<float>();
        inputActions.Player.Rotate.canceled += _ => Rotation = 0f;
    }

    private void Shoot()
    {
        throw new NotImplementedException();
    }

    private void CheckLimits()
    {
        float limitsX = 14;
        float limitsY = 5; 


        if (CheckLimits() == true)
        {
            MovePlayer();
        }


            bool CheckLimits()
            {
                bool inLimit = true;

                return inLimit;
            }

        void Shoot()
        {
            print("PUUUUUM");
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 36f;
        desplSpeed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    void MovePlayer()

    {
        if (CheckLimitsX() == true)
        {
            Vector3 desplx = Vector3.right * desplSpeed * Time.deltaTime * MoveX;
            transform.Translate(desplx,Space.World);
        }
        if (CheckLimitsY() == true)
        {
            Vector3 desplx = Vector3.right * desplSpeed * Time.deltaTime * MoveX;
            transform.Translate(desplx, Space.World);
        }
            transform.Translate(Vector3.right * desplSpeed * Time.deltaTime);

        transform.Translate(Vector3.up * desplSpeed * Time.deltaTime);

        transform.Translate(Vector3.down * desplSpeed * Time.deltaTime);

        transform.Translate(Vector3.left * desplSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * rotationSpeed * Time.deltaTime * 360f);
    }

    bool CheckLimitsX()
    {
        bool inLimit = true;
        return inLimit;
    }

    bool CheckLimitsY()
    {
        bool inLimit = true;
        return inLimit;
    }

}
