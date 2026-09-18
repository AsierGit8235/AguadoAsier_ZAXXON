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

    //rotacion del player
    float Rotation;

    //restringimiento de movimiento
    public float minX = -17f;
    public float maxX = 17f;
    public float minY = -5f;
    public float maxY = 5f;

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

    void Shoot()
    {
        print("PUUUUUM");
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
        transform.Translate(Vector3.right * desplSpeed * Time.deltaTime);

        transform.Translate(Vector3.left * desplSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * rotationSpeed * Time.deltaTime * 360f);


        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);


    }
}
