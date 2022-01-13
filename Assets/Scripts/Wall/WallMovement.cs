using UnityEngine;
using Utilities.Events;

namespace FlappyCube.Wall {
	public class WallMovement: MonoBehaviour {
		[SerializeField] private float _speed = 2;
		[Space]
		[SerializeField] private GameEvent _gameEnded;

		protected void Update() {
			var movement = -Vector3.right * _speed * Time.deltaTime;
			transform.Translate(movement);
		}

		private void StopMovement() => Destroy(this);

		protected void OnEnable() {
			_gameEnded.AddListener(StopMovement);
		}
		protected void OnDestroy() {
			_gameEnded.RemoveListener(StopMovement);
		}
	}
}