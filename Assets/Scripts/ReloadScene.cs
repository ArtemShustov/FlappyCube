using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities {
	public class ReloadScene: MonoBehaviour {
		public void Reload() {
			var index = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(index);
		}
	}
}