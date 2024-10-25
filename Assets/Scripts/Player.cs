using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int _coins;

    public GameObject _dust;

    [SerializeField] private float _speed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _jumpForsce;

    private Rigidbody _rb;

    [SerializeField] private Animator _animator;

    [SerializeField] private float[] _line = new float[3];
    [SerializeField] private int _currentLine;

    private bool _isGrounded;
    private bool _isJumped = false;

    public TMP_Text coinsText;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(0,_rb.velocity.y,_speed);

        Vector3 targetXPosition = new Vector3(_line[_currentLine], transform.position.y, transform.position.z );

        transform.position = Vector3.MoveTowards(transform.position, targetXPosition, _sideSpeed);
        
    }
    private void Update()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.3f);

        if (Input.GetKeyDown(KeyCode.D))
        {
            _currentLine++;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _currentLine--;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        _currentLine = Mathf.Clamp(_currentLine, 0, 2);

        coinsText.text = _coins.ToString();
    }
    private void LateUpdate()
    {
        _animator.SetFloat("Velocity",_rb.velocity.magnitude);
    }
    public void Jump() 
    {
        if (_isGrounded) 
        {
            _isJumped = true;
            _rb.AddForce(transform.up * _jumpForsce, ForceMode.Impulse);
            _animator.SetTrigger("Jump");
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && _isJumped == true)
        {
            GameObject newParticle = Instantiate(_dust, transform.position, Quaternion.identity, null);
            Destroy(newParticle, 3);

            _isJumped=false;
        }

    }

}
