using System.Collections.Generic;

namespace E3.UpdateAttributes.Interfaces.Repository
{
    public interface IE3Repository: IE3RepositoryBase
    {
        List<string> GetAttributesFromDevice();
        void UpdateDeviceAttributes(List<string> Attributes);
    }

}