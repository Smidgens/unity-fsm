// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	/// <summary>
	/// FSM execution context, shared across
	/// </summary>
	public interface IFSMContext
	{
		/// <summary>
		/// FSM instance
		/// </summary>
		IFSM FSM { get; }
	}
}