﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitTests.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tamagot", Namespace="http://schemas.datacontract.org/2004/07/TamagotchiDomain")]
    [System.SerializableAttribute()]
    public partial class Tamagot : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime GeboorteTijdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int GezondheidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HongerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> LastActionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NaamField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SlaapField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> SterfTijdField;
        
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
        public System.DateTime GeboorteTijd {
            get {
                return this.GeboorteTijdField;
            }
            set {
                if ((this.GeboorteTijdField.Equals(value) != true)) {
                    this.GeboorteTijdField = value;
                    this.RaisePropertyChanged("GeboorteTijd");
                }
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
        public System.Nullable<System.DateTime> LastAction {
            get {
                return this.LastActionField;
            }
            set {
                if ((this.LastActionField.Equals(value) != true)) {
                    this.LastActionField = value;
                    this.RaisePropertyChanged("LastAction");
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
        public System.Nullable<System.DateTime> SterfTijd {
            get {
                return this.SterfTijdField;
            }
            set {
                if ((this.SterfTijdField.Equals(value) != true)) {
                    this.SterfTijdField = value;
                    this.RaisePropertyChanged("SterfTijd");
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAge", ReplyAction="http://tempuri.org/IService1/GetAgeResponse")]
        int GetAge(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAge", ReplyAction="http://tempuri.org/IService1/GetAgeResponse")]
        System.Threading.Tasks.Task<int> GetAgeAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/InitTimer", ReplyAction="http://tempuri.org/IService1/InitTimerResponse")]
        void InitTimer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/InitTimer", ReplyAction="http://tempuri.org/IService1/InitTimerResponse")]
        System.Threading.Tasks.Task InitTimerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddTamagotchi", ReplyAction="http://tempuri.org/IService1/AddTamagotchiResponse")]
        void AddTamagotchi(UnitTests.ServiceReference1.Tamagot tam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddTamagotchi", ReplyAction="http://tempuri.org/IService1/AddTamagotchiResponse")]
        System.Threading.Tasks.Task AddTamagotchiAsync(UnitTests.ServiceReference1.Tamagot tam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTamagotchi", ReplyAction="http://tempuri.org/IService1/GetTamagotchiResponse")]
        TamoService.Tamagotchi GetTamagotchi(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTamagotchi", ReplyAction="http://tempuri.org/IService1/GetTamagotchiResponse")]
        System.Threading.Tasks.Task<TamoService.Tamagotchi> GetTamagotchiAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EditTamagotchi", ReplyAction="http://tempuri.org/IService1/EditTamagotchiResponse")]
        void EditTamagotchi(int Id, string Name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EditTamagotchi", ReplyAction="http://tempuri.org/IService1/EditTamagotchiResponse")]
        System.Threading.Tasks.Task EditTamagotchiAsync(int Id, string Name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTamagotchis", ReplyAction="http://tempuri.org/IService1/GetTamagotchisResponse")]
        TamoService.Tamagotchi[] GetTamagotchis();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTamagotchis", ReplyAction="http://tempuri.org/IService1/GetTamagotchisResponse")]
        System.Threading.Tasks.Task<TamoService.Tamagotchi[]> GetTamagotchisAsync();
        
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
    public interface IService1Channel : UnitTests.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<UnitTests.ServiceReference1.IService1>, UnitTests.ServiceReference1.IService1 {
        
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
        
        public int GetAge(int Id) {
            return base.Channel.GetAge(Id);
        }
        
        public System.Threading.Tasks.Task<int> GetAgeAsync(int Id) {
            return base.Channel.GetAgeAsync(Id);
        }
        
        public void InitTimer() {
            base.Channel.InitTimer();
        }
        
        public System.Threading.Tasks.Task InitTimerAsync() {
            return base.Channel.InitTimerAsync();
        }
        
        public void AddTamagotchi(UnitTests.ServiceReference1.Tamagot tam) {
            base.Channel.AddTamagotchi(tam);
        }
        
        public System.Threading.Tasks.Task AddTamagotchiAsync(UnitTests.ServiceReference1.Tamagot tam) {
            return base.Channel.AddTamagotchiAsync(tam);
        }
        
        public TamoService.Tamagotchi GetTamagotchi(int Id) {
            return base.Channel.GetTamagotchi(Id);
        }
        
        public System.Threading.Tasks.Task<TamoService.Tamagotchi> GetTamagotchiAsync(int Id) {
            return base.Channel.GetTamagotchiAsync(Id);
        }
        
        public void EditTamagotchi(int Id, string Name) {
            base.Channel.EditTamagotchi(Id, Name);
        }
        
        public System.Threading.Tasks.Task EditTamagotchiAsync(int Id, string Name) {
            return base.Channel.EditTamagotchiAsync(Id, Name);
        }
        
        public TamoService.Tamagotchi[] GetTamagotchis() {
            return base.Channel.GetTamagotchis();
        }
        
        public System.Threading.Tasks.Task<TamoService.Tamagotchi[]> GetTamagotchisAsync() {
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
