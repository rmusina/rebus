﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AccountWebServiceModel", Namespace="http://schemas.datacontract.org/2004/07/ReBus.WebServices.WebServiceModel")]
    public partial class AccountWebServiceModel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private decimal CreditField;
        
        private string FirstNameField;
        
        private System.Guid GUIDField;
        
        private string LastNameField;
        
        private string UserNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Credit {
            get {
                return this.CreditField;
            }
            set {
                if ((this.CreditField.Equals(value) != true)) {
                    this.CreditField = value;
                    this.RaisePropertyChanged("Credit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid GUID {
            get {
                return this.GUIDField;
            }
            set {
                if ((this.GUIDField.Equals(value) != true)) {
                    this.GUIDField = value;
                    this.RaisePropertyChanged("GUID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransactionWebServiceModel", Namespace="http://schemas.datacontract.org/2004/07/ReBus.WebServices.WebServiceModel")]
    public partial class TransactionWebServiceModel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private decimal AmountField;
        
        private System.DateTime CreatedField;
        
        private int IdField;
        
        private int TypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((this.AmountField.Equals(value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Created {
            get {
                return this.CreatedField;
            }
            set {
                if ((this.CreatedField.Equals(value) != true)) {
                    this.CreatedField = value;
                    this.RaisePropertyChanged("Created");
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
        public int Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthenticationWebServiceReference.IAuthenticationWebService")]
    public interface IAuthenticationWebService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAuthenticationWebService/Authenticate", ReplyAction="http://tempuri.org/IAuthenticationWebService/AuthenticateResponse")]
        System.IAsyncResult BeginAuthenticate(string username, string password, System.AsyncCallback callback, object asyncState);
        
        ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel EndAuthenticate(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAuthenticationWebService/AuthenticateTicketController", ReplyAction="http://tempuri.org/IAuthenticationWebService/AuthenticateTicketControllerResponse" +
            "")]
        System.IAsyncResult BeginAuthenticateTicketController(string username, string password, System.AsyncCallback callback, object asyncState);
        
        ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel EndAuthenticateTicketController(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAuthenticationWebService/Register", ReplyAction="http://tempuri.org/IAuthenticationWebService/RegisterResponse")]
        System.IAsyncResult BeginRegister(string userName, string password, string firstName, string lastName, System.AsyncCallback callback, object asyncState);
        
        string EndRegister(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAuthenticationWebService/GetTransactionHistory", ReplyAction="http://tempuri.org/IAuthenticationWebService/GetTransactionHistoryResponse")]
        System.IAsyncResult BeginGetTransactionHistory(ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel userAccount, System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.TransactionWebServiceModel> EndGetTransactionHistory(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticationWebServiceChannel : ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public AuthenticateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticateTicketControllerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public AuthenticateTicketControllerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegisterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public RegisterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetTransactionHistoryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetTransactionHistoryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.TransactionWebServiceModel> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.TransactionWebServiceModel>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationWebServiceClient : System.ServiceModel.ClientBase<ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService>, ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService {
        
        private BeginOperationDelegate onBeginAuthenticateDelegate;
        
        private EndOperationDelegate onEndAuthenticateDelegate;
        
        private System.Threading.SendOrPostCallback onAuthenticateCompletedDelegate;
        
        private BeginOperationDelegate onBeginAuthenticateTicketControllerDelegate;
        
        private EndOperationDelegate onEndAuthenticateTicketControllerDelegate;
        
        private System.Threading.SendOrPostCallback onAuthenticateTicketControllerCompletedDelegate;
        
        private BeginOperationDelegate onBeginRegisterDelegate;
        
        private EndOperationDelegate onEndRegisterDelegate;
        
        private System.Threading.SendOrPostCallback onRegisterCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetTransactionHistoryDelegate;
        
        private EndOperationDelegate onEndGetTransactionHistoryDelegate;
        
        private System.Threading.SendOrPostCallback onGetTransactionHistoryCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public AuthenticationWebServiceClient() {
        }
        
        public AuthenticationWebServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticationWebServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationWebServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationWebServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<AuthenticateCompletedEventArgs> AuthenticateCompleted;
        
        public event System.EventHandler<AuthenticateTicketControllerCompletedEventArgs> AuthenticateTicketControllerCompleted;
        
        public event System.EventHandler<RegisterCompletedEventArgs> RegisterCompleted;
        
        public event System.EventHandler<GetTransactionHistoryCompletedEventArgs> GetTransactionHistoryCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService.BeginAuthenticate(string username, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginAuthenticate(username, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService.EndAuthenticate(System.IAsyncResult result) {
            return base.Channel.EndAuthenticate(result);
        }
        
        private System.IAsyncResult OnBeginAuthenticate(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string username = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService)(this)).BeginAuthenticate(username, password, callback, asyncState);
        }
        
        private object[] OnEndAuthenticate(System.IAsyncResult result) {
            ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel retVal = ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService)(this)).EndAuthenticate(result);
            return new object[] {
                    retVal};
        }
        
        private void OnAuthenticateCompleted(object state) {
            if ((this.AuthenticateCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AuthenticateCompleted(this, new AuthenticateCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void AuthenticateAsync(string username, string password) {
            this.AuthenticateAsync(username, password, null);
        }
        
        public void AuthenticateAsync(string username, string password, object userState) {
            if ((this.onBeginAuthenticateDelegate == null)) {
                this.onBeginAuthenticateDelegate = new BeginOperationDelegate(this.OnBeginAuthenticate);
            }
            if ((this.onEndAuthenticateDelegate == null)) {
                this.onEndAuthenticateDelegate = new EndOperationDelegate(this.OnEndAuthenticate);
            }
            if ((this.onAuthenticateCompletedDelegate == null)) {
                this.onAuthenticateCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAuthenticateCompleted);
            }
            base.InvokeAsync(this.onBeginAuthenticateDelegate, new object[] {
                        username,
                        password}, this.onEndAuthenticateDelegate, this.onAuthenticateCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService.BeginAuthenticateTicketController(string username, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginAuthenticateTicketController(username, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService.EndAuthenticateTicketController(System.IAsyncResult result) {
            return base.Channel.EndAuthenticateTicketController(result);
        }
        
        private System.IAsyncResult OnBeginAuthenticateTicketController(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string username = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService)(this)).BeginAuthenticateTicketController(username, password, callback, asyncState);
        }
        
        private object[] OnEndAuthenticateTicketController(System.IAsyncResult result) {
            ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel retVal = ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService)(this)).EndAuthenticateTicketController(result);
            return new object[] {
                    retVal};
        }
        
        private void OnAuthenticateTicketControllerCompleted(object state) {
            if ((this.AuthenticateTicketControllerCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AuthenticateTicketControllerCompleted(this, new AuthenticateTicketControllerCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void AuthenticateTicketControllerAsync(string username, string password) {
            this.AuthenticateTicketControllerAsync(username, password, null);
        }
        
        public void AuthenticateTicketControllerAsync(string username, string password, object userState) {
            if ((this.onBeginAuthenticateTicketControllerDelegate == null)) {
                this.onBeginAuthenticateTicketControllerDelegate = new BeginOperationDelegate(this.OnBeginAuthenticateTicketController);
            }
            if ((this.onEndAuthenticateTicketControllerDelegate == null)) {
                this.onEndAuthenticateTicketControllerDelegate = new EndOperationDelegate(this.OnEndAuthenticateTicketController);
            }
            if ((this.onAuthenticateTicketControllerCompletedDelegate == null)) {
                this.onAuthenticateTicketControllerCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAuthenticateTicketControllerCompleted);
            }
            base.InvokeAsync(this.onBeginAuthenticateTicketControllerDelegate, new object[] {
                        username,
                        password}, this.onEndAuthenticateTicketControllerDelegate, this.onAuthenticateTicketControllerCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService.BeginRegister(string userName, string password, string firstName, string lastName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginRegister(userName, password, firstName, lastName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService.EndRegister(System.IAsyncResult result) {
            return base.Channel.EndRegister(result);
        }
        
        private System.IAsyncResult OnBeginRegister(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string userName = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            string firstName = ((string)(inValues[2]));
            string lastName = ((string)(inValues[3]));
            return ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService)(this)).BeginRegister(userName, password, firstName, lastName, callback, asyncState);
        }
        
        private object[] OnEndRegister(System.IAsyncResult result) {
            string retVal = ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService)(this)).EndRegister(result);
            return new object[] {
                    retVal};
        }
        
        private void OnRegisterCompleted(object state) {
            if ((this.RegisterCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.RegisterCompleted(this, new RegisterCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void RegisterAsync(string userName, string password, string firstName, string lastName) {
            this.RegisterAsync(userName, password, firstName, lastName, null);
        }
        
        public void RegisterAsync(string userName, string password, string firstName, string lastName, object userState) {
            if ((this.onBeginRegisterDelegate == null)) {
                this.onBeginRegisterDelegate = new BeginOperationDelegate(this.OnBeginRegister);
            }
            if ((this.onEndRegisterDelegate == null)) {
                this.onEndRegisterDelegate = new EndOperationDelegate(this.OnEndRegister);
            }
            if ((this.onRegisterCompletedDelegate == null)) {
                this.onRegisterCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnRegisterCompleted);
            }
            base.InvokeAsync(this.onBeginRegisterDelegate, new object[] {
                        userName,
                        password,
                        firstName,
                        lastName}, this.onEndRegisterDelegate, this.onRegisterCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService.BeginGetTransactionHistory(ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel userAccount, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetTransactionHistory(userAccount, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.TransactionWebServiceModel> ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService.EndGetTransactionHistory(System.IAsyncResult result) {
            return base.Channel.EndGetTransactionHistory(result);
        }
        
        private System.IAsyncResult OnBeginGetTransactionHistory(object[] inValues, System.AsyncCallback callback, object asyncState) {
            ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel userAccount = ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel)(inValues[0]));
            return ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService)(this)).BeginGetTransactionHistory(userAccount, callback, asyncState);
        }
        
        private object[] OnEndGetTransactionHistory(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.TransactionWebServiceModel> retVal = ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService)(this)).EndGetTransactionHistory(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetTransactionHistoryCompleted(object state) {
            if ((this.GetTransactionHistoryCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetTransactionHistoryCompleted(this, new GetTransactionHistoryCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetTransactionHistoryAsync(ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel userAccount) {
            this.GetTransactionHistoryAsync(userAccount, null);
        }
        
        public void GetTransactionHistoryAsync(ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel userAccount, object userState) {
            if ((this.onBeginGetTransactionHistoryDelegate == null)) {
                this.onBeginGetTransactionHistoryDelegate = new BeginOperationDelegate(this.OnBeginGetTransactionHistory);
            }
            if ((this.onEndGetTransactionHistoryDelegate == null)) {
                this.onEndGetTransactionHistoryDelegate = new EndOperationDelegate(this.OnEndGetTransactionHistory);
            }
            if ((this.onGetTransactionHistoryCompletedDelegate == null)) {
                this.onGetTransactionHistoryCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetTransactionHistoryCompleted);
            }
            base.InvokeAsync(this.onBeginGetTransactionHistoryDelegate, new object[] {
                        userAccount}, this.onEndGetTransactionHistoryDelegate, this.onGetTransactionHistoryCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService CreateChannel() {
            return new AuthenticationWebServiceClientChannel(this);
        }
        
        private class AuthenticationWebServiceClientChannel : ChannelBase<ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService>, ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService {
            
            public AuthenticationWebServiceClientChannel(System.ServiceModel.ClientBase<ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.IAuthenticationWebService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginAuthenticate(string username, string password, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = username;
                _args[1] = password;
                System.IAsyncResult _result = base.BeginInvoke("Authenticate", _args, callback, asyncState);
                return _result;
            }
            
            public ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel EndAuthenticate(System.IAsyncResult result) {
                object[] _args = new object[0];
                ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel _result = ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel)(base.EndInvoke("Authenticate", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginAuthenticateTicketController(string username, string password, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = username;
                _args[1] = password;
                System.IAsyncResult _result = base.BeginInvoke("AuthenticateTicketController", _args, callback, asyncState);
                return _result;
            }
            
            public ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel EndAuthenticateTicketController(System.IAsyncResult result) {
                object[] _args = new object[0];
                ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel _result = ((ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel)(base.EndInvoke("AuthenticateTicketController", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginRegister(string userName, string password, string firstName, string lastName, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[4];
                _args[0] = userName;
                _args[1] = password;
                _args[2] = firstName;
                _args[3] = lastName;
                System.IAsyncResult _result = base.BeginInvoke("Register", _args, callback, asyncState);
                return _result;
            }
            
            public string EndRegister(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("Register", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetTransactionHistory(ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.AccountWebServiceModel userAccount, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = userAccount;
                System.IAsyncResult _result = base.BeginInvoke("GetTransactionHistory", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.TransactionWebServiceModel> EndGetTransactionHistory(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.TransactionWebServiceModel> _result = ((System.Collections.ObjectModel.ObservableCollection<ReBus.Mobile.TicketCollector.AuthenticationWebServiceReference.TransactionWebServiceModel>)(base.EndInvoke("GetTransactionHistory", _args, result)));
                return _result;
            }
        }
    }
}
