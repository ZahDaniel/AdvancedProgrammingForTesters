using ISP.Interfaces;

public interface IUploadPopup : IPopUp
{
    void SetUploadProgress(int percentage);
    bool ValidateFileType(string fileName);
}
