using ISP.Interfaces;

public interface IDialogPopup : IPopup
{
    void SetTitle(string title);
    void SetMessage(string message);
}

