using UnityEngine;

namespace Asteroids.Controller
{
    public class GameInitialization
    {
        public GameInitialization(Controllers controllers, Transform transform, GameStarter.ShipSettings shipSettings,
            Camera camera)
        {
            var playerInput = new playerInput(transform, camera);
            var shipMoveController = new ShipMoveController(playerInput, transform, shipSettings);
            var shipShootController = new ShipShootController(playerInput, shipSettings);
            controllers.Add(shipMoveController);
            controllers.Add(shipShootController);
        }
    }
}