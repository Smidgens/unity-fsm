// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	/// <summary>
	/// FSM transition, internal API
	/// </summary>
	public interface IFSMTransitionInternals
	{
		internal void SetContext(IFSMContext ctx);
	}

	public interface IFSMTransition : IFSMTransitionInternals
	{
		/// <summary>
		/// Exit state
		/// </summary>
		IFSMState Exit { get; }

		/// <summary>
		/// Retrieve weight value
		/// </summary>
		/// <returns></returns>
		float GetWeight();
	}
}