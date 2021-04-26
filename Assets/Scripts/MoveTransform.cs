using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Transform _transform;
        private Vector3 _move;

        public float Speed { get; protected set; }

        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }

        public void Move((float horizontal, float vertical) inputMove, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(inputMove.horizontal * speed, inputMove.vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }
    }
}