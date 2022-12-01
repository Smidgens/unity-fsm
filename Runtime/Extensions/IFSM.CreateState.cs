// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	/// <summary>
	/// FSM extensions
	/// </summary>
	public static partial class FSM_
	{
		public static IFSMState CreateState
		(
			this IFSM fsm,
			IFSMStateService service
		)
		{
			IFSMState state = new FSMState(service);
			fsm.Attach(state);
			return state;
		}
	}
}

namespace Smidgenomics.Unity.FSM
{
	using HandlerFn = System.Action<IFSMContext>;

	public static partial class FSM_
	{
		public static IFSMState CreateState
		(
			this IFSM fsm,
			HandlerFn onTick = null,
			HandlerFn onStart = null,
			HandlerFn onEnd = null
		)
		{
			IFSMStateService service = new ActionService(onTick, onStart, onEnd);
			IFSMState state = new FSMState(service);
			fsm.Attach(state);
			return state;
		}
	}
}