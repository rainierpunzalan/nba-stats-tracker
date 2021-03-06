#region Copyright Notice

//    Copyright 2011-2013 Eleftherios Aslanoglou
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

#endregion

#region Using Directives

using System;
using System.Windows;

#endregion

namespace LeftosCommonLibrary.CommonDialogs
{
    /// <summary>
    ///     Implements a general-purpose Input-box Window.
    /// </summary>
    public partial class InputBoxWindow
    {
        /// <summary>
        ///     Contains the user input if the user clicked OK, or an empty string if the user clicked Cancel.
        /// </summary>
        public static string UserInput;

        private InputBoxWindow()
        {
            InitializeComponent();

            UserInput = "";
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InputBoxWindow" /> class.
        /// </summary>
        /// <param name="message">The prompt to display.</param>
        /// <param name="title">The title.</param>
        /// <param name="defaultValue">The default value.</param>
        public InputBoxWindow(string message, string defaultValue = "", string title = "") : this()
        {
            lblMessage.Text = message;
            Title = String.IsNullOrWhiteSpace(title) ? Tools.AppName : title;

            txtInput.Focus();

            if (!string.IsNullOrWhiteSpace(defaultValue))
            {
                txtInput.Text = defaultValue;
                txtInput.SelectAll();
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            UserInput = txtInput.Text;
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            UserInput = "";
            DialogResult = false;
            Close();
        }
    }
}