namespace E3.UpdateAttributes.Gui
{
    partial class PlugIn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetAttributes = new System.Windows.Forms.Button();
            this.btnUpdateAttributes = new System.Windows.Forms.Button();
            this.lbAttributes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnGetAttributes
            // 
            this.btnGetAttributes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnGetAttributes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetAttributes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAttributes.ForeColor = System.Drawing.Color.Black;
            this.btnGetAttributes.Location = new System.Drawing.Point(6, 3);
            this.btnGetAttributes.Name = "btnGetAttributes";
            this.btnGetAttributes.Size = new System.Drawing.Size(150, 30);
            this.btnGetAttributes.TabIndex = 0;
            this.btnGetAttributes.Text = "Lese Attribute";
            this.btnGetAttributes.UseVisualStyleBackColor = false;
            this.btnGetAttributes.Click += new System.EventHandler(this.btnGetAttributes_Click);
            // 
            // btnUpdateAttributes
            // 
            this.btnUpdateAttributes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btnUpdateAttributes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateAttributes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUpdateAttributes.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateAttributes.Location = new System.Drawing.Point(162, 3);
            this.btnUpdateAttributes.Name = "btnUpdateAttributes";
            this.btnUpdateAttributes.Size = new System.Drawing.Size(147, 30);
            this.btnUpdateAttributes.TabIndex = 2;
            this.btnUpdateAttributes.Text = "Update";
            this.btnUpdateAttributes.UseVisualStyleBackColor = false;
            this.btnUpdateAttributes.Click += new System.EventHandler(this.btnUpdateAttributes_Click);
            // 
            // lbAttributes
            // 
            this.lbAttributes.FormattingEnabled = true;
            this.lbAttributes.Location = new System.Drawing.Point(6, 39);
            this.lbAttributes.Name = "lbAttributes";
            this.lbAttributes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAttributes.Size = new System.Drawing.Size(303, 251);
            this.lbAttributes.TabIndex = 3;
            // 
            // PlugIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbAttributes);
            this.Controls.Add(this.btnGetAttributes);
            this.Controls.Add(this.btnUpdateAttributes);
            this.Name = "PlugIn";
            this.Size = new System.Drawing.Size(313, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAttributes;
        private System.Windows.Forms.Button btnUpdateAttributes;
        private System.Windows.Forms.ListBox lbAttributes;
    }
}
