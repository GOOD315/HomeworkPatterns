using System;
using Asteroids.Controller;
using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroids
{
    public sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private float _hp;

        private Camera _camera;
        private ShipMove _ship;
        private playerInput _playerInput;
        private Controllers _controllers;

        [Serializable]
        public struct ShipSettings
        {
            public float _speed;
            public float _acceleration;
            public float _hp;
            public Rigidbody2D _bullet;
            public Transform _barrel;
            public float _force;
        }

        [SerializeField] private ShipSettings _shipSettings;

        private void Start()
        {
            _camera = Camera.main;

            _controllers = new Controllers();
            new GameInitialization(_controllers, transform, _shipSettings, _camera);
        }

        private void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}