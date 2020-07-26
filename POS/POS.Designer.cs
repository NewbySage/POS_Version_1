namespace POS
{
    partial class POS
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_editItem = new System.Windows.Forms.Button();
            this.btn_Search_Add = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.txt_barCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_editItem);
            this.panel1.Controls.Add(this.btn_Search_Add);
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Controls.Add(this.txt_barCode);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 116);
            this.panel1.TabIndex = 0;
            // 
            // btn_editItem
            // 
            this.btn_editItem.Location = new System.Drawing.Point(270, 80);
            this.btn_editItem.Name = "btn_editItem";
            this.btn_editItem.Size = new System.Drawing.Size(75, 23);
            this.btn_editItem.TabIndex = 3;
            this.btn_editItem.Text = "Edit Item";
            this.btn_editItem.UseVisualStyleBackColor = true;
            // 
            // btn_Search_Add
            // 
            this.btn_Search_Add.Location = new System.Drawing.Point(165, 80);
            this.btn_Search_Add.Name = "btn_Search_Add";
            this.btn_Search_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Search_Add.TabIndex = 2;
            this.btn_Search_Add.Text = "Search/Add";
            this.btn_Search_Add.UseVisualStyleBackColor = true;
            this.btn_Search_Add.Click += new System.EventHandler(this.btn_Search_Add_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(63, 80);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // txt_barCode
            // 
            this.txt_barCode.Location = new System.Drawing.Point(29, 44);
            this.txt_barCode.Name = "txt_barCode";
            this.txt_barCode.Size = new System.Drawing.Size(345, 20);
            this.txt_barCode.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Location = new System.Drawing.Point(12, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 304);
            this.panel2.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(773, 304);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(462, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 116);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bar Code";
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "POS";
            this.Text = "POS";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_Search_Add;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TextBox txt_barCode;
        private System.Windows.Forms.Button btn_editItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

