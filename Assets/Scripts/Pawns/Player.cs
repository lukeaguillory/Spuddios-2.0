using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        }

        private void OnDisable()
        {
            move.Disable();
        }

        private void Start()
        {
            nextFire = Time.time;
        }

        private void Update()
        {
            if (currentHealth <= 0)
                LoadGame.LoadGameOver();

            moveDirection = move.ReadValue<Vector2>();
            CheckIfTimeToFire();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(moveDirection.x * MovementSpeed, moveDirection.y * MovementSpeed);
        }

        void CheckIfTimeToFire()
        {
            if (Time.time > nextFire && Repository.GetAllEnemies().Count > 0)
            {
                Vector3 closestEnemyPosition = FindClosestEnemyPosition();
                GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.Euler(0, 0, FindClosestEnemyAngle(closestEnemyPosition)));
                projectile.GetComponent<Weapons.Projectile>().shotDirection = closestEnemyPosition - transform.position;
                projectile.GetComponent<Weapons.Projectile>().caster = player;
                nextFire = Time.time + fireRate;
            }
        }

        Vector3 FindClosestEnemyPosition()
        {
            List<GameObject> enemies = Repository.GetAllEnemies();
            player = Repository.FirstOrDefault<GameObject>(Player.ID);
            GameObject closestEnemy = null;
            foreach (GameObject enemy in enemies)
            {
                if (closestEnemy == null ||
                    Vector2.Distance(enemy.transform.position, player.transform.position) <
                    Vector2.Distance(closestEnemy.transform.position, player.transform.position))
                {
                    closestEnemy = enemy;
                }
            }

            return closestEnemy.transform.position;
        }

        float FindClosestEnemyAngle(Vector3 enemy)
        {
            Vector3 player = transform.position;
            float angle = Vector2.Angle(enemy - player, transform.up);
            if (player.x > enemy.x)
            {
                return angle;
            } else
            {
                return 360 - angle;
            }
        }
    }
}
