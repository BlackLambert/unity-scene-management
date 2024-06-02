using System.Collections.Generic;

namespace SBaier.SceneManagement
{
    public interface CommandsEnqueuer
    {
        void Enqueue(List<SceneChangeCommand> commands);
    }
}
