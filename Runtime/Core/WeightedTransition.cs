// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	using System;

	/// <summary>
	/// Transition backed by dynamic weight
	/// </summary>
	internal sealed class WeightedTransition : FSMTransition
	{
		/// <summary>
		/// Init
		/// </summary>
		/// <param name="exit">Exit state</param>
		/// <param name="weightFn">Dynamic weight value</param>
		public WeightedTransition(IFSMState exit, Func<float> weightFn) : base(exit)
		{
			_weightFn = weightFn;
		}

		/// <summary>
		/// Compute dynamic weight
		/// </summary>
		/// <returns>Weight</returns>
		public override float GetWeight() => _weightFn.Invoke();

		/// <summary>
		/// Dynamic weight fn
		/// </summary>
		private Func<float> _weightFn = null;
	}
}