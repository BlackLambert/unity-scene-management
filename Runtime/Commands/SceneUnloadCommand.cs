using UnityEngine;
using UnityEngine.SceneManagement;

namespace SBaier.SceneManagement
{
    [CreateAssetMenu(fileName = "SceneUnloadCommand", menuName = "ScriptableObjects/SceneManagement/SceneUnloadCommand")]
    public class SceneUnloadCommand : SceneChangeCommand
    {
        public override AsyncOperation Execute()
        {
            return SceneManager.UnloadSceneAsync(SceneName);
        }
    }
}
