﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources.Domain {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class DailyNutritionIntake {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DailyNutritionIntake() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Resources.Domain.DailyNutritionIntake", typeof(DailyNutritionIntake).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string Calories {
            get {
                return ResourceManager.GetString("Calories", resourceCulture);
            }
        }
        
        public static string Carbohydrates {
            get {
                return ResourceManager.GetString("Carbohydrates", resourceCulture);
            }
        }
        
        public static string Fats {
            get {
                return ResourceManager.GetString("Fats", resourceCulture);
            }
        }
        
        public static string Protein {
            get {
                return ResourceManager.GetString("Protein", resourceCulture);
            }
        }
        
        public static string UnitType {
            get {
                return ResourceManager.GetString("UnitType", resourceCulture);
            }
        }
        
        public static string LoggedAt {
            get {
                return ResourceManager.GetString("LoggedAt", resourceCulture);
            }
        }
    }
}
