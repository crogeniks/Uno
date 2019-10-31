using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SamplesApp.UITests.TestFramework;
using Uno.UITest.Helpers;
using Uno.UITest.Helpers.Queries;

namespace SamplesApp.UITests.Windows_UI_Xaml_Controls.WebViewTests
{
  [TestFixture]
  public partial class WebView_Tests : SampleControlUITestBase
  {
	[Test]
	[AutoRetry]
	public void WebView_NavigateToLongString()
	{
	  Run("UITests.Shared.Windows_UI_Xaml_Controls.WebView.WebView_NavigateToLongString");

	  var startButton = _app.Marked("startButton");

	  _app.WaitForElement(_app.Marked("startButton"));

	  TakeScreenshot("Initial");

	  _app.Tap(startButton);

	  _app.Wait(TimeSpan.FromSeconds(10));

	  var clickResult = _app.Marked("WebView_NavigateToStringSize");
	  _app.WaitForText(clickResult, "success");

	  TakeScreenshot("AfterSuccess");
	}
  }
}
