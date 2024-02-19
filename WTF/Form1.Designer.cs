namespace WTF {
   partial class Main_Frm {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.label1 = new System.Windows.Forms.Label();
         this.StartDir_TB = new System.Windows.Forms.TextBox();
         this.DirSelect_Btn = new System.Windows.Forms.Button();
         this.FolderBrowser_Dlg = new System.Windows.Forms.FolderBrowserDialog();
         this.ProcessSubs_CB = new System.Windows.Forms.CheckBox();
         this.label2 = new System.Windows.Forms.Label();
         this.SearchMask_TB = new System.Windows.Forms.TextBox();
         this.Process_Btn = new System.Windows.Forms.Button();
         this.OpenFile_Dlg = new System.Windows.Forms.OpenFileDialog();
         this.OnFileCode_Btn = new System.Windows.Forms.Button();
         this.OnFileCode_TB = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.OnFolderCode_Btn = new System.Windows.Forms.Button();
         this.OnFolderCode_TB = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.TestCode_Btn = new System.Windows.Forms.Button();
         this.OutputLoc_Btn = new System.Windows.Forms.Button();
         this.OutputLoc_TB = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.Save_Dlg = new System.Windows.Forms.SaveFileDialog();
         this.GenCmd_Btn = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(109, 25);
         this.label1.TabIndex = 0;
         this.label1.Text = "Starting Folder:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // StartDir_TB
         // 
         this.StartDir_TB.Location = new System.Drawing.Point(139, 10);
         this.StartDir_TB.MaxLength = 250;
         this.StartDir_TB.Name = "StartDir_TB";
         this.StartDir_TB.Size = new System.Drawing.Size(457, 22);
         this.StartDir_TB.TabIndex = 1;
         this.StartDir_TB.WordWrap = false;
         // 
         // DirSelect_Btn
         // 
         this.DirSelect_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.DirSelect_Btn.Location = new System.Drawing.Point(602, 3);
         this.DirSelect_Btn.Name = "DirSelect_Btn";
         this.DirSelect_Btn.Size = new System.Drawing.Size(49, 34);
         this.DirSelect_Btn.TabIndex = 2;
         this.DirSelect_Btn.Text = "...";
         this.DirSelect_Btn.UseVisualStyleBackColor = true;
         this.DirSelect_Btn.Click += new System.EventHandler(this.DirSelect_Btn_Click);
         // 
         // FolderBrowser_Dlg
         // 
         this.FolderBrowser_Dlg.Description = "Starting Folder";
         this.FolderBrowser_Dlg.RootFolder = System.Environment.SpecialFolder.MyComputer;
         this.FolderBrowser_Dlg.ShowNewFolderButton = false;
         // 
         // ProcessSubs_CB
         // 
         this.ProcessSubs_CB.Checked = true;
         this.ProcessSubs_CB.CheckState = System.Windows.Forms.CheckState.Checked;
         this.ProcessSubs_CB.Location = new System.Drawing.Point(383, 47);
         this.ProcessSubs_CB.Name = "ProcessSubs_CB";
         this.ProcessSubs_CB.Size = new System.Drawing.Size(213, 22);
         this.ProcessSubs_CB.TabIndex = 7;
         this.ProcessSubs_CB.Text = "Process Subdirectories?";
         this.ProcessSubs_CB.UseVisualStyleBackColor = true;
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(12, 47);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(109, 25);
         this.label2.TabIndex = 4;
         this.label2.Text = "Search Mask:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // SearchMask_TB
         // 
         this.SearchMask_TB.Location = new System.Drawing.Point(139, 47);
         this.SearchMask_TB.MaxLength = 250;
         this.SearchMask_TB.Name = "SearchMask_TB";
         this.SearchMask_TB.Size = new System.Drawing.Size(64, 22);
         this.SearchMask_TB.TabIndex = 5;
         this.SearchMask_TB.Text = "*.*";
         this.SearchMask_TB.WordWrap = false;
         // 
         // Process_Btn
         // 
         this.Process_Btn.Location = new System.Drawing.Point(139, 248);
         this.Process_Btn.Name = "Process_Btn";
         this.Process_Btn.Size = new System.Drawing.Size(121, 40);
         this.Process_Btn.TabIndex = 30;
         this.Process_Btn.Text = "Process...";
         this.Process_Btn.UseVisualStyleBackColor = true;
         this.Process_Btn.Click += new System.EventHandler(this.Process_Btn_Click);
         // 
         // OpenFile_Dlg
         // 
         this.OpenFile_Dlg.AddExtension = false;
         this.OpenFile_Dlg.Filter = "C# files|*.cs|Text files|*.txt|All files|*.*";
         this.OpenFile_Dlg.FilterIndex = 3;
         this.OpenFile_Dlg.Title = "Select Code File";
         // 
         // OnFileCode_Btn
         // 
         this.OnFileCode_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.OnFileCode_Btn.Location = new System.Drawing.Point(602, 82);
         this.OnFileCode_Btn.Name = "OnFileCode_Btn";
         this.OnFileCode_Btn.Size = new System.Drawing.Size(49, 34);
         this.OnFileCode_Btn.TabIndex = 15;
         this.OnFileCode_Btn.Text = "...";
         this.OnFileCode_Btn.UseVisualStyleBackColor = true;
         this.OnFileCode_Btn.Click += new System.EventHandler(this.OnFileCode_Btn_Click);
         // 
         // OnFileCode_TB
         // 
         this.OnFileCode_TB.Location = new System.Drawing.Point(139, 89);
         this.OnFileCode_TB.MaxLength = 250;
         this.OnFileCode_TB.Name = "OnFileCode_TB";
         this.OnFileCode_TB.Size = new System.Drawing.Size(457, 22);
         this.OnFileCode_TB.TabIndex = 14;
         this.OnFileCode_TB.WordWrap = false;
         // 
         // label5
         // 
         this.label5.Location = new System.Drawing.Point(12, 89);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(117, 25);
         this.label5.TabIndex = 13;
         this.label5.Text = "On File Code:";
         this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // OnFolderCode_Btn
         // 
         this.OnFolderCode_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.OnFolderCode_Btn.Location = new System.Drawing.Point(602, 128);
         this.OnFolderCode_Btn.Name = "OnFolderCode_Btn";
         this.OnFolderCode_Btn.Size = new System.Drawing.Size(49, 34);
         this.OnFolderCode_Btn.TabIndex = 18;
         this.OnFolderCode_Btn.Text = "...";
         this.OnFolderCode_Btn.UseVisualStyleBackColor = true;
         this.OnFolderCode_Btn.Click += new System.EventHandler(this.OnFolderCode_Btn_Click);
         // 
         // OnFolderCode_TB
         // 
         this.OnFolderCode_TB.Location = new System.Drawing.Point(139, 135);
         this.OnFolderCode_TB.MaxLength = 250;
         this.OnFolderCode_TB.Name = "OnFolderCode_TB";
         this.OnFolderCode_TB.Size = new System.Drawing.Size(457, 22);
         this.OnFolderCode_TB.TabIndex = 17;
         this.OnFolderCode_TB.WordWrap = false;
         // 
         // label6
         // 
         this.label6.Location = new System.Drawing.Point(12, 135);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(117, 25);
         this.label6.TabIndex = 16;
         this.label6.Text = "On Folder Code:";
         this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // TestCode_Btn
         // 
         this.TestCode_Btn.Location = new System.Drawing.Point(311, 248);
         this.TestCode_Btn.Name = "TestCode_Btn";
         this.TestCode_Btn.Size = new System.Drawing.Size(121, 40);
         this.TestCode_Btn.TabIndex = 35;
         this.TestCode_Btn.Text = "Test Code...";
         this.TestCode_Btn.UseVisualStyleBackColor = true;
         this.TestCode_Btn.Click += new System.EventHandler(this.TestCode_Btn_Click);
         // 
         // OutputLoc_Btn
         // 
         this.OutputLoc_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.OutputLoc_Btn.Location = new System.Drawing.Point(602, 177);
         this.OutputLoc_Btn.Name = "OutputLoc_Btn";
         this.OutputLoc_Btn.Size = new System.Drawing.Size(49, 34);
         this.OutputLoc_Btn.TabIndex = 22;
         this.OutputLoc_Btn.Text = "...";
         this.OutputLoc_Btn.UseVisualStyleBackColor = true;
         this.OutputLoc_Btn.Click += new System.EventHandler(this.OutputLoc_Btn_Click);
         // 
         // OutputLoc_TB
         // 
         this.OutputLoc_TB.Location = new System.Drawing.Point(139, 184);
         this.OutputLoc_TB.MaxLength = 250;
         this.OutputLoc_TB.Name = "OutputLoc_TB";
         this.OutputLoc_TB.Size = new System.Drawing.Size(457, 22);
         this.OutputLoc_TB.TabIndex = 21;
         this.OutputLoc_TB.WordWrap = false;
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(12, 184);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(117, 25);
         this.label3.TabIndex = 20;
         this.label3.Text = "Output File:";
         this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // Save_Dlg
         // 
         this.Save_Dlg.AddExtension = false;
         this.Save_Dlg.DefaultExt = "txt";
         this.Save_Dlg.Filter = "Text files|*.txt|All files|*.*";
         this.Save_Dlg.Title = "Output File Location";
         // 
         // GenCmd_Btn
         // 
         this.GenCmd_Btn.Location = new System.Drawing.Point(475, 248);
         this.GenCmd_Btn.Name = "GenCmd_Btn";
         this.GenCmd_Btn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.GenCmd_Btn.Size = new System.Drawing.Size(176, 40);
         this.GenCmd_Btn.TabIndex = 40;
         this.GenCmd_Btn.Text = "Generate Command-line";
         this.GenCmd_Btn.UseVisualStyleBackColor = true;
         this.GenCmd_Btn.Click += new System.EventHandler(this.GenCmd_Btn_Click);
         // 
         // Main_Frm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(764, 311);
         this.Controls.Add(this.GenCmd_Btn);
         this.Controls.Add(this.OutputLoc_Btn);
         this.Controls.Add(this.OutputLoc_TB);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.TestCode_Btn);
         this.Controls.Add(this.OnFolderCode_Btn);
         this.Controls.Add(this.OnFolderCode_TB);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.OnFileCode_Btn);
         this.Controls.Add(this.OnFileCode_TB);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.Process_Btn);
         this.Controls.Add(this.SearchMask_TB);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.ProcessSubs_CB);
         this.Controls.Add(this.DirSelect_Btn);
         this.Controls.Add(this.StartDir_TB);
         this.Controls.Add(this.label1);
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Margin = new System.Windows.Forms.Padding(4);
         this.Name = "Main_Frm";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "With The File";
         this.Load += new System.EventHandler(this.Main_Frm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox StartDir_TB;
      private System.Windows.Forms.Button DirSelect_Btn;
      private System.Windows.Forms.FolderBrowserDialog FolderBrowser_Dlg;
      private System.Windows.Forms.CheckBox ProcessSubs_CB;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox SearchMask_TB;
      private System.Windows.Forms.Button Process_Btn;
      private System.Windows.Forms.OpenFileDialog OpenFile_Dlg;
      private System.Windows.Forms.Button OnFileCode_Btn;
      private System.Windows.Forms.TextBox OnFileCode_TB;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Button OnFolderCode_Btn;
      private System.Windows.Forms.TextBox OnFolderCode_TB;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Button TestCode_Btn;
      private System.Windows.Forms.Button OutputLoc_Btn;
      private System.Windows.Forms.TextBox OutputLoc_TB;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.SaveFileDialog Save_Dlg;
      private System.Windows.Forms.Button GenCmd_Btn;
   }
}

