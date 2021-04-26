namespace Asteroids.Controller
{
    public interface IExecute : IController
    {
        void Execute(float deltaTime);
    }
}