using Runner.Level;
using TMPro;
using UnityEngine;
using Zenject;

namespace Runner.View
{
    public class BlocksPassedCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [Inject] private LevelRoadBuilder _roadBuilder;
        private int _blockPassedCount;

        private void Awake()
        {
            _roadBuilder.OnBuilt += OnBlockBuilt;
        }

        private void OnDestroy()
        {
            _roadBuilder.OnBuilt -= OnBlockBuilt;
        }

        private void OnBlockBuilt(Block.BlockComponent obj)
        {
            _blockPassedCount++;
            _text.SetText("Blocks passed - " + _blockPassedCount);
        }
    }
}