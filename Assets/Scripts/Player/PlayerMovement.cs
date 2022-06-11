using UnityEngine;

namespace DetectorSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        private Rigidbody2D _rigidbody;
        private PlayerInput _playerInput;
        private Vector2 _directionMove;
        private float _multiplierSpeed = 50f;


        #region MonoBahviour
        private void OnValidate()
        {
            if (_speed < 0f) _speed = 0f;
        }
        #endregion

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private void Update()
        {
            _directionMove = _playerInput.Keyboard.Movement.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _directionMove * _speed * _multiplierSpeed * Time.fixedDeltaTime;
        }
    }
}
