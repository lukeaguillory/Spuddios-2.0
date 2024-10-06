using System;
using System.Collections.Generic;

namespace Assets.Scripts.Queues
{
    public static class DeathQueue
    {
        public static event EventHandler queued;
        private readonly static Queue<string> _deathQueue;

        //you can just kill things from here if you'd like
        public static void Enqueue(string key)
        {
            _deathQueue.Enqueue(key);
            queued.Invoke(null, null);
        }
    }
}
