using System;

namespace Chance.MvvmCross.Plugins.UserInteraction.Mac
{
	public class UserInteraction : IUserInteraction
	{
		public UserInteraction ()
		{
		}

		#region IUserInteraction implementation

		public void Confirm (string message, Action okClicked, string title = null, string okButton = "OK", string cancelButton = "Cancel")
		{
		}

		public void Confirm (string message, Action<bool> answer, string title = null, string okButton = "OK", string cancelButton = "Cancel")
		{
		}

		public void Alert (string message, Action done = null, string title = "")
		{
		}

		public void Input (string message, Action<string> okClicked, string placeholder = null, string title = null, string okButton = "OK", string cancelButton = "Cancel")
		{
		}

		public void Input (string message, Action<bool, string> answer, string placeholder = null, string title = null, string okButton = "OK", string cancelButton = "Cancel")
		{
		}

		public System.Threading.Tasks.Task AlertAsync (string message, string title = "")
		{
			throw new NotImplementedException ();
		}

		public System.Threading.Tasks.Task<bool> ConfirmAsync (string message, string title = "", string okButton = "OK", string cancelButton = "Cancel")
		{
			throw new NotImplementedException ();
		}

		public System.Threading.Tasks.Task<InputResponse> InputAsync (string message, string placeholder = null, string title = null, string okButton = "OK", string cancelButton = "Cancel")
		{
			throw new NotImplementedException ();
		}

		public void Toast (string message)
		{
		}

		public void ToastOK (string message)
		{
		}

		public void ToastError (string message)
		{
		}

		public void ToastProgress (string message)
		{
		}

		public void ToastStatus (string message)
		{
		}

		public void ToastClose ()
		{
		}

		#endregion
	}
}

