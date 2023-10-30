namespace authNetFramework
{
    partial class FormCreateUser
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
            this.buttonCreate = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxPasswordMinLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPasswordValidityPeriod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(379, 126);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(86, 23);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(269, 15);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(197, 22);
            this.textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя пользователя";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(287, 126);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(86, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxPasswordMinLength
            // 
            this.textBoxPasswordMinLength.Location = new System.Drawing.Point(269, 43);
            this.textBoxPasswordMinLength.Name = "textBoxPasswordMinLength";
            this.textBoxPasswordMinLength.Size = new System.Drawing.Size(196, 22);
            this.textBoxPasswordMinLength.TabIndex = 1;
            this.textBoxPasswordMinLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPasswordMinLength_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Минимальная длина пароля";
            // 
            // textBoxPasswordValidityPeriod
            // 
            this.textBoxPasswordValidityPeriod.Location = new System.Drawing.Point(269, 71);
            this.textBoxPasswordValidityPeriod.Name = "textBoxPasswordValidityPeriod";
            this.textBoxPasswordValidityPeriod.Size = new System.Drawing.Size(197, 22);
            this.textBoxPasswordValidityPeriod.TabIndex = 1;
            this.textBoxPasswordValidityPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPasswordValidityPeriod_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Срок действия пароля";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(269, 99);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(18, 17);
            this.checkBox.TabIndex = 3;
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Установить ограничение на пароль";
            // 
            // FormCreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 155);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPasswordValidityPeriod);
            this.Controls.Add(this.textBoxPasswordMinLength);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonCreate);
            this.Name = "FormCreateUser";
            this.Text = "Создать пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxPasswordMinLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPasswordValidityPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label label4;
    }
}