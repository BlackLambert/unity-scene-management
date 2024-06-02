using System.Threading.Tasks;
using SBaier.DI;
using SBaier.UI;
using UnityEngine;

namespace SBaier.SceneManagement
{
    public class LoadingScreen : MonoBehaviour, Injectable
    {
        [SerializeField] private CanvasGroup _group;
        
        public Process.Process Process { get; private set; }
        private Displayer _displayer;
        
        public void Inject(Resolver resolver)
        {
            Process = resolver.Resolve<Process.Process>();
            _displayer = resolver.Resolve<Displayer>();
        }

        public async Task Show(bool immediately)
        {
            await _displayer.Show(immediately);
        }
        
        public async Task Hide(bool immediately)
        {
            await _displayer.Hide(immediately);
        }
    }
}