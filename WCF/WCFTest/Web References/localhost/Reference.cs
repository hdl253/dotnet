﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.4927
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 2.0.50727.4927 版自动生成。
// 
#pragma warning disable 1591

namespace WCFTest.localhost {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    // CODEGEN: 未处理命名空间“http://schemas.xmlsoap.org/ws/2004/09/policy”中的可选 WSDL 扩展元素“PolicyReference”。
    // CODEGEN: 未处理命名空间“http://schemas.xmlsoap.org/ws/2004/09/policy”中的可选 WSDL 扩展元素“PolicyReference”。
    // CODEGEN: 未处理命名空间“http://schemas.xmlsoap.org/ws/2004/09/policy”中的可选 WSDL 扩展元素“PolicyReference”。
    // CODEGEN: 未处理命名空间“http://schemas.xmlsoap.org/ws/2004/09/policy”中的可选 WSDL 扩展元素“PolicyReference”。
    // CODEGEN: 未处理命名空间“http://schemas.xmlsoap.org/ws/2004/09/policy”中的可选 WSDL 扩展元素“PolicyReference”。
    // CODEGEN: 未处理命名空间“http://www.w3.org/2005/08/addressing”中的可选 WSDL 扩展元素“EndpointReference”。
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WSHttpBinding_IService1", Namespace="http://tempuri.org/")]
    public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetDataOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDataUsingDataContractOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service1() {
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            this.Url = global::WCFTest.Properties.Settings.Default.WCFTest_localhost_Service1;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetDataCompletedEventHandler GetDataCompleted;
        
        /// <remarks/>
        public event GetDataUsingDataContractCompletedEventHandler GetDataUsingDataContractCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IService1/GetData", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string GetData(int value, [System.Xml.Serialization.XmlIgnoreAttribute()] bool valueSpecified) {
            object[] results = this.Invoke("GetData", new object[] {
                        value,
                        valueSpecified});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetDataAsync(int value, bool valueSpecified) {
            this.GetDataAsync(value, valueSpecified, null);
        }
        
        /// <remarks/>
        public void GetDataAsync(int value, bool valueSpecified, object userState) {
            if ((this.GetDataOperationCompleted == null)) {
                this.GetDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDataOperationCompleted);
            }
            this.InvokeAsync("GetData", new object[] {
                        value,
                        valueSpecified}, this.GetDataOperationCompleted, userState);
        }
        
        private void OnGetDataOperationCompleted(object arg) {
            if ((this.GetDataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDataCompleted(this, new GetDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IService1/GetDataUsingDataContract", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public CompositeType GetDataUsingDataContract([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] CompositeType composite) {
            object[] results = this.Invoke("GetDataUsingDataContract", new object[] {
                        composite});
            return ((CompositeType)(results[0]));
        }
        
        /// <remarks/>
        public void GetDataUsingDataContractAsync(CompositeType composite) {
            this.GetDataUsingDataContractAsync(composite, null);
        }
        
        /// <remarks/>
        public void GetDataUsingDataContractAsync(CompositeType composite, object userState) {
            if ((this.GetDataUsingDataContractOperationCompleted == null)) {
                this.GetDataUsingDataContractOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDataUsingDataContractOperationCompleted);
            }
            this.InvokeAsync("GetDataUsingDataContract", new object[] {
                        composite}, this.GetDataUsingDataContractOperationCompleted, userState);
        }
        
        private void OnGetDataUsingDataContractOperationCompleted(object arg) {
            if ((this.GetDataUsingDataContractCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDataUsingDataContractCompleted(this, new GetDataUsingDataContractCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/WCF")]
    public partial class CompositeType {
        
        private bool boolValueField;
        
        private bool boolValueFieldSpecified;
        
        private string stringValueField;
        
        /// <remarks/>
        public bool BoolValue {
            get {
                return this.boolValueField;
            }
            set {
                this.boolValueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BoolValueSpecified {
            get {
                return this.boolValueFieldSpecified;
            }
            set {
                this.boolValueFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string StringValue {
            get {
                return this.stringValueField;
            }
            set {
                this.stringValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void GetDataCompletedEventHandler(object sender, GetDataCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void GetDataUsingDataContractCompletedEventHandler(object sender, GetDataUsingDataContractCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDataUsingDataContractCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDataUsingDataContractCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public CompositeType Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CompositeType)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591