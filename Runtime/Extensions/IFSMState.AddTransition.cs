// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	using System;

	/// <summary>
	/// FSM extensions
	/// </summary>
	public static partial class FSM_
	{
		public static IFSMTransition AddTransition
		(
			this IFSMState state,
			IFSMState exit,
			Func<bool> guard
		)
		{
			// derive weight from guard eval
			Func<float> weightFn = () => guard.Invoke() ? 1f : 0f;
			IFSMTransition t = new WeightedTransition(exit, weightFn);
			// attach to FSM
			state.Context.FSM.AddTransition(state, t);
			return t;
		}
	}
}

namespace Smidgenomics.Unity.FSM
{
	using WeightFn = System.Func<float>;

	/// <summary>
	/// FSM extensions
	/// </summary>
	public static partial class FSM_
	{
		public static IFSMTransition AddTransition
		(
			this IFSMState state,
			IFSMState exit,
			WeightFn weightFn
		)
		{
			IFSMTransition t = new WeightedTransition(exit, weightFn);
			// attach to FSM
			state.Context.FSM.AddTransition(state, t);
			return t;
		}

		public static IFSMTransition AddTransition
		(
			this IFSMState state,
			IFSMState exit,
			float fixedWeight
		)
		{
			WeightFn weightFn = () => fixedWeight;
			return state.AddTransition(exit, weightFn);
		}
	}
}