// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	public static partial class FSM_
	{
		/// <summary>
		/// Set given state as active in FSM
		/// </summary>
		/// <param name="state">FSM state</param>
		public static void Activate(this IFSMState state)
		{
			// verify that bound to fsm
			if (state.Index < 0 || state.Context == null)
			{
				throw new System.ArgumentException("Cannot enable state: not bound to FSM");
			}

			// set state in owning fsm
			state.Context.FSM.SetState(state.Index);
		}
	}
}