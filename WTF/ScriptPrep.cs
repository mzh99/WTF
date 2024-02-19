using Microsoft.CodeAnalysis.Scripting;
using System.Collections.Generic;
using System.Linq;

namespace WTF {

   public class ScriptPrep<T> {
      public string Code { get; private set; }
      public string CompileErrors { get; private set; }
      public string ExecuteErrors { get; private set; }
      public Script<T> CompiledCode { get; private set; }
      public bool HasCode { get; private set; }
      public List<string> Imports { get; private set; }

      public bool HasCompileErrors { get { return HasCode && CompileErrors != string.Empty; } }

      public ScriptPrep(string codeToExecute) : this(codeToExecute, ScriptRunner.CommonImports) { }

      public ScriptPrep(string codeToExecute, IEnumerable<string> imports) {
         Code = codeToExecute == null ? string.Empty : codeToExecute.Trim();
         HasCode = Code != string.Empty;
         ExecuteErrors = string.Empty;
         Imports = imports.ToList();
         Compile();
      }

      private void Compile() {
         if (HasCode) {
            CompiledCode = ScriptRunner.TryCompileScript<T, GlobalVars>(Code, Imports, out string err);
            CompileErrors = err;
         }
      }

      public T Execute(GlobalVars globalVars) {
         T ret = ScriptRunner.ExecuteCode(CompiledCode, globalVars, out string err);
         ExecuteErrors = err;
         return ret;
      }

   }

}
