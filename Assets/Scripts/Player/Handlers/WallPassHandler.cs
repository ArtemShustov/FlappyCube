using UnityEngine;
using Utilities.Events;
using FlappyCube.Wall;

namespace FlappyCube.Player {
	public class WallPassHandler: MonoBehaviour {
		[SerializeField] private GameEvent _event;

		protected void OnTriggerEnter2D(Collider2D collision) {
			if (collision.transform.TryGetComponent<WallHole>(out var hole)) {
				_event.Invoke();
			}
		}
	}
}