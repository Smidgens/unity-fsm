// smidgens @ github

#pragma warning disable 0414

namespace Smidgenomics.Unity.FSM
{
	internal abstract class FSMTransition : IFSMTransition
	{
		/// <summary>
		/// Exit state
		/// </summary>
		public IFSMState Exit { get; } = null;

		/// <summary>
		/// Dynamic weight
		/// </summary>
		/// <returns>Weight value</returns>
		public virtual float GetWeight() => 0f;

		/// <summary>
		/// Execution context
		/// </summary>
		protected IFSMContext Context { get; private set; } = null;

		protected FSMTransition(IFSMState exit)
		{
			Exit = exit;
		}

		/// <summary>
		/// Inject context
		/// </summary>
		/// <param name="ctx"></param>
		void IFSMTransitionInternals.SetContext(IFSMContext ctx)
		{
			Context = ctx;
		}
	}
}