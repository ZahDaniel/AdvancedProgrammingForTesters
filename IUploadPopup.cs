using System;

public interface IUploadPopup : IDialogPopup
{
    void SetUploadProgress(int percentage);
    bool ValidateFileType(string fileName);
}
