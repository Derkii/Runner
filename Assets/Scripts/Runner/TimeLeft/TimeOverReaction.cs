#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Zenject;

namespace Runner.TimeLeft
{
    public class TimeOverReaction : MonoBehaviour
    {
        [Inject] private TimeLeftCounter _counter;

        private void Start()
        {
            _counter.TimeOver += Reaction;
        }

        private void Reaction()
        {
#if UNITY_EDITOR
            EditorApplication.isPaused = true;
#elif !UNITY_EDITOR
            throw new NotImplementedException();
#endif
            _counter.TimeOver -= Reaction;
        }
    }
}