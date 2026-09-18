using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float desplSpeed;

    //Input System
    MyInputActions inputActions;

    //movimientos en axis
    float MoveX;
    float MoveY;


    //movimiento vertical
    float MoveUp;
    float MoveDown;

    //limites del movimiento 
    float limits = 15f;

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

    private void Update()
    {
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
        transform.Translate(Vector3.right * desplSpeed * Time.deltaTime);

        transform.Translate(Vector3.up * desplSpeed * Time.deltaTime);

        transform.Translate(Vector3.down * desplSpeed * Time.deltaTime);

        transform.Translate(Vector3.left * desplSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * rotationSpeed * Time.deltaTime * 360f);
    }
}
