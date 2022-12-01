// smidgens @ github

namespace Smidgenomics.Unity.FSM
{
	using HandlerFn = System.Action<IFSMContext>;

	internal class ActionService : FSMStateService
	{
		public ActionService
		(
			HandlerFn onTick = null,
			HandlerFn onStart = null,
			HandlerFn onExit = null
		)
		{
			_onTick = onTick ?? NoOp;
			_onStart = onStart ?? NoOp;
			_onStop = onExit ?? NoOp;
		}

		public override void OnStart() => _onStart.Invoke(Context);
		public override void OnStop() => _onStop.Invoke(Context);
		public override void OnTick() => _onTick.Invoke(Context);

		private HandlerFn _onTick = null, _onStart = null, _onStop = null;

		private static void NoOp<T>(T _) { }

	}
}