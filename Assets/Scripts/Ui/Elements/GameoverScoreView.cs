using TMPro;
using UnityEngine;
using FlappyCube.Statistics;

namespace FlappyCube.Ui.Elements {
	public class GameoverScoreView: MonoBehaviour {
		[SerializeField] private TMP_Text _uiText;
		[SerializeField] private string _prefix = "Score: ";
		[Space]
		[SerializeField] private ScoreCounter _counter;

		private void UpdateScoreText(int score) => _uiText.text = _prefix + score.ToString();

		protected void OnEnable() {
			UpdateScoreText(_counter.Points);
		}
	}
}