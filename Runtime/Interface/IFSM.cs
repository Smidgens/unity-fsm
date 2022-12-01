// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	/// <summary>
	/// FSM, internal API
	/// </summary>
	public interface IFSMInternals
	{

	}

	public interface IFSM : IFSMInternals
	{
		void Tick();
		void SetState(in int i);
		void Attach(in IFSMState state);
		void AddTransition(in IFSMState from, in IFSMTransition transition);
	}
}