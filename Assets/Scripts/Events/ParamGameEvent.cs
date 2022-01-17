using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Events {
	public abstract class ParamGameEvent<T>: ScriptableObject {
		private UnityEvent<T> _event = new UnityEvent<T>();

		public void AddListener(UnityAction<T> action) => _event.AddListener(action);
		public void RemoveListener(UnityAction<T> action) => _event.RemoveListener(action);

		public void Invoke(T param) => _event.Invoke(param);
	}
}