using UnityEngine;
using Utilities.Events;

namespace FlappyCube.Player {
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerMovement: MonoBehaviour {
		[SerializeField] private float _jumpForce = 5f;
		[SerializeField] private GameEvent _gameStarted;
		[SerializeField] private GameEvent _gameEnded;

		private Rigidbody2D _rigidbody;

		protected void Awake() {
			_rigidbody = GetComponent<Rigidbody2D>();
			_rigidbody.bodyType = RigidbodyType2D.Static;
		}

		public void Jump() {
			_rigidbody.velocity = Vector2.up * _jumpForce;
		}
		private void EnableMovement() {
			_rigidbody.bodyType = RigidbodyType2D.Dynamic;
		}
		private void DisableMovement() { 
			_rigidbody.bodyType = RigidbodyType2D.Static;
		}

		protected void OnEnable() {
			_gameStarted.AddListener(EnableMovement);
			_gameEnded.AddListener(DisableMovement);
		}
		protected void OnDisable() {
			_gameStarted.RemoveListener(EnableMovement);
			_gameEnded.RemoveListener(DisableMovement);
		}
	}
}