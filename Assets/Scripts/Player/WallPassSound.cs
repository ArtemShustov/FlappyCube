using UnityEngine;
using Utilities.Events;

namespace FlappyCube.Player {
	public class WallPassSound: MonoBehaviour {
		[SerializeField] private AudioSource _audioSource;
		[Space]
		[SerializeField] private GameEvent _wallPassed;

		private void PlaySound() => _audioSource.PlayOneShot(_audioSource.clip);

		protected void OnEnable() {
			_wallPassed.AddListener(PlaySound);
		}
		protected void OnDisable() {
			_wallPassed.RemoveListener(PlaySound);
		}
	}
}