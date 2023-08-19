using System;
using UnityEngine;

namespace Runner.TimeLeft
{
    public class TimeLeftCounter : MonoBehaviour
    {
        [SerializeField] private int _timeForGame;
        private float _timeLeft;
        public float TimeLeft => _timeLeft;
        public int TimeForGame => _timeForGame;
        public event Action TimeOver;
        private void Awake()
        {
            _timeLeft = _timeForGame;
        }

        private void Update()
        {
            if (_timeLeft <= 0f)
            {
                TimeOver?.Invoke();
                return;
            }
            _timeLeft -= Time.deltaTime;
        }  
    }
}