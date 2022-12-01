// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	using System.Collections.Generic;

	/// <summary>
	/// Base class for custom transition selection
	/// </summary>
	public abstract class FSMTransitionSelector : IFSMTransitionSelector
	{
		public virtual int Select(IEnumerable<IFSMTransition> transitions)
		{
			return -1;
		}
	}
}