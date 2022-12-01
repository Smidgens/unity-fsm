// smidgens @ github

namespace Smidgenomics.Unity.FSM
{

	/// <summary>
	/// FSM state service, internal API
	/// </summary>
	public interface IStateServiceInternals
	{
		/// <summary>
		/// Inject FSM context into service
		/// </summary>
		/// <param name="ctx"></param>
		internal void SetContext(IFSMContext ctx);
	}

	/// <summary>
	/// API for custom state service
	/// </summary>
	public interface IFSMStateService : IStateServiceInternals
	{
		void OnStart();
		void OnTick();
		void OnStop();
	}
}