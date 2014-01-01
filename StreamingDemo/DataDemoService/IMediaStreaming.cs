namespace DataDemoService
{
    using System.IO;
    using System.ServiceModel;

    [ServiceContract(Name = "MediaStreamingContract", Namespace = "http://www.SOArUS.com")]
    public interface IMediaStreaming
    {
        [OperationContract]
        Stream GetMediaAsStream(string mediaFileName);
    }
}