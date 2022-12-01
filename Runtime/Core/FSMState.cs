// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	using System;

	/// <summary>
	/// FSM state
	/// </summary>
	internal sealed class FSMState : IFSMState
	{
		/// <summary>
		/// State was entered
		/// </summary>
		public event Action onEnter = default;

		/// <summary>
		/// State was exited
		/// </summary>
		public event Action onExit = default;

		/// <summary>
		/// Index of state in FSM
		/// </summary>
		public int Index { get; private set; } = -1;

		/// <summary>
		/// Bound context
		/// </summary>
		public IFSMContext Context { get; private set; } = null;

		/// <summary>
		/// Custom transition selection for state
		/// </summary>
		public IFSMTransitionSelector TransitionSelector { get; set; } = null;

		public FSMState(IFSMStateService service)
		{
			_service = service;
		}

		/// <summary>
		/// State has activated
		/// </summary>
		void IFSMStateInternals.Enter()
		{
			_service.OnStart();
			onEnter?.Invoke();
		}

		/// <summary>
		/// Update state
		/// </summary>
		void IFSMStateInternals.Tick()
		{
			_service.OnTick();
		}

		/// <summary>
		/// State has existed
		/// </summary>
		void IFSMStateInternals.Exit()
		{
			_service.OnStop();
			onExit?.Invoke();
		}

		/// <summary>
		/// Inject context
		/// </summary>
		/// <param name="ctx"></param>
		void IFSMStateInternals.SetContext(IFSMContext ctx)
		{
			Context = ctx;
			_service.SetContext(ctx);
			// no context -> no index
			if(ctx == null) { Index = -1; }
		}

		/// <summary>
		/// Set index in FSM
		/// </summary>
		/// <param name="i">State index</param>
		void IFSMStateInternals.SetIndex(in int i)
		{
			Index = i;
		}

		/// <summary>
		/// Service
		/// </summary>
		private IFSMStateService _service = default;
	}
}