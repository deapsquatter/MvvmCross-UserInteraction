using System;

namespace Chance.MvvmCross.Plugins.UserInteraction.Touch
{
	public interface IToastMessage
	{
		void Toast (string message);
		void ToastOK (string message);
		void ToastError (string message);
		void ToastProgress(string message);	
		void ToastStatus (string message);
		void ToastClose();
	}
}

