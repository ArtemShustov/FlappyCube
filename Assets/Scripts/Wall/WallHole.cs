﻿using UnityEngine;

namespace FlappyCube.Wall {
	[RequireComponent(typeof(BoxCollider2D))]
	public class WallHole: MonoBehaviour {
		[SerializeField] private float _width = 0.1f;

		public void Init(float position, float height) {
			var collider = GetComponent<BoxCollider2D>();

			collider.size = new Vector2(_width, height);

			transform.localPosition = new Vector3(transform.localPosition.x, position, 0);
		}
	}
}