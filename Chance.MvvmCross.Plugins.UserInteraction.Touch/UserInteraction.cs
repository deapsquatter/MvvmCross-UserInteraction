using System;
using MonoTouch.UIKit;
using System.Threading.Tasks;
using Cirrious.CrossCore;

namespace Chance.MvvmCross.Plugins.UserInteraction.Touch
{
	public class UserInteraction : IUserInteraction
	{
		public void Confirm(string message, Action okClicked, string title = "", string okButton = "OK", string cancelButton = "Cancel")
		{
			Confirm(message, confirmed =>
			{
				if (confirmed)
					okClicked();
			},
			title, okButton, cancelButton);
		}

		public void Confirm(string message, Action<bool> answer, string title = "", string okButton = "OK", string cancelButton = "Cancel")
		{
			UIApplication.SharedApplication.InvokeOnMainThread(() =>
			{
				var confirm = new UIAlertView(title ?? string.Empty, message,
				                              null, cancelButton, okButton);
				if (answer != null)
				{
					confirm.Clicked +=
						(sender, args) =>
							answer(confirm.CancelButtonIndex != args.ButtonIndex);
				}
				confirm.Show();
			});
		}

		public Task<bool> ConfirmAsync(string message, string title = "", string okButton = "OK", string cancelButton = "Cancel")
		{
			var tcs = new TaskCompletionSource<bool>();
			Confirm(message, confirmed => tcs.SetResult(confirmed), title, okButton, cancelButton);
			return tcs.Task;
		}

		public void Alert(string message, Action done = null, string title = "")
		{
			UIApplication.SharedApplication.InvokeOnMainThread(() =>
			{
				var alert = new UIAlertView(title ?? string.Empty, message, null, "OK");
				if (done != null)
				{
					alert.Clicked += (sender, args) => done();
				}
				alert.Show();
			});

		}

		public Task AlertAsync(string message, string title = "")
		{
			var tcs = new TaskCompletionSource<object>();
			Alert(message, () => tcs.SetResult(null), title);
			return tcs.Task;
		}

		public void Input(string message, Action<string> okClicked, string placeholder = null, string title = null, string okButton = "OK",
		                string cancelButton = "Cancel")
		{
			Input(message, (ok, text) =>
			{
				if (ok)
					okClicked(text);
			},
			placeholder, title, okButton, cancelButton);
		}

		public void Input(string message, Action<bool, string> answer, string placeholder = null, string title = null, string okButton = "OK", string cancelButton = "Cancel")
		{
			UIApplication.SharedApplication.InvokeOnMainThread(() =>
			{
				var input = new UIAlertView(title ?? string.Empty, message, null, cancelButton, okButton);
				input.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
				var textField = input.GetTextField(0);
				textField.Placeholder = placeholder;
				if (answer != null)
				{
					input.Clicked +=
						(sender, args) =>
							answer(input.CancelButtonIndex != args.ButtonIndex, textField.Text);
				}
				input.Show();
			});
		}

		public Task<InputResponse> InputAsync(string message, string placeholder = null, string title = null, string okButton = "OK", string cancelButton = "Cancel")
		{
			var tcs = new TaskCompletionSource<InputResponse>();
			Input(message, (ok, text) => tcs.SetResult(new InputResponse() {Ok = ok, Text = text}),	placeholder, title, okButton, cancelButton);
			return tcs.Task;
		}

		public void Toast(string message)
		{
			var toast = Mvx.Resolve<IToastMessage>();
			if (toast != null)
				toast.Toast (message);
		}

		public void ToastOK (string message)
		{
			var toast = Mvx.Resolve<IToastMessage>();
			if (toast != null)
				toast.ToastOK (message);
		}

		public void ToastError (string message)
		{
			var toast = Mvx.Resolve<IToastMessage>();
			if (toast != null)
				toast.ToastError (message);
		}


		public void ToastProgress (string message)
		{
			var toast = Mvx.Resolve<IToastMessage>();
			if (toast != null)
				toast.ToastProgress (message);
		}

		public void ToastStatus (string message)
		{
			var toast = Mvx.Resolve<IToastMessage>();
			if (toast != null)
				toast.ToastStatus (message);
		}

		public void ToastClose()
		{
			var toast = Mvx.Resolve<IToastMessage>();
			if (toast != null)
				toast.ToastClose ();
		}
	}
}

