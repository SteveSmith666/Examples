﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StreamingDemo.Client.serviceProxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.SOArUS.com", ConfigurationName="serviceProxy.DataStreamingContract")]
    public interface DataStreamingContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.SOArUS.com/DataStreamingContract/GetDataFileAsStream", ReplyAction="http://www.SOArUS.com/DataStreamingContract/GetDataFileAsStreamResponse")]
        System.IO.Stream GetDataFileAsStream(string dataFileName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DataStreamingContractChannel : StreamingDemo.Client.serviceProxy.DataStreamingContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataStreamingContractClient : System.ServiceModel.ClientBase<StreamingDemo.Client.serviceProxy.DataStreamingContract>, StreamingDemo.Client.serviceProxy.DataStreamingContract {
        
        public DataStreamingContractClient() {
        }
        
        public DataStreamingContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataStreamingContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataStreamingContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataStreamingContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.IO.Stream GetDataFileAsStream(string dataFileName) {
            return base.Channel.GetDataFileAsStream(dataFileName);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.SOArUS.com", ConfigurationName="serviceProxy.MediaStreamingContract")]
    public interface MediaStreamingContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.SOArUS.com/MediaStreamingContract/GetMediaAsStream", ReplyAction="http://www.SOArUS.com/MediaStreamingContract/GetMediaAsStreamResponse")]
        System.IO.Stream GetMediaAsStream(string mediaFileName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MediaStreamingContractChannel : StreamingDemo.Client.serviceProxy.MediaStreamingContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MediaStreamingContractClient : System.ServiceModel.ClientBase<StreamingDemo.Client.serviceProxy.MediaStreamingContract>, StreamingDemo.Client.serviceProxy.MediaStreamingContract {
        
        public MediaStreamingContractClient() {
        }
        
        public MediaStreamingContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MediaStreamingContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MediaStreamingContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MediaStreamingContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.IO.Stream GetMediaAsStream(string mediaFileName) {
            return base.Channel.GetMediaAsStream(mediaFileName);
        }
    }
}
