// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Select transition with non-zero weight
	/// </summary>
	internal sealed class GuardSelector : FSMTransitionSelector
	{
		/// <summary>
		/// Init
		/// </summary>
		/// <param name="mode">0: First non-zero, 1: Highest non-zero weight, -1: Lowest non-zero</param>
		public GuardSelector(int mode = 0)
		{
			mode = mode.Clamp(-1, 1);
			// choose selection fn
			if(mode == 1) { _selectFn = SelectMax; }
			else if(mode == -1) { _selectFn = SelectMin; }
		}

		public override int Select(IEnumerable<IFSMTransition> transitions)
		{
			return _selectFn.Invoke(transitions);
		}

		private Func<IEnumerable<IFSMTransition>, int> _selectFn = SelectFirst;

		// pick first non-zero weight
		private static int SelectFirst(IEnumerable<IFSMTransition> transitions)
		{
			int i = 0;
			foreach(IFSMTransition t in transitions)
			{
				if(t.GetWeight() > 0f) { return i; }
				i++;
			}
			return -1;
		}

		// pick highest non-zero weight
		private static int SelectMax(IEnumerable<IFSMTransition> transitions)
		{
			int i = 0;
			int maxIndex = -1;
			float maxWeight = 0;
			foreach (IFSMTransition t in transitions)
			{
				// check if new weight is higher than last
				float w = t.GetWeight();
				if(w > maxWeight) { maxIndex = i; maxWeight = w; }
				i++;
			}
			return maxIndex;
		}

		// pick lowest non-zero weight
		private static int SelectMin(IEnumerable<IFSMTransition> transitions)
		{
			int i = 0;
			int maxIndex = -1;
			float minWeight = 0;
			foreach (IFSMTransition t in transitions)
			{
				// check if new weight is lower than last
				float w = t.GetWeight();
				if (w > 0f && minWeight < w) { maxIndex = i; minWeight = w; }
				i++;
			}
			return maxIndex;
		}
	}
}