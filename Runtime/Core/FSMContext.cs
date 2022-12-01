// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	/// <summary>
	/// Default
	/// </summary>
	internal sealed class FSMContext : IFSMContext
	{
		public IFSM FSM { get; private set; } = null;

		public FSMContext(IFSM fsm)
		{
			FSM = fsm;
		}
	}
}