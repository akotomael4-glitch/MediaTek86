namespace MediaTek86.Vue
{
    partial class FrmAbsence
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
            this.dataGridViewAbsences = new System.Windows.Forms.DataGridView();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModfier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAbsences)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAbsences
            // 
            this.dataGridViewAbsences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAbsences.Location = new System.Drawing.Point(219, 120);
            this.dataGridViewAbsences.Name = "dataGridViewAbsences";
            this.dataGridViewAbsences.RowHeadersWidth = 62;
            this.dataGridViewAbsences.RowTemplate.Height = 28;
            this.dataGridViewAbsences.Size = new System.Drawing.Size(372, 150);
            this.dataGridViewAbsences.TabIndex = 0;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(219, 314);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 43);
            this.btnAjouter.TabIndex = 1;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModfier
            // 
            this.btnModfier.Location = new System.Drawing.Point(368, 316);
            this.btnModfier.Name = "btnModfier";
            this.btnModfier.Size = new System.Drawing.Size(75, 38);
            this.btnModfier.TabIndex = 2;
            this.btnModfier.Text = "Modifier";
            this.btnModfier.UseVisualStyleBackColor = true;
            this.btnModfier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(516, 316);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(106, 38);
            this.btnSupprimer.TabIndex = 3;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // FrmAbsence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModfier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.dataGridViewAbsences);
            this.Name = "FrmAbsence";
            this.Text = "FrmAbsence";
            this.Load += new System.EventHandler(this.FrmAbsence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAbsences)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAbsences;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModfier;
        private System.Windows.Forms.Button btnSupprimer;
    }
}