using UnityEngine;

namespace Assets.Scripts.Pawns
{
    public class EnemySpawner : MonoBehaviour
    {
        
        [SerializeField]
        public float _minimumSpawnTime;
        [SerializeField]
        public float _maximumSpawnTime;
        public float _timeUntilSpawn;
        public bool shouldSpawn = true;
        [SerializeField]
        public GameObject player;

        private void Awake()
        {
            SetTimeUntilSpawn();

        }

        private void Update()
        {
            
        }

        public void SetTimeUntilSpawn()
        {
            _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
        }

        public void SetShouldSpawn()
        {
            if (Repository.GetAllEnemies().Count >= 50 || Vector2.Distance(player.transform.position, transform.position) > 20)
            {
                shouldSpawn = false;
            }
            else
            {
                shouldSpawn = true;
            }
        }
    }
}
