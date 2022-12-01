// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	/// <summary>
	/// Base for custom state service
	/// </summary>
	public abstract class FSMStateService : IFSMStateService
	{
		public virtual void OnStart() { }
		public virtual void OnTick() { }
		public virtual void OnStop() { }

		/// <summary>
		/// Bind context
		/// </summary>
		void IStateServiceInternals.SetContext(IFSMContext ctx) => Context = ctx;

		/// <summary>
		/// Bound context
		/// </summary>
		protected IFSMContext Context { get; private set; }

	}
}