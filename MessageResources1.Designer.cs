﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Minesweeper {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MessageResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MessageResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Minesweeper.MessageResources", typeof(MessageResources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This cell has already been cleared.
        /// </summary>
        public static string CellCleared {
            get {
                return ResourceManager.GetString("CellCleared", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  Cells before victory.
        /// </summary>
        public static string CellsBeforeVictory {
            get {
                return ResourceManager.GetString("CellsBeforeVictory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Entry out of range, enter a value corresonding to a {0} number.
        /// </summary>
        public static string CheckBoundariesError {
            get {
                return ResourceManager.GetString("CheckBoundariesError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter an integer.
        /// </summary>
        public static string CheckIntegerError {
            get {
                return ResourceManager.GetString("CheckIntegerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter {0}:.
        /// </summary>
        public static string EnterInput {
            get {
                return ResourceManager.GetString("EnterInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Game Over.
        /// </summary>
        public static string GameOver {
            get {
                return ResourceManager.GetString("GameOver", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Starting the game.
        /// </summary>
        public static string GameStart {
            get {
                return ResourceManager.GetString("GameStart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Press any key to exit.
        /// </summary>
        public static string PressKeyExit {
            get {
                return ResourceManager.GetString("PressKeyExit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This is a mine.
        /// </summary>
        public static string ThisIsMine {
            get {
                return ResourceManager.GetString("ThisIsMine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You won !.
        /// </summary>
        public static string YouWon {
            get {
                return ResourceManager.GetString("YouWon", resourceCulture);
            }
        }
    }
}
