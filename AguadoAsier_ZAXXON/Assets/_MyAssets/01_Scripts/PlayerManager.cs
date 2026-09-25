using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool alive = true;


    public float moveSpeed;
    [SerializeField] float desplSpeed;

    //Input System
    MyInputActions inputActions;

    //movimiento en x
    float moveX;

    //movimiento en y
    float moveY;

    //movimiento vertical
    float MoveUp;
    float MoveDown;


    //rotacion del player
    float rotate;

    //velocidad de rotacion
    float rotationSpeed = 0.7f;

    float maxRotation = 70f;
    [SerializeField] float smoothTime = 0.4f;
    private Vector3 velocity = Vector3.zero;
    Vector3 currentRot;

    private void Awake()
    {
        inputActions = new MyInputActions();

        inputActions.Player.Fire.started += _ => Shoot();

        inputActions.Player.MoveX.performed += ctx => moveX = ctx.ReadValue<float>();
        inputActions.Player.MoveX.canceled += _ => moveX = 0f;

        inputActions.Player.MoveY.performed += ctx => moveY = ctx.ReadValue<float>();
        inputActions.Player.MoveY.canceled += _ => moveY = 0f;

        inputActions.Player.Rotate.performed += ctx => rotate = ctx.ReadValue<float>();
        inputActions.Player.Rotate.canceled += _ => rotate = 0f;

        moveSpeed = 25f;
    }


    private void CheckLimits()
    {
        float limitsX = 14f;
        float limitsY = 5f; 


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
       
        desplSpeed = 25f;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer(); 
    }


    void MovePlayer()

    {
        if (CheckLimitsX() == true)
        {
            Vector3 desplx = Vector3.right * desplSpeed * Time.deltaTime * moveX;
            transform.Translate(desplx,Space.World);
        }
        if (CheckLimitsY() == true)
        {
            Vector3 desply = Vector3.up * desplSpeed * Time.deltaTime * moveY;
            transform.Translate(desply, Space.World);
        }
           


   
    }

    void RotatePlayer()
    {
        transform.Rotate(Vector3.forward * -rotate * rotationSpeed * Time.deltaTime * 360, Space.Self);
        /*
        transform.eulerAngles = Vector3.forward * -maxRotation * moveX;
        Vector3 vectorRotZ = Vector3.forward * -60f * moveX;
        Vector3 vectorRotX = Vector3.right * -30f * moveY;
        Vector3 vectorRot = vectorRotX + vectorRotZ;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothTime);
        transform.eulerAngles = currentRot;
        */
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
