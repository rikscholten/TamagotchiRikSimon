﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TamagotchiWeb.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tamagotchi", Namespace="http://schemas.datacontract.org/2004/07/TamoService")]
    [System.SerializableAttribute()]
    public partial class Tamagotchi : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int GezondheidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HongerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LeeftijdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NaamField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SlaapField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int VervelingField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Gezondheid {
            get {
                return this.GezondheidField;
            }
            set {
                if ((this.GezondheidField.Equals(value) != true)) {
                    this.GezondheidField = value;
                    this.RaisePropertyChanged("Gezondheid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Honger {
            get {
                return this.HongerField;
            }
            set {
                if ((this.HongerField.Equals(value) != true)) {
                    this.HongerField = value;
                    this.RaisePropertyChanged("Honger");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Leeftijd {
            get {
                return this.LeeftijdField;
            }
            set {
                if ((this.LeeftijdField.Equals(value) != true)) {
                    this.LeeftijdField = value;
                    this.RaisePropertyChanged("Leeftijd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Naam {
            get {
                return this.NaamField;
            }
            set {
                if ((object.ReferenceEquals(this.NaamField, value) != true)) {
                    this.NaamField = value;
                    this.RaisePropertyChanged("Naam");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Slaap {
            get {
                return this.SlaapField;
            }
            set {
                if ((this.SlaapField.Equals(value) != true)) {
                    this.SlaapField = value;
                    this.RaisePropertyChanged("Slaap");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Verveling {
            get {
                return this.VervelingField;
            }
            set {
                if ((this.VervelingField.Equals(value) != true)) {
                    this.VervelingField = value;
                    this.RaisePropertyChanged("Verveling");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddTamagotchi", ReplyAction="http://tempuri.org/IService1/AddTamagotchiResponse")]
        void AddTamagotchi(TamagotchiDomain.Tamagot tam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddTamagotchi", ReplyAction="http://tempuri.org/IService1/AddTamagotchiResponse")]
        System.Threading.Tasks.Task AddTamagotchiAsync(TamagotchiDomain.Tamagot tam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTamagotchi", ReplyAction="http://tempuri.org/IService1/GetTamagotchiResponse")]
        TamagotchiWeb.ServiceReference1.Tamagotchi GetTamagotchi(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTamagotchi", ReplyAction="http://tempuri.org/IService1/GetTamagotchiResponse")]
        System.Threading.Tasks.Task<TamagotchiWeb.ServiceReference1.Tamagotchi> GetTamagotchiAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EditTamagotchi", ReplyAction="http://tempuri.org/IService1/EditTamagotchiResponse")]
        void EditTamagotchi(int Id, string Name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EditTamagotchi", ReplyAction="http://tempuri.org/IService1/EditTamagotchiResponse")]
        System.Threading.Tasks.Task EditTamagotchiAsync(int Id, string Name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTamagotchis", ReplyAction="http://tempuri.org/IService1/GetTamagotchisResponse")]
        TamagotchiWeb.ServiceReference1.Tamagotchi[] GetTamagotchis();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTamagotchis", ReplyAction="http://tempuri.org/IService1/GetTamagotchisResponse")]
        System.Threading.Tasks.Task<TamagotchiWeb.ServiceReference1.Tamagotchi[]> GetTamagotchisAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetStatus", ReplyAction="http://tempuri.org/IService1/GetStatusResponse")]
        string GetStatus(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetStatus", ReplyAction="http://tempuri.org/IService1/GetStatusResponse")]
        System.Threading.Tasks.Task<string> GetStatusAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PerformAction", ReplyAction="http://tempuri.org/IService1/PerformActionResponse")]
        void PerformAction(int Id, string Action);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PerformAction", ReplyAction="http://tempuri.org/IService1/PerformActionResponse")]
        System.Threading.Tasks.Task PerformActionAsync(int Id, string Action);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetRuleArray", ReplyAction="http://tempuri.org/IService1/GetRuleArrayResponse")]
        bool[] GetRuleArray();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetRuleArray", ReplyAction="http://tempuri.org/IService1/GetRuleArrayResponse")]
        System.Threading.Tasks.Task<bool[]> GetRuleArrayAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateGameRules", ReplyAction="http://tempuri.org/IService1/CreateGameRulesResponse")]
        System.Collections.Generic.Dictionary<int, object> CreateGameRules(bool[] rulesArray);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateGameRules", ReplyAction="http://tempuri.org/IService1/CreateGameRulesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, object>> CreateGameRulesAsync(bool[] rulesArray);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TamagotchiWeb.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TamagotchiWeb.ServiceReference1.IService1>, TamagotchiWeb.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddTamagotchi(TamagotchiDomain.Tamagot tam) {
            base.Channel.AddTamagotchi(tam);
        }
        
        public System.Threading.Tasks.Task AddTamagotchiAsync(TamagotchiDomain.Tamagot tam) {
            return base.Channel.AddTamagotchiAsync(tam);
        }
        
        public TamagotchiWeb.ServiceReference1.Tamagotchi GetTamagotchi(int Id) {
            return base.Channel.GetTamagotchi(Id);
        }
        
        public System.Threading.Tasks.Task<TamagotchiWeb.ServiceReference1.Tamagotchi> GetTamagotchiAsync(int Id) {
            return base.Channel.GetTamagotchiAsync(Id);
        }
        
        public void EditTamagotchi(int Id, string Name) {
            base.Channel.EditTamagotchi(Id, Name);
        }
        
        public System.Threading.Tasks.Task EditTamagotchiAsync(int Id, string Name) {
            return base.Channel.EditTamagotchiAsync(Id, Name);
        }
        
        public TamagotchiWeb.ServiceReference1.Tamagotchi[] GetTamagotchis() {
            return base.Channel.GetTamagotchis();
        }
        
        public System.Threading.Tasks.Task<TamagotchiWeb.ServiceReference1.Tamagotchi[]> GetTamagotchisAsync() {
            return base.Channel.GetTamagotchisAsync();
        }
        
        public string GetStatus(int Id) {
            return base.Channel.GetStatus(Id);
        }
        
        public System.Threading.Tasks.Task<string> GetStatusAsync(int Id) {
            return base.Channel.GetStatusAsync(Id);
        }
        
        public void PerformAction(int Id, string Action) {
            base.Channel.PerformAction(Id, Action);
        }
        
        public System.Threading.Tasks.Task PerformActionAsync(int Id, string Action) {
            return base.Channel.PerformActionAsync(Id, Action);
        }
        
        public bool[] GetRuleArray() {
            return base.Channel.GetRuleArray();
        }
        
        public System.Threading.Tasks.Task<bool[]> GetRuleArrayAsync() {
            return base.Channel.GetRuleArrayAsync();
        }
        
        public System.Collections.Generic.Dictionary<int, object> CreateGameRules(bool[] rulesArray) {
            return base.Channel.CreateGameRules(rulesArray);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, object>> CreateGameRulesAsync(bool[] rulesArray) {
            return base.Channel.CreateGameRulesAsync(rulesArray);
        }
    }
}
