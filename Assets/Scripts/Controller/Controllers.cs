using System.Collections.Generic;

namespace Asteroids.Controller
{
    public class Controllers : IInitialization, IExecute

    {
        private List<IExecute> _executeControllers;
        private List<IInitialization> _initializeControllers;

        public Controllers()
        {
            _initializeControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
        }

        public void Add(IController controller)
        {
            if (controller is IExecute executeController) _executeControllers.Add(executeController);
            if (controller is IInitialization initializeController) _initializeControllers.Add(initializeController);
        }


        public void Initialization()
        {
            foreach (var controller in _initializeControllers)
            {
                controller.Initialization();
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var controller in _executeControllers)
            {
                controller.Execute(deltaTime);
            }
        }
    }
}