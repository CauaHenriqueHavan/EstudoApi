﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace estudo.api {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ResourceApi {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceApi() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("estudo.api.ResourceApi", typeof(ResourceApi).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo &apos;{0}&apos; não pode ser vazio!.
        /// </summary>
        internal static string CampoVazio {
            get {
                return ResourceManager.GetString("CampoVazio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O Cpf inserido é inválido!.
        /// </summary>
        internal static string CpfInvalido {
            get {
                return ResourceManager.GetString("CpfInvalido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data de nascimento esta inválida!.
        /// </summary>
        internal static string DataNascimentoInvalida {
            get {
                return ResourceManager.GetString("DataNascimentoInvalida", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não foi possivel alterar cadastro.
        /// </summary>
        internal static string NaoFoiPossivelAlterarCadastro {
            get {
                return ResourceManager.GetString("NaoFoiPossivelAlterarCadastro", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Situação Alterada com sucesso !.
        /// </summary>
        internal static string SituacaoAlteradaComSucesso {
            get {
                return ResourceManager.GetString("SituacaoAlteradaComSucesso", resourceCulture);
            }
        }
    }
}
