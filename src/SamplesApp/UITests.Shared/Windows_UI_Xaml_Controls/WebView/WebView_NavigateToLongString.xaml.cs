using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UITests.Shared.Windows_UI_Xaml_Controls.WebView
{
  [Uno.UI.Samples.Controls.SampleControlInfo("WebView", "WebView_NavigateToLongString", description: "Testing a NavigateToString with a very long string")]
  public sealed partial class WebView_NavigateToLongString : UserControl
  {
	public WebView_NavigateToLongString()
	{
	  this.InitializeComponent();
	}

	private async void GenerateLong_Click(object sender, object e)
	{

	  int linesCount = 0;
	  if (!int.TryParse(WebView_NavigateToStringSize.Text, out linesCount))
	  {
		return;
	  }

	  WebView_NavigateToStringSize.Text = "waiting for NavigationCompleted";

	  string longString;
	  longString = "<html><body>";
	  for (int i = 0; i < linesCount; i++)
	  {
		string line = "Line " + i.ToString() + " ";
		line = line.PadRight(1000, 'x');
		longString = longString + "<p>" + line;
		WebView_NavigateToStringSize.Text = ((int)(i * 100 / linesCount)).ToString();  // percentage, as generating string takes loooong
	  }
	  longString += "</body></html>";
	  //webViewControl.NavigationCompleted += webViewControl_NavigationCompleted;
	  webViewControl.NavigationCompleted += WebViewControl_NavigationCompleted;
	  webViewControl.NavigateToString(longString);
	}

	private void WebViewControl_NavigationCompleted(Windows.UI.Xaml.Controls.WebView sender, WebViewNavigationCompletedEventArgs args)
	{
	  WebView_NavigateToStringSize.Text = "success";
	}
  }
}
