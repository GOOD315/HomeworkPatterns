using UnityEngine;

namespace Asteroids.Controller
{
    public class ShipShootController : MonoBehaviour, IExecute
    {
        private playerInput _playerInput;
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private GameStarter.ShipSettings _shipSettings;

        public ShipShootController(playerInput playerInput, GameStarter.ShipSettings shipSettings)
        {
            _playerInput = playerInput;
            _shipSettings = shipSettings;
            _bullet = shipSettings._bullet;
            _barrel = shipSettings._barrel;
        }

        public void Execute(float deltaTime)
        {
            if (_playerInput.GetFire())
            {
                var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _shipSettings._force);
            }
        }
    }
}