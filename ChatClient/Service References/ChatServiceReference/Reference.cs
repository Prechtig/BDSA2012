﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatClient.ChatServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChatServiceReference.IChatService")]
    public interface IChatService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/PostNote", ReplyAction="http://tempuri.org/IChatService/PostNoteResponse")]
        string PostNote(string name, string note);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceChannel : ChatClient.ChatServiceReference.IChatService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatServiceClient : System.ServiceModel.ClientBase<ChatClient.ChatServiceReference.IChatService>, ChatClient.ChatServiceReference.IChatService {
        
        public ChatServiceClient() {
        }
        
        public ChatServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChatServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string PostNote(string name, string note) {
            return base.Channel.PostNote(name, note);
        }
    }
}
