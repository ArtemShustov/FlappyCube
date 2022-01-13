using UnityEngine;
using Utilities.Events;

namespace FlappyCube.Player {
	public class HitHandler: MonoBehaviour {
		[SerializeField] private GameEvent _event;

		protected void OnCollisionEnter2D(Collision2D collision) {
			_event.Invoke();
		}
	}
}