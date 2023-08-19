using Runner.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Runner.View
{
    public class PlayerHealthText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [Inject] private PlayerController _player;
        private string[] _healthCachedStrings;

        private void Start()
        {
            _healthCachedStrings = new string[_player.StartHealth+1];
            for (int health = 0; health <= _player.StartHealth; health++)
            {
                _healthCachedStrings[health] = health.ToString();
            }
            _player.HealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            _player.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int newHealth)
        {
            _text.SetText("Health - " + _healthCachedStrings[newHealth]);
        }
    }
}