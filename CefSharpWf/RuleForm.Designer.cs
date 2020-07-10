namespace CefSharpWf
{
    partial class RuleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.edtName = new System.Windows.Forms.TextBox();
            this.chbActive = new System.Windows.Forms.CheckBox();
            this.edtUrlSearchPattern = new System.Windows.Forms.TextBox();
            this.cbRequestResponse = new System.Windows.Forms.ComboBox();
            this.cbAction = new System.Windows.Forms.ComboBox();
            this.edtSearchPattern = new System.Windows.Forms.TextBox();
            this.edtReplaceStr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя правила";
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.Location = new System.Drawing.Point(165, 13);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(228, 20);
            this.edtName.TabIndex = 1;
            // 
            // chbActive
            // 
            this.chbActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbActive.AutoSize = true;
            this.chbActive.Location = new System.Drawing.Point(165, 40);
            this.chbActive.Name = "chbActive";
            this.chbActive.Size = new System.Drawing.Size(68, 17);
            this.chbActive.TabIndex = 3;
            this.chbActive.Text = "Активно";
            this.chbActive.UseVisualStyleBackColor = true;
            this.chbActive.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // edtUrlSearchPattern
            // 
            this.edtUrlSearchPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUrlSearchPattern.Location = new System.Drawing.Point(165, 63);
            this.edtUrlSearchPattern.Name = "edtUrlSearchPattern";
            this.edtUrlSearchPattern.Size = new System.Drawing.Size(228, 20);
            this.edtUrlSearchPattern.TabIndex = 4;
            this.edtUrlSearchPattern.TextChanged += new System.EventHandler(this.edtUrlSearchPattern_TextChanged);
            // 
            // cbRequestResponse
            // 
            this.cbRequestResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRequestResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRequestResponse.FormattingEnabled = true;
            this.cbRequestResponse.Location = new System.Drawing.Point(165, 90);
            this.cbRequestResponse.Name = "cbRequestResponse";
            this.cbRequestResponse.Size = new System.Drawing.Size(228, 21);
            this.cbRequestResponse.TabIndex = 5;
            // 
            // cbAction
            // 
            this.cbAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAction.FormattingEnabled = true;
            this.cbAction.Location = new System.Drawing.Point(165, 117);
            this.cbAction.Name = "cbAction";
            this.cbAction.Size = new System.Drawing.Size(228, 21);
            this.cbAction.TabIndex = 6;
            // 
            // edtSearchPattern
            // 
            this.edtSearchPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSearchPattern.Location = new System.Drawing.Point(165, 144);
            this.edtSearchPattern.Name = "edtSearchPattern";
            this.edtSearchPattern.Size = new System.Drawing.Size(228, 20);
            this.edtSearchPattern.TabIndex = 7;
            this.edtSearchPattern.TextChanged += new System.EventHandler(this.edtSearchPattern_TextChanged);
            // 
            // edtReplaceStr
            // 
            this.edtReplaceStr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtReplaceStr.Location = new System.Drawing.Point(165, 170);
            this.edtReplaceStr.Name = "edtReplaceStr";
            this.edtReplaceStr.Size = new System.Drawing.Size(228, 20);
            this.edtReplaceStr.TabIndex = 8;
            this.edtReplaceStr.TextChanged += new System.EventHandler(this.edtReplaceStr_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Шаблон Url";            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Объект";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Действие";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Шаблон поиска для замены";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Текст для замены";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(318, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(237, 196);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // RuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 228);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtReplaceStr);
            this.Controls.Add(this.edtSearchPattern);
            this.Controls.Add(this.cbAction);
            this.Controls.Add(this.cbRequestResponse);
            this.Controls.Add(this.edtUrlSearchPattern);
            this.Controls.Add(this.chbActive);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(417, 266);
            this.Name = "RuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Правило обработки http";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtName;
        private System.Windows.Forms.CheckBox chbActive;
        private System.Windows.Forms.TextBox edtUrlSearchPattern;
        private System.Windows.Forms.ComboBox cbRequestResponse;
        private System.Windows.Forms.ComboBox cbAction;
        private System.Windows.Forms.TextBox edtSearchPattern;
        private System.Windows.Forms.TextBox edtReplaceStr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}