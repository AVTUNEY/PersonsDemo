﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shared {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SharedResource_ka_GE {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SharedResource_ka_GE() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("TBCDemo.WebApi.Resources.SharedResource_ka_GE", typeof(SharedResource_ka_GE).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string RequiredErrorMessage {
            get {
                return ResourceManager.GetString("RequiredErrorMessage", resourceCulture);
            }
        }
        
        internal static string StringLengthErrorMessage {
            get {
                return ResourceManager.GetString("StringLengthErrorMessage", resourceCulture);
            }
        }
        
        internal static string InvalidCharactersErrorMessage {
            get {
                return ResourceManager.GetString("InvalidCharactersErrorMessage", resourceCulture);
            }
        }
        
        internal static string AgeRestrictionErrorMessage {
            get {
                return ResourceManager.GetString("AgeRestrictionErrorMessage", resourceCulture);
            }
        }
        
        internal static string PersonalNumberDigitsOnlyErrorMessage {
            get {
                return ResourceManager.GetString("PersonalNumberDigitsOnlyErrorMessage", resourceCulture);
            }
        }
        
        internal static string PersonalNumberDigitsNumberErrorMessage {
            get {
                return ResourceManager.GetString("PersonalNumberDigitsNumberErrorMessage", resourceCulture);
            }
        }
    }
}
