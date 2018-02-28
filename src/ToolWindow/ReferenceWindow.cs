using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.Shell;

namespace RubyLanguageService.ToolWindow
{
    [Guid(WindowGuidString)]
    public class ReferenceWindow : ToolWindowPane
    {
        public const string WindowGuidString = "e7090fd8-8163-4e9a-9616-45ff87e0816e";
        public const string Title = "Ruby Language Reference";

        /// <summary>
        /// Initializes a new instance of the <see cref="TermWindow"/> class.
        /// </summary>
        public ReferenceWindow(string title) : base()
        {
            Caption = title;

            var elm = new WebBrowser();
            elm.Navigate("https://www.ruby-lang.org/en/documentation/");
            
            Content = elm;
        }
    }
}
