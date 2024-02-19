using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace WTF {

   /* 
      Sample Command lines:
         "E:\Data\Source\CS\WTF\WTF\bin\Debug\WTF.exe" "/aE:\Data\DL" /m*.* "/oE:\Data\DL\SampleOutput.txt" "/fE:\Data\DL\Samples\OnFile1.txt"
         "E:\Data\Source\CS\WTF\WTF\bin\Debug\WTF.exe" "/aE:\Data\Source\CS" /m*.* "/oE:\Data\DL\HiddenFilesOutput.txt" /s "/fE:\Data\DL\Samples\FindHiddenFiles.txt"
   */

   public partial class Main_Frm: Form {
      private static readonly string ParmsLastRunName = "WTF-LastRunParms.txt";
      // for when run as a command-line app since WinForms apps don't get a console by default
      private static readonly string LastRunOutputName = "WTF-LastRunOutput.txt";

      public SearchProcessor Searcher { get; private set; }

      private CmdlineHelper cmdLineHelper;
      private RunParms runParms;
      private readonly string lastRunParmsFullPath;
      private readonly string lastRunOutputFullPath;

      public Main_Frm() {
         InitializeComponent();
         string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
         lastRunParmsFullPath = Path.Combine(docs, ParmsLastRunName);
         lastRunOutputFullPath = Path.Combine(docs, LastRunOutputName);
      }

      private void Main_Frm_Load(object sender, EventArgs e) {
         cmdLineHelper = new CmdlineHelper(Environment.GetCommandLineArgs());
         if (cmdLineHelper.RunViaCommandLine) {
            StringBuilder lastOutputSB = new StringBuilder();
            // move off screen as alternative to hide
            var maxWidth = Screen.AllScreens.Max(b => b.Bounds.Width);
            var maxHeight = Screen.AllScreens.Max(b => b.Bounds.Height);
            this.Location = new System.Drawing.Point(maxWidth + 1, maxHeight + 1);
            this.ShowInTaskbar = false;

            runParms = cmdLineHelper.ReturnPackage;
            var errors = runParms.GetValidationErrors().ToList();
            // ShowInfo($"Cmd Line: All Req: {cmdLineHelper.AllReqParmsPresent}, Error Count: {errors.Count},\r\nStart: {runParms.StartFolder}{runParms.SearchMask}\r\nSubs: {runParms.ProcessSubFolders}\r\nOutput: {runParms.OutputFilename}\r\nFile Code: {runParms.OnFileCodeLoc}\r\nFolder Code: {runParms.OnFolderCodeLoc}");
            if (errors.Count == 0) {
               lastOutputSB.AppendLine($"Folder and search filter: {runParms.StartFolder}\\{runParms.SearchMask}");
               lastOutputSB.AppendLine($"Process Sub-folders: {runParms.ProcessSubFolders}");
               lastOutputSB.AppendLine($"Output File: {runParms.OutputFilename}");
               if (runParms.OnFileCodeLoc != string.Empty)
                  lastOutputSB.AppendLine($"OnFile Code File: {runParms.OnFileCodeLoc}");
               if (runParms.OnFolderCodeLoc != string.Empty)
                  lastOutputSB.AppendLine($"OnFolder Code File: {runParms.OnFolderCodeLoc}");

               Searcher = new SearchProcessor(runParms);
               Searcher.Search();
               lastOutputSB.AppendLine("Success");
               Environment.ExitCode = 0;
            }
            else {
               lastOutputSB.AppendLine("Errors on Run:");
               string errMsgs = string.Join("\r\n", WTFErrors.GetErrorMessagesEN(errors));
               lastOutputSB.AppendLine(errMsgs);
               if (runParms.HasCompileErrors) {
                  lastOutputSB.AppendLine(runParms.CompileErrors);
               }
               // return the first error to calling program/cmd
               Environment.ExitCode = errors[0];
            }
            File.WriteAllText(lastRunOutputFullPath, lastOutputSB.ToString());
            Close();
         }
         else {   // UI/Interactive
            runParms = GetLastRunParms();
            StartDir_TB.Text = runParms.StartFolder;
            SearchMask_TB.Text = runParms.SearchMask;
            ProcessSubs_CB.Checked = runParms.ProcessSubFolders;
            OnFileCode_TB.Text = runParms.OnFileCodeLoc;
            OnFolderCode_TB.Text = runParms.OnFolderCodeLoc;
            OutputLoc_TB.Text = runParms.OutputFilename;
         }
      }

      private void GetParmsFromUI() {
         runParms = new RunParms() {
            StartFolder = StartDir_TB.Text,
            SearchMask = SearchMask_TB.Text,
            OutputFilename = OutputLoc_TB.Text,
            ProcessSubFolders = ProcessSubs_CB.Checked,
            OnFileCodeLoc = OnFileCode_TB.Text,
            OnFolderCodeLoc = OnFolderCode_TB.Text
         };
      }
      private void Process_Btn_Click(object sender, EventArgs e) {
         GetParmsFromUI();
         var errors = runParms.GetValidationErrors().ToList();
         if (errors.Count == 0) {
            SaveLastRunParms();
            Searcher = new SearchProcessor(runParms);
            Searcher.Search();
            ShowInfo("Processing complete");
         }
         else {
            string errMsgs = string.Join("\r\n", WTFErrors.GetErrorMessagesEN(errors));
            ShowError(errMsgs);
         }
      }

      private void TestCode_Btn_Click(object sender, EventArgs e) {
         GetParmsFromUI();
         var errors = runParms.GetValidationErrors().ToList();
         if (errors.Count == 0) {
            ShowInfo("All code compiled successfully.");
         }
         else {
            string errMsgs = string.Join("\r\n", WTFErrors.GetErrorMessagesEN(errors));
            if (runParms.HasCompileErrors) {
               errMsgs += runParms.CompileErrors;
            }
            ShowError(errMsgs);
         }
      }

      private void GenCmd_Btn_Click(object sender, EventArgs e) {
         GetParmsFromUI();
         var errors = runParms.GetValidationErrors().ToList();
         if (errors.Count == 0) {
            string cmd = "\"" + Application.ExecutablePath + "\" " + CmdlineHelper.ConstructCommandLineString(runParms, @"/");
            Clipboard.SetText(cmd, TextDataFormat.Text);
            ShowInfo("The following command-line has been copied to the system clipboard:\r\n" + cmd);
         }
         else {
            string errMsgs = string.Join("\r\n", WTFErrors.GetErrorMessagesEN(errors));
            ShowError(errMsgs);
         }
      }

      private void ShowError(string err) {
         MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      private void ShowInfo(string msg) {
         MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      private void DirSelect_Btn_Click(object sender, EventArgs e) {
         if (FolderBrowser_Dlg.ShowDialog() == DialogResult.OK) {
            StartDir_TB.Text = FolderBrowser_Dlg.SelectedPath;
            StartDir_TB.Focus();
         }
      }

      private void OnFileCode_Btn_Click(object sender, EventArgs e) {
         GetOpenResult(OnFileCode_TB);
      }

      private void OnFolderCode_Btn_Click(object sender, EventArgs e) {
         GetOpenResult(OnFolderCode_TB);
      }

      private void OutputLoc_Btn_Click(object sender, EventArgs e) {
         Save_Dlg.FileName = OutputLoc_TB.Text;
         DialogResult ret = Save_Dlg.ShowDialog();
         if (ret == DialogResult.OK) {
            OutputLoc_TB.Text = Save_Dlg.FileName;
            OutputLoc_TB.Focus();
         }
      }

      private DialogResult GetOpenResult(TextBox tb) {
         OpenFile_Dlg.FileName = tb.Text;
         DialogResult ret = OpenFile_Dlg.ShowDialog();
         if (ret == DialogResult.OK) {
            tb.Text = OpenFile_Dlg.FileName;
            tb.Focus();
         }
         return ret;
      }

      private void SaveLastRunParms() {
         File.WriteAllText(lastRunParmsFullPath, JsonSerializer.Serialize(runParms));
      }

      private RunParms GetLastRunParms() {
         return File.Exists(lastRunParmsFullPath) ? JsonSerializer.Deserialize<RunParms>(File.ReadAllText(lastRunParmsFullPath)) : new RunParms();
      }

   }

}
