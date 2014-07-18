using System;
using System.ServiceModel;
namespace WriteToFileWindowsService
{
    [ServiceContract]
    public interface IFileWriterService
    {
        [OperationContract]
        void WriteLine(string p);
    }
}
