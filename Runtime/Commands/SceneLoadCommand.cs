using UnityEngine;
using UnityEngine.SceneManagement;

namespace SBaier.SceneManagement
{
    [CreateAssetMenu(fileName = "SceneLoadCommand", menuName = "ScriptableObjects/SceneManagement/SceneLoadCommand")]
    public class SceneLoadCommand : SceneChangeCommand
    {
        [field: SerializeField]
        public LoadSceneMode Mode { get; private set; } = LoadSceneMode.Additive;

        public override AsyncOperation Execute()
        {
            return SceneManager.LoadSceneAsync(SceneName, Mode);
        }
    }
}
