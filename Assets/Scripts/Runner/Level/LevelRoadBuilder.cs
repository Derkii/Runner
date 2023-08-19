using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Runner.Block;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace Runner.Level
{
    public class LevelRoadBuilder : MonoBehaviour
    {
        [SerializeField, SerializedDictionary] private SerializedDictionary<BlockComponent, int> _prefabs;
        [Inject] private DiContainer _container;
        private Text _pointsText, _livesText, _timerText;
        private List<BlockComponent> _builtBlocks;
        public event Action<BlockComponent> OnBuilt;
        private BlockComponent _lastBlockPrefab;

        private void Start()
        {
            _builtBlocks = FindObjectsOfType<BlockComponent>().ToList();
            _builtBlocks.Sort((x, y) =>
                x.transform.position.z.CompareTo(y.transform.position.z)
            );
        }

        public void BuildBlock()
        {
            BlockComponent prefab = null;
            foreach (var block in _prefabs)
            {
                if (Random.Range(0, 100) < block.Value && _lastBlockPrefab != block.Key)
                {
                    prefab = block.Key;
                    break;
                }
            }

            BlockComponent FirstOfPrefabWithMaxValue()
            {
                KeyValuePair<BlockComponent, int> prefabWithMaxValue = default;
                foreach (var block in _prefabs)
                {
                    if ((prefabWithMaxValue.Key == null ||
                        block.Value > prefabWithMaxValue.Value) && block.Key != _lastBlockPrefab)
                    {
                        prefabWithMaxValue = block;
                    }
                }

                return prefabWithMaxValue.Key;
            }

            if (prefab == null)
            {
                prefab = FirstOfPrefabWithMaxValue();
            }

            _lastBlockPrefab = prefab;
            var currentBlock = _builtBlocks[^1];
            var prefabInstance =
                Instantiate(prefab,
                    new Vector3(currentBlock.transform.position.x, currentBlock.transform.position.y,
                        currentBlock.transform.position.z + currentBlock.Size / 2 + prefab.Size / 2),
                    Quaternion.identity);
            _container.InjectGameObject(prefabInstance.gameObject);
            _builtBlocks.Add(prefabInstance);
            Destroy(_builtBlocks[0].gameObject);
            _builtBlocks.RemoveAt(0);
            OnBuilt?.Invoke(prefabInstance);
        }
    }
}