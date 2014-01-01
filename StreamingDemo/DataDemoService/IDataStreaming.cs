namespace DataDemoService
{
    using System.IO;
    using System.ServiceModel;

    [ServiceContract(Name = "DataStreamingContract", Namespace = "http://www.SOArUS.com")]
    public interface IDataStreaming
    {
        [OperationContract]
        Stream GetDataFileAsStream(string dataFileName);
    }
}