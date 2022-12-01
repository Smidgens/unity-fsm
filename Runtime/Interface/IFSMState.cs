// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	using System;

	/// <summary>
	/// FSM state, internal API
	/// </summary>
	public interface IFSMStateInternals
	{
		/// <summary>
		/// Inject context
		/// </summary>
		/// <param name="ctx"></param>
		internal void SetContext(IFSMContext ctx);

		/// <summary>
		/// Set state index in FSM
		/// </summary>
		/// <param name="i"></param>
		internal void SetIndex(in int i);

		/// <summary>
		/// State entered
		/// </summary>
		internal void Enter();

		/// <summary>
		/// State update
		/// </summary>
		internal void Tick();

		/// <summary>
		/// State exited
		/// </summary>
		internal void Exit();
	}

	/// <summary>
	/// State attached to FSM
	/// </summary>
	public interface IFSMState : IFSMStateInternals
	{
		/// <summary>
		/// State was entered
		/// </summary>
		event Action onEnter;

		/// <summary>
		/// State exited
		/// </summary>
		event Action onExit;

		/// <summary>
		/// Index of state in FSM
		/// </summary>
		int Index { get; }

		/// <summary>
		/// Bound context
		/// </summary>
		IFSMContext Context { get; }

		/// <summary>
		/// Transition selection logic
		/// </summary>
		IFSMTransitionSelector TransitionSelector { get; }

	}
}