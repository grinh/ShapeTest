using System;
using System.Diagnostics;
using Moq;
using MvvmCross.Core;
using MvvmCross.Core.Platform;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;

namespace ShapeTest.ViewModel.UnitTests.Helpers
{
    /// <summary>
    /// Helper class that allows to UnitTest MvvmCross ViewModels
    /// </summary>
	public class MvvmCrossTestSetup
	{
	    private Mock<IMvxViewDispatcher> _mockViewDispatcher;

	    public Mock<IMvxViewDispatcher> MvxViewDispatcher => _mockViewDispatcher;

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
            _mockViewDispatcher = new Mock<IMvxViewDispatcher>();

            var dispatcher = new MockMvxViewDispatcher(_mockViewDispatcher.Object);
            
            Ioc.RegisterSingleton(dispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(dispatcher);
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