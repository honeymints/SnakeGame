using UnityEngine;
using UnityEngine.InputSystem;

public class SnakeMovement : MonoBehaviour
{
    public PlayerInput PlayerInp { get; private set; }
    public InputAction Movement { get; private set; }

    private Vector3 _movementInput;

    private Vector3 _startPos;
    [SerializeField] private float _speed=10f;
    [SerializeField] private float _rotationSpeed;
    
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.GetChild(0).localPosition;
        _rb = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        PlayerInp = new PlayerInput();
    }

    private void OnEnable()
    {
        Movement = PlayerInp.Player.Move;
        Movement.Enable();
    }

    private void OnDisable()
    {
        Movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        _movementInput = Movement.ReadValue<Vector2>().normalized;
        Move();
        
    }

    private void Move()
    {
        Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y);
        Debug.Log(movement);
        transform.Translate(movement*Time.deltaTime*_speed, Space.World);
        RotateToward(movement);
    }

    
    private void RotateToward(Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            Quaternion _direction = Quaternion.LookRotation(movement, Vector3.up);
            Quaternion _rotation =
                Quaternion.RotateTowards(transform.rotation, _direction, _rotationSpeed * Time.deltaTime);

            //_rb.MoveRotation(_rotation);
            transform.rotation = _rotation;
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Apple"))
        {
            other.gameObject.SetActive(false); 
            EatAppleAndGrow(0.5f);;
            ScoreCounter.Instance.GainScore(5);
        }
    }

    private void EatAppleAndGrow(float scale)
    {
        transform.GetChild(0).localScale = new Vector3(
            transform.GetChild(0).localScale.x,
            transform.GetChild(0).localScale.y,
            transform.GetChild(0).localScale.z + scale);
        _startPos.z -= 0.25f;
        Debug.Log(_startPos);
        transform.GetChild(0).localPosition=new Vector3(_startPos.x, _startPos.y, _startPos.z);
    }
}
