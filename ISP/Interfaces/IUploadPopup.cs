using ISP.Interfaces;

public interface IUploadPopup : IPopup
{
    void SetUploadProgress(int percentage);
    bool ValidateFileType(string fileName);
}