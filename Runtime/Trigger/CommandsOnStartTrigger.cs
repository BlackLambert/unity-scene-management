using SBaier.DI;

namespace SBaier.SceneManagement
{
    public class CommandsOnInitTrigger : CommandsExecutionTriggerBehaviour, Initializable
    {
        public void Initialize()
        {
            Execute();
        }
    }
}
