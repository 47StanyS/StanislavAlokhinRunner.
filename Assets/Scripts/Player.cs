using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int _coins;

    public float _speed;
    public float _sideSpeed;

    private Rigidbody _rb;

    [SerializeField]private Animator _animator;

    [SerializeField] private float[] _line = new float[3];
    [SerializeField] private int _currentLine;

    public TMP_Text coinsText;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(0,0,_speed);

        Vector3 targetXPosition = new Vector3(_line[_currentLine], transform.position.y, transform.position.z );

        transform.position = Vector3.MoveTowards(transform.position, targetXPosition, _sideSpeed);
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _currentLine++;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _currentLine--;
        }

        _currentLine = Mathf.Clamp(_currentLine, 0, 2);

        coinsText.text = _coins.ToString();
    }
    private void LateUpdate()
    {
        _animator.SetFloat("Velocity",_rb.velocity.magnitude);
    }
}
