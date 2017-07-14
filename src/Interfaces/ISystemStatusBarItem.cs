
namespace Actionix {
	public interface ISystemStatusBarItem : IMenuExtra {
		void AssignMenuBuilder(IMenuBuilder menuBuilder);
		void AssignMenuVisualizer(IMenuVisualizer menuVisualizer);
	}
}