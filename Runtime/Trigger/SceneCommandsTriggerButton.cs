using SBaier.DI;
using UnityEngine;
using UnityEngine.UI;

namespace SBaier.SceneManagement
{
    public class SceneCommandsTriggerButton : CommandsExecutionTriggerBehaviour, Initializable, Cleanable
    {
        [SerializeField]
        private Button _button;

        private ReadonlyObservable<Process.Process> _currentProcess;

        public override void Inject(Resolver resolver)
        {
	        base.Inject(resolver);
	        
	        _currentProcess = resolver.Resolve<ReadonlyObservable<Process.Process>>();
	        UpdateInteractable();
        }

        public void Initialize()
		{
			_currentProcess.OnValueChanged += OnProcessChanged;
			_button.onClick.AddListener(Execute);
		}

		public void Clean()
		{
			_currentProcess.OnValueChanged -= OnProcessChanged;
			_button.onClick.RemoveListener(Execute);
			TryRemoveProcessListeners(_currentProcess.Value);
		}

		private void Reset()
		{
			_button = GetComponent<Button>();
		}

		private void OnProcessChanged(Process.Process formervalue, Process.Process newvalue)
		{
			TryRemoveProcessListeners(formervalue);
			UpdateInteractable();
			TryAddProcessListeners(newvalue);
		}

		private void TryAddProcessListeners(Process.Process process)
		{
			if (process != null)
			{
				process.Stopped.OnValueChanged += UpdateInteractable;
				process.Complete.OnValueChanged += UpdateInteractable;
			}
		}

		private void TryRemoveProcessListeners(Process.Process process)
		{
			if (process != null)
			{
				process.Stopped.OnValueChanged -= UpdateInteractable;
				process.Complete.OnValueChanged -= UpdateInteractable;
			}
		}

		private void UpdateInteractable(bool formervalue, bool newvalue)
		{
			UpdateInteractable();
		}

		private void UpdateInteractable()
		{
			_button.interactable = _currentProcess.Value == null || 
			                       _currentProcess.Value.Complete.Value ||
			                       _currentProcess.Value.Stopped.Value;
		}
    }
}
