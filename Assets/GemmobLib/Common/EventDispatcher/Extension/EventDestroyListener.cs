namespace Gemmob.Common {
	public class EventDestroyListener : EventListenerBase {
		private void Awake() {
			if (listener != null) listener(true);
		}

		private void OnDestroy() {
			if (listener != null) listener(false);
		}
	}
}