using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Events {
	[CreateAssetMenu(menuName = "Events/GameEvent")]
	public class GameEvent: ScriptableObject {
		private UnityEvent _event;

		public void AddListener(UnityAction action) => _event.AddListener(action);
		public void RemoveListener(UnityAction action) => _event.RemoveListener(action);

		public void Invoke() => _event.Invoke();
	}
}