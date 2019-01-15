﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace WebMVC.serviceSarlaft {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="addressbook1Binding", Namespace="urn:/due/ws_due/server_ws_due_v2b.php")]
    public partial class addressbook1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback getDatosWsDueOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public addressbook1() {
            this.Url = global::WebMVC.Properties.Settings.Default.WebMVC_serviceSarlaft_addressbook1;
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
        public event getDatosWsDueCompletedEventHandler getDatosWsDueCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("uri:DatosWsDue/getDatosWsDue", RequestNamespace="uri:DatosWsDue", ResponseNamespace="uri:DatosWsDue")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public Respuesta getDatosWsDue(DatosWsDue Datos) {
            object[] results = this.Invoke("getDatosWsDue", new object[] {
                        Datos});
            return ((Respuesta)(results[0]));
        }
        
        /// <remarks/>
        public void getDatosWsDueAsync(DatosWsDue Datos) {
            this.getDatosWsDueAsync(Datos, null);
        }
        
        /// <remarks/>
        public void getDatosWsDueAsync(DatosWsDue Datos, object userState) {
            if ((this.getDatosWsDueOperationCompleted == null)) {
                this.getDatosWsDueOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetDatosWsDueOperationCompleted);
            }
            this.InvokeAsync("getDatosWsDue", new object[] {
                        Datos}, this.getDatosWsDueOperationCompleted, userState);
        }
        
        private void OngetDatosWsDueOperationCompleted(object arg) {
            if ((this.getDatosWsDueCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getDatosWsDueCompleted(this, new getDatosWsDueCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2046.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:/due/ws_due/server_ws_due_v2b.php")]
    public partial class DatosWsDue {
        
        private string cod_empField;
        
        private string usuarioField;
        
        private string passwordField;
        
        private string llave_idField;
        
        private string nombresField;
        
        private string apellidosField;
        
        private string divisionField;
        
        private string identificacionField;
        
        /// <comentarios/>
        public string cod_emp {
            get {
                return this.cod_empField;
            }
            set {
                this.cod_empField = value;
            }
        }
        
        /// <comentarios/>
        public string usuario {
            get {
                return this.usuarioField;
            }
            set {
                this.usuarioField = value;
            }
        }
        
        /// <comentarios/>
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <comentarios/>
        public string llave_id {
            get {
                return this.llave_idField;
            }
            set {
                this.llave_idField = value;
            }
        }
        
        /// <comentarios/>
        public string nombres {
            get {
                return this.nombresField;
            }
            set {
                this.nombresField = value;
            }
        }
        
        /// <comentarios/>
        public string apellidos {
            get {
                return this.apellidosField;
            }
            set {
                this.apellidosField = value;
            }
        }
        
        /// <comentarios/>
        public string division {
            get {
                return this.divisionField;
            }
            set {
                this.divisionField = value;
            }
        }
        
        /// <comentarios/>
        public string identificacion {
            get {
                return this.identificacionField;
            }
            set {
                this.identificacionField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2046.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:/due/ws_due/server_ws_due_v2b.php")]
    public partial class Respuesta {
        
        private string lista_clintonField;
        
        private string otros_organismosField;
        
        private string linkField;
        
        private string detalle_otrosField;
        
        private string detalle_usField;
        
        /// <comentarios/>
        public string lista_clinton {
            get {
                return this.lista_clintonField;
            }
            set {
                this.lista_clintonField = value;
            }
        }
        
        /// <comentarios/>
        public string otros_organismos {
            get {
                return this.otros_organismosField;
            }
            set {
                this.otros_organismosField = value;
            }
        }
        
        /// <comentarios/>
        public string link {
            get {
                return this.linkField;
            }
            set {
                this.linkField = value;
            }
        }
        
        /// <comentarios/>
        public string detalle_otros {
            get {
                return this.detalle_otrosField;
            }
            set {
                this.detalle_otrosField = value;
            }
        }
        
        /// <comentarios/>
        public string detalle_us {
            get {
                return this.detalle_usField;
            }
            set {
                this.detalle_usField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void getDatosWsDueCompletedEventHandler(object sender, getDatosWsDueCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getDatosWsDueCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getDatosWsDueCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Respuesta Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Respuesta)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591