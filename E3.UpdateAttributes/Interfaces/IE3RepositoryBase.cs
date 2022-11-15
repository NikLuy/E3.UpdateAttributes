namespace E3.UpdateAttributes.Interfaces.Repository
{
    public interface IE3RepositoryBase
    {
        bool Connect();
        void Disconnect();
        bool IsConnected { get; }

        void PutInfo(bool showMessageBox, string message, int itemId = 0);
        void PutWarning(bool showMessageBox, string message, int itemId = 0);
        void PutError(bool showMessageBox, string message, int itemId = 0);
        int GetItemType(int itemId);
    }
}