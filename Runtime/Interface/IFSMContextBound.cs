// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	public interface IFSMContextBound
	{
		/// <summary>
		/// Bound context
		/// </summary>
		IFSMContext Context { get; }
	}
}