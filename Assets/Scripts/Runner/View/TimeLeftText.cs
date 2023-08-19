using System;
using System.Collections.Generic;
using System.Linq;
using Runner.TimeLeft;
using TMPro;
using UnityEngine;
using Zenject;

namespace Runner.View
{
    public class TimeLeftText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [Inject] private TimeLeftCounter _counter;
        [SerializeField] private int _signsAfterDot;
        private Dictionary<double, string> _times;

        private void Start()
        {
            var pow = (int)Math.Pow(10, _signsAfterDot);
            _times = new Dictionary<double, string>(_counter.TimeForGame * pow);
            //Cashing all time variants
            for (int time = 0; time < _counter.TimeForGame; time++)
            {
                _times.Add(time, time.ToString());
                if (_signsAfterDot <= 0) continue;
                for (int time2 = 1; time2 < pow; time2++)
                {
                    var time2DividedByPow = (double)time2 / pow;
                    var summaryOfTimes = time + time2DividedByPow;
                    if (_times.ContainsKey(summaryOfTimes)) continue;
                    _times.Add(Math.Round(summaryOfTimes, _signsAfterDot), summaryOfTimes.ToString());
                }
            }

            _counter.TimeOver += OnTimeOver;
        }

        private void Update()
        {
            if (_counter.TimeLeft > 0f)
                _text.SetText("TimeLeft - " + _times[Math.Round(_counter.TimeLeft, _signsAfterDot)]);
        }

        private void OnTimeOver()
        {
            _times.Clear();
            _text.SetText("Time Over~!~");
            _counter.TimeOver -= OnTimeOver;
            Destroy(this);
        }
    }
}