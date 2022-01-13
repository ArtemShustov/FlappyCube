using UnityEngine;

namespace FlappyCube.Wall {
	public class WallBuilder: MonoBehaviour {
		[SerializeField] private float _wallHeight = 10;
		[SerializeField] private float _holeHeight = 2;
		[SerializeField] private float _minHolePosition = 2f;
		[SerializeField] private float _maxHolePosition = 8f;
		[Space]
		[SerializeField] private WallPlatform _bottomPlatform;
		[SerializeField] private WallPlatform _topPlatform;
		[SerializeField] private WallHole _hole;
		[SerializeField] private WallMovement _movement;
		[SerializeField] private WallDestroyer _destroyer;

		public void Init(Transform destroyPoint) {
			var holePosition = Random.Range(_minHolePosition, _maxHolePosition);

			var bottomPlatformHeight = holePosition - _holeHeight / 2;
			var topPlatformHeight = _wallHeight - holePosition - _holeHeight / 2;

			_bottomPlatform.Init(bottomPlatformHeight);
			_topPlatform.Init(topPlatformHeight);
			_hole.Init(holePosition, _holeHeight);
			_destroyer.Init(destroyPoint);

			Destroy(this);
		}
	}
}