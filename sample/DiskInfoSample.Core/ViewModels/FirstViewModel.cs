using g0rdan.MvvmCross.Plugin.DiskInfo;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace DiskInfoSample.Core.ViewModels
{
	public class FirstViewModel
		: MvxViewModel
	{
		private string _hello = "Hello MvvmCross";
		public string Hello
		{
			get { return _hello; }
			set { SetProperty(ref _hello, value); }
		}

		public override void Start()
		{
			base.Start();

			var freeSpace = Mvx.Resolve<IDiskInfoPlugin>().GetFreeSpace();
			var totalSpace = Mvx.Resolve<IDiskInfoPlugin>().GetTotalSpace();
		}
	}
}
