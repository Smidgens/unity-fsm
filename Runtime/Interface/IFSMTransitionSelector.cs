// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	using System.Collections.Generic;

	/// <summary>
	/// Transition selection logic
	/// </summary>
	public interface IFSMTransitionSelector
	{
		/// <summary>
		/// Select available transition
		/// </summary>
		/// <param name="transitions">Outgoing transitions</param>
		/// <returns>Index of transition to take</returns>
		int Select(IEnumerable<IFSMTransition> transitions);
	}
}