using TMPro;
using UnityEngine;

namespace FlappyCube.Ui.Elements {
	public class RecordView: MonoBehaviour {
		[SerializeField] private string _key = "stats.best";
		[SerializeField] private string _prefix = "Best: ";
		[SerializeField] private TMP_Text _uiText;

		private void UpdateScoreText(int score) => _uiText.text = _prefix + score.ToString();

		protected void OnEnable() {
			UpdateScoreText(PlayerPrefs.GetInt(_key, 0));
		}
	}
}