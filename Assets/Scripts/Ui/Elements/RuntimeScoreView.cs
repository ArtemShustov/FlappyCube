using TMPro;
using UnityEngine;
using Utilities.Events;

namespace FlappyCube.Ui.Elements {
	public class RuntimeScoreView: MonoBehaviour {
		[SerializeField] private TMP_Text _uiText;
		[Space]
		[SerializeField] private IntGameEvent _scoreChanged;

		private void UpdateScoreText(int score) => _uiText.text = score.ToString();

		protected void OnEnable() {
			_scoreChanged.AddListener(UpdateScoreText);
			UpdateScoreText(0);
		}
		protected void OnDisable() {
			_scoreChanged.RemoveListener(UpdateScoreText);
		}
	}
}