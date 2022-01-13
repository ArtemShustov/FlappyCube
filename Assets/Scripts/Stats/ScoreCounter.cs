using UnityEngine;
using Utilities.Events;

namespace FlappyCube.Statistics {
	public class ScoreCounter: MonoBehaviour {
		[SerializeField] private string _bestScoreKey = "stats.best";
		[SerializeField] private string _lastScoreKey = "stats.lastScore";
		[Space]
		[SerializeField] private GameEvent _gameStarted;
		[SerializeField] private GameEvent _gameEnded;
		[SerializeField] private GameEvent _playerPassedWall;
		[SerializeField] private IntGameEvent _scoreChanged;

		public int Points { get; private set; } = 0;

		private void AddScorePoint() {
			Points += 1;
			_scoreChanged.Invoke(Points);
		}
		private void ResetScorePoints() {
			Points = 0;
			_scoreChanged.Invoke(Points);
		}
		private void SaveScore() {
			var currentBest = PlayerPrefs.GetInt(_bestScoreKey, 0);
			if (currentBest < Points) {
				PlayerPrefs.SetInt(_bestScoreKey, Points);
			}
			PlayerPrefs.SetInt(_lastScoreKey, Points);
		}

		protected void OnEnable() {
			_gameEnded.AddListener(SaveScore);
			_playerPassedWall.AddListener(AddScorePoint);
			_gameStarted.AddListener(ResetScorePoints);
		}
		protected void OnDisable() {
			_gameEnded.RemoveListener(SaveScore);
			_playerPassedWall.RemoveListener(AddScorePoint);
			_gameStarted.RemoveListener(ResetScorePoints);
		}
	}
}