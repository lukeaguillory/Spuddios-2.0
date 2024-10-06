using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class Repository
    {
        private static Dictionary<string, object> _repository = new Dictionary<string, object>();

        public static T FirstOrDefault<T>(string key)
        {
            if (!_repository.TryGetValue(key, out var obj))
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
    }
}
