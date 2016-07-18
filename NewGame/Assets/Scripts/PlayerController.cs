using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //calculate movement velocity as a 3d vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _yMov;

        // final movement vector which will be passed to motor.move down below.
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //apply movement and pass this to playermotor
        motor.Move(_velocity);


        //calculatie player rotation as a 3d vector, this is just for turning the player and not the camera.
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //apply rotation and pass this to playermotor
        motor.Rotate(_rotation);


        //calculatie camera rotation as a 3d vector, Make the camera look up and down without changing player rotation.
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        //apply camera rotation and pass this to playermotor
        motor.RotateCamera(_cameraRotation);
    }
}
