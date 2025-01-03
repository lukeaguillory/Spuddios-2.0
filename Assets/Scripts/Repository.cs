using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Repository
    {
        private static Dictionary<string, object> _repository = new Dictionary<string, object>();
        private static Dictionary<string, object> _enemyRepository = new Dictionary<string, object>();

        public static T FirstOrDefault<T>(string key)
        {
            if (!_repository.TryGetValue(key, out var obj))
                return default;

            return (T)obj;
        }

        public static T EnemyFirstOrDefault<T>(string key)
        {
            if (!_enemyRepository.TryGetValue(key, out var obj))
                return default;

            return (T)obj;
        }

        public static IEnumerable<T> List<T>(IEnumerable<string> keys)
        {
            var values = new List<T>();
            foreach (var key in keys)
            {
                var value = FirstOrDefault<T>(key);

                if (value == null)
                    continue;

                values.Add(value);
            }

            return values;
        }

        public static void Add(string key, object obj)
        {
            if (_repository.ContainsKey(key))
                return;

            _repository.Add(key, obj);
        }

        public static void AddEnemy(string key, object obj)
        {
            if (_enemyRepository.ContainsKey(key))
                return;

            _enemyRepository.Add(key, obj);
        }

        public static void RemoveEnemy(string key)
        {
            if (_enemyRepository.ContainsKey(key))
                _enemyRepository.Remove(key);
        }

        public static List<GameObject> GetAllEnemies()
        {
            List<GameObject> list = new List<GameObject>();
            foreach (var key in _enemyRepository.Keys)
            {
                list.Add(EnemyFirstOrDefault<GameObject>(key));
                
            }
            return list;
        }

        public static void RefreshRepository()
        {
            _repository = new Dictionary<string, object>();
            _enemyRepository = new Dictionary<string, object>();
        }
    }
}
