using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Pawns
{
    public class Player : Pawn
    {

        public const string ID = "Leeten";
        public float moveSpeed;
        [SerializeField]
        public GameObject player;
        public Rigidbody2D rb;
        public PlayerInputActions playerControls;
        Vector2 moveDirection = Vector2.zero;
        private InputAction move;
        private InputAction fire;

        [SerializeField]
        GameObject Projectile;

        [SerializeField]
        public float fireRate;
        float nextFire;

        private void Awake()
        {
            Id = "Leeten";
            Repository.Add(ID, player);
            playerControls = new PlayerInputActions();
        }
        private void OnEnable()
        {
            move = playerControls.Player.Move;
            move.Enable();

            fire = playerControls.Player.Fire;
            fire.Enable();
            fire.performed += Fire;
        }

        private void OnDisable()
        {
            move.Disable();
            fire.Disable();
        }

        private void Start()
        {
            nextFire = Time.time;
        }

        private void Update()
        {
            moveDirection = move.ReadValue<Vector2>();
            CheckIfTimeToFire();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(moveDirection.x * MovementSpeed, moveDirection.y * MovementSpeed);
        }

        private void Fire(InputAction.CallbackContext context)
        {
            Debug.Log("We Fired");
        }

        void CheckIfTimeToFire()
        {
            if (Time.time > nextFire)
            {
                GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
        }


    }
}
