using System;

public class Class1
{
    public interface IDialogPopup
    {
        void Show();
        void Close();
        void SetTitle(string title);
        void SetMessage(string message);
    }
}
