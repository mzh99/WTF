using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;

namespace WTF {

   /* 
      https://github.com/dotnet/roslyn/blob/main/docs/wiki/Scripting-API-Samples.md
      https://www.strathweb.com/2019/06/building-a-c-interactive-shell-in-a-browser-with-blazor-webassembly-and-roslyn/
      https://josephwoodward.co.uk/2016/12/in-memory-c-sharp-compilation-using-roslyn
      https://kenslearningcurve.com/tutorials/compiling-c-code-at-runtime/
      https://stackoverflow.com/questions/38277781/how-to-add-and-use-an-import-in-a-script
   */

   public static class ScriptRunner {

      public static readonly string[] CommonImports = new string[] { "System", "System.IO", "System.Collections.Generic" };

      #region Calls for code that don't return a value
      
      // compile code with no return value
      public static Script TryCompileScript<GlobalVars>(string code, IEnumerable<string> imports, out string err) {
         ScriptOptions opts = ScriptOptions
            .Default
            //.WithReferences(Assembly.GetExecutingAssembly())
            .AddImports(imports);
         try {
            var script = CSharpScript.Create(code, opts, typeof(GlobalVars));
            var diags = script.Compile();
            err = diags.Length == 0 ? string.Empty : string.Join("\r\n", diags);
            return diags.Length == 0 ? script : null;
         }
         catch (CompilationErrorException e) {
            err = e.Message;
            return null;
         }
      }

      // execute code with no return value
      public static void ExecuteCode<GlobalVars>(Script script, GlobalVars glob, out string err) {
         err = string.Empty;
         try {
            ScriptState ret = null;
            // script.RunAsync(glob).Wait();
            script.RunAsync(glob).ContinueWith(s => ret = s.Result).Wait();
            if (ret.Exception != null) {
               err = ret.Exception.Message;
            }
         }
         catch (CompilationErrorException e) {
            err = e.Message;
         }
      }

      #endregion

      #region Calls that return a type (using generics)

      public static Script<T> TryCompileScript<T, GlobalVars>(string code, IEnumerable<string> imports, out string err) {
         ScriptOptions opts = ScriptOptions
            .Default
            // .WithReferences(Assembly.GetExecutingAssembly())
            .AddImports(imports);
         try {
            var script = CSharpScript.Create<T>(code, opts, typeof(GlobalVars));
            var diags = script.Compile();
            err = diags.Length == 0 ? string.Empty : string.Join("\r\n", diags);
            return diags.Length == 0 ? script : null;
         }
         catch (CompilationErrorException e) {
            err = e.Message;
            return null;
         }
      }

      public static T ExecuteCode<T, GlobalVars>(Script<T> script, GlobalVars glob, out string err) {
         err = string.Empty;
         T ret = default;
         try {
            script.RunAsync(glob).ContinueWith(s => ret = s.Result.ReturnValue).Wait();
         }
         catch (AggregateException e) {
            err = e.InnerException.Message;
         }
         catch (CompilationErrorException e) {
            err = e.Message;
         }
         return ret;
      }
      
      #endregion

   }

}
