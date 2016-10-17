using System;
using g0rdan.MvvmCross.Plugin.DiskInfo;
using g0rdan.MvvmCross.Plugin.DiskInfo.iOS;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace DiskInfoSample.iOS
{
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IDiskInfoPlugin>(new DiskInfoPlugin());
		}
	}
}
