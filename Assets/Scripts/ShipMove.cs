using Asteroids.Controller;
using UnityEngine;

namespace Asteroids
{
    internal sealed class ShipMove : IExecute, IMove, IRotation
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        public bool isAccellerated;

        public float Speed => _moveImplementation.Speed;

        public ShipMove(IMove moveImplementation, IRotation rotationImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
        }

        public void Move((float horizontal, float vertical) inputMove, float deltaTime)
        {
            _moveImplementation.Move(inputMove, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
                isAccellerated = true;
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
                isAccellerated = false;
            }
        }

        public void Execute(float deltaTime)
        {
        }
    }
}