
using UnityEngine;

namespace Assets.Scripts.Pawns
{
    public class EnemyStatueSpawner : EnemySpawner
    {
        [SerializeField]
        private GameObject _enemyPrefab;

        // Start is called before the first frame update
        void Start()
        {
            player = Repository.FirstOrDefault<GameObject>(Player.ID);
        }

        // Update is called once per frame
        void Update()
        {
            _timeUntilSpawn -= Time.deltaTime;
            SetShouldSpawn();

            if (_timeUntilSpawn <= 0 && shouldSpawn)
            {
                GameObject newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyStatue>().Id = System.Guid.NewGuid().ToString();
                Repository.AddEnemy(newEnemy.GetComponent<EnemyStatue>().Id, newEnemy);
                SetTimeUntilSpawn();
            }
        }
    }
}
