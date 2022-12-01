// smidgens @ github

#pragma warning disable 0414

namespace Smidgenomics.Unity.FSM
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// FSM implementation
	/// </summary>
	public sealed class FSM : IFSM
	{
		/// <summary>
		/// Transition taken
		/// </summary>
		public event Action<IFSMTransition> onTransition;

		/// <summary>
		/// Init
		/// </summary>
		public FSM()
		{
			_context = new FSMContext(this);
		}

		/// <summary>
		/// Tick current state
		/// </summary>
		public void Tick()
		{
			if(_state < 0) { return; } // no state active
			AttachedState s = _states[_state];
			s.state.Tick();

			// check for available transitions out of current state
			IFSMTransition availableTransition = FindAvailableTransition(_state);

			if(availableTransition != null)
			{
				// go to exit state
				SetState(availableTransition.Exit.Index);
				// notify observers
				onTransition?.Invoke(availableTransition);
			}
		}

		/// <summary>
		/// Explicitly move to state
		/// </summary>
		/// <param name="newIndex">Index of state</param>
		public void SetState(in int newIndex)
		{
			// exit current
			if(_state > -1)
			{
				AttachedState oldState = _states[_state];
				oldState.state.Exit();
			}

			// validate
			if(!IsValidIndex(newIndex, _states))
			{
				throw new ArgumentException("Cannot set state: invalid index.");
			}

			// enter new state
			_state = newIndex;
			AttachedState newState = _states[newIndex];
			newState.state.Enter();
		}

		public void Attach(in IFSMState state)
		{
			// prevent duplicates
			if (state.Index > -1)
			{
				throw new ArgumentException("State already bound.");
			}

			// attach state
			state.SetIndex(_states.Count);
			state.SetContext(_context);
			_states.Add(new AttachedState
			{
				state = state
			});

		}

		// add transition between states
		public void AddTransition
		(
			in IFSMState from,
			in IFSMTransition transition
		)
		{
			IFSMState exit = transition.Exit;

			// check if states are bound to FSM
			bool validStates =
			exit != null
			&& from.Context.FSM == this
			&& exit.Context.FSM == this;

			if (!validStates)
			{
				throw new ArgumentException("Error adding transition: states not bound to FSM");
			}

			AttachedState s = _states[from.Index];

			transition.SetContext(_context);

			s.transitions.Add(transition);
		}

		/// <summary>
		/// Information about state registered with FSM
		/// </summary>
		private sealed class AttachedState
		{
			public IFSMState state;
			public List<IFSMTransition> transitions = new List<IFSMTransition>();
		}

		/// <summary>
		/// Default transition selector for all states
		/// </summary>
		private static readonly IFSMTransitionSelector _DEFAULT_SELECTOR = new GuardSelector();

		/// <summary>
		/// Currently active state
		/// </summary>
		private int _state = -1;

		/// <summary>
		/// Execution context
		/// </summary>
		private IFSMContext _context = null;

		/// <summary>
		/// States bound to FSM
		/// </summary>
		private List<AttachedState> _states = new List<AttachedState>();


		/// <summary>
		/// Select 
		/// </summary>
		/// <param name="stateIndex">Index of source state</param>
		/// <returns></returns>
		private IFSMTransition FindAvailableTransition(in int stateIndex)
		{
			AttachedState state = _states[stateIndex];

			// selection logic
			IFSMTransitionSelector selector = state.state.TransitionSelector ?? _DEFAULT_SELECTOR;
			int transitionIndex = selector.Select(state.transitions);

			// no transition available
			if(transitionIndex < 0) { return null; }

			return state.transitions[transitionIndex];
		}

		// index is within bounds
		private static bool IsValidIndex<T>(in int i, List<T> l) => i > -1 && i < l.Count;

	}
}