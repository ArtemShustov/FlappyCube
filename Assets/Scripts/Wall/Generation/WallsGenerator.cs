using System.Collections;
using UnityEngine;
using Utilities.Events;

namespace FlappyCube.Wall {
	public class WallsGenerator: MonoBehaviour {
		[SerializeField] private float _spawnDelay = 2f;
		[SerializeField] private Transform _wallDestroyPoint;
		[SerializeField] private WallBuilder _wallPrefab;
		[Space]
		[SerializeField] private GameEvent _gameStarted;
		[SerializeField] private GameEvent _gameEnded;

		private Coroutine _spawnerCoroutine;

		private void StartGeneration() {
			if (_spawnerCoroutine == null) {
				_spawnerCoroutine = StartCoroutine(WallSpawner());
			}
		}
		private void StopGeneration() {
			if (_spawnerCoroutine != null) {
				StopCoroutine(_spawnerCoroutine);
			}
		}
		private void SpawnWall() {
			var wall = Instantiate(_wallPrefab, transform);
			wall.Init(_wallDestroyPoint);
		}

		private IEnumerator WallSpawner() {
			while(true) {
				SpawnWall();
				yield return new WaitForSeconds(_spawnDelay);
			}
		}

		protected void OnEnable() {
			_gameStarted.AddListener(StartGeneration);
			_gameEnded.AddListener(StopGeneration);
		}
		protected void OnDisable() {
			_gameStarted.RemoveListener(StartGeneration);
			_gameEnded.RemoveListener(StopGeneration);
		}
	}
}