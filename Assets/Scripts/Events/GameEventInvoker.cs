using UnityEngine;

namespace Utilities.Events {
	public class GameEventInvoker: MonoBehaviour {
		[SerializeField] private GameEvent _event;

		public void Invoke() {
			if (_event != null) {
				_event.Invoke();
			}
		}
	}
}