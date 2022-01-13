using UnityEngine;
using Utilities.Events;

namespace FlappyCube.Ui {
	public class UiPanelsController: MonoBehaviour {
		[SerializeField] private UiPanel _gameoverPanel;
		[SerializeField] private UiPanel _inGamePanel;
		[SerializeField] private UiPanel _menuPanel;
		[Space]
		[SerializeField] private GameEvent _gameEnded;
		[SerializeField] private GameEvent _gameStarted;

		private UiPanel _activePanel;

		protected void Start() {
			SetActivePanel(_menuPanel);
		}

		private void SetActivePanel(UiPanel panel) {
			if (_activePanel != null) {
				_activePanel.Hide();
			}
			_activePanel = panel;
			_activePanel.Show();
		}
		private void ShowGameoverPanel() => SetActivePanel(_gameoverPanel);
		private void ShowInGamePanel() => SetActivePanel(_inGamePanel);
		private void ShowMenuPanel() => SetActivePanel(_menuPanel);

		protected void OnEnable() {
			_gameStarted.AddListener(ShowInGamePanel);
			_gameEnded.AddListener(ShowGameoverPanel);
		}
		protected void OnDestroy() {
			_gameStarted.RemoveListener(ShowInGamePanel);
			_gameEnded.RemoveListener(ShowGameoverPanel);
		}
	}
}