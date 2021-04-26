using UnityEngine;

namespace Asteroids.Controller
{
    public sealed class ShipMoveController : IExecute
    {
        private playerInput _playerInput;
        private ShipMove _shipMove;

        public ShipMoveController(playerInput playerInput, Transform transform, GameStarter.ShipSettings shipSettings)
        {
            _playerInput = playerInput;

            var moveTransform = new AccelerationMove(transform, shipSettings._speed, shipSettings._acceleration);
            var rotation = new RotationShip(transform);
            _shipMove = new ShipMove(moveTransform, rotation);
        }

        public void Execute(float deltaTime)
        {
            _shipMove.Rotation(_playerInput.GetRotation());
            _shipMove.Move(_playerInput.GetMovement(), Time.deltaTime);
            
            
            if (_playerInput.GetAcelleration() && !_shipMove.isAccellerated)
            {
                _shipMove.AddAcceleration();
            }
            else if (!_playerInput.GetAcelleration() && _shipMove.isAccellerated)
            {
                _shipMove.RemoveAcceleration();
            }
        }
    }
}