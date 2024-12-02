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
    }
}
