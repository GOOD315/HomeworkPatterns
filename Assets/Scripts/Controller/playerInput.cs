using UnityEngine;

namespace Asteroids.Controller
{
    public class playerInput
    {
        private float _rotation;
        private Transform _playerTransform;
        private Camera _camera;

        public playerInput(Transform playerTransform, Camera camera)
        {
            _playerTransform = playerTransform;
            _camera = camera;
        }

        public Vector3 GetRotation()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_playerTransform.position);
            return direction;
        }

        public (float horizontal, float vertical) GetMovement()
        {
            return (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        public bool GetAcelleration()
        {
            if (Input.GetKey(KeyCode.LeftShift)) return true;
            return false;
        }

        public bool GetFire()
        {
            if (Input.GetButtonDown("Fire1")) return true;
            return false;
        }
    }
}