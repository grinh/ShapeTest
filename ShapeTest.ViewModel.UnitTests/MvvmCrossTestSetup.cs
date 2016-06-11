using System;
using System.Diagnostics;
using MvvmCross.Core;
using MvvmCross.Core.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;

namespace ShapeTest.ViewModel.UnitTests
{
	public class MvvmCrossTestSetup
	{
		private IMvxIoCProvider _ioc;

		protected IMvxIoCProvider Ioc
		{
			get { return _ioc; }
		}

		public void Setup()
		{
			ClearAll();
		}

		protected void ClearAll()
		{
			// fake set up of the IoC
			MvxSingleton.ClearAllSingletons();
			_ioc = MvxSimpleIoCContainer.Initialize();
			_ioc.RegisterSingleton(_ioc);
			_ioc.RegisterSingleton<IMvxTrace>(new TestTrace());
			RegisterAdditionalSingletons();
			InitialiseSingletonCache();
			InitialiseMvxSettings();
			MvxTrace.Initialize();
		}

		protected void InitialiseMvxSettings()
		{
			_ioc.RegisterSingleton<IMvxSettings>(new MvxSettings());
		}

		protected virtual void RegisterAdditionalSingletons()
		{
		}

		private static void InitialiseSingletonCache()
		{
			MvxSingletonCache.Initialize();
		}

		private class TestTrace : IMvxTrace
		{
			public void Trace(MvxTraceLevel level, string tag, Func<string> message)
			{
				Debug.WriteLine(tag + ":" + level + ":" + message());
			}

			public void Trace(MvxTraceLevel level, string tag, string message)
			{
				Debug.WriteLine(tag + ": " + level + ": " + message);
			}

			public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
			{
				Debug.WriteLine(tag + ": " + level + ": " + message, args);
			}
		}
	}
}