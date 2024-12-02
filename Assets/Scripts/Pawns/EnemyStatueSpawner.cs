using Assets.Scripts;
using Assets.Scripts.Pawns;
using System.Collections;
using System.Collections.Generic;
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

        }

        // Update is called once per frame
        void Update()
        {
            _timeUntilSpawn -= Time.deltaTime;

            if (_timeUntilSpawn <= 0)
            {
                GameObject newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                Repository.Add(newEnemy.GetComponent<EnemyStatue>().Id, newEnemy);
                SetTimeUntilSpawn();
            }
        }
    }
}
