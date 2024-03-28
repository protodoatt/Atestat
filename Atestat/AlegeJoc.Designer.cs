namespace Atestat
{
    partial class AlegeJoc
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idRezultatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipJocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailUtilizatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.punctajJocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rezultateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jocEducativDataSet = new Atestat.JocEducativDataSet();
            this.rezultateTableAdapter = new Atestat.JocEducativDataSetTableAdapters.RezultateTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezultateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jocEducativDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "You are not supposed to see this";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRezultatDataGridViewTextBoxColumn,
            this.tipJocDataGridViewTextBoxColumn,
            this.emailUtilizatorDataGridViewTextBoxColumn,
            this.punctajJocDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.rezultateBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(81, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 273);
            this.dataGridView1.TabIndex = 1;
            // 
            // idRezultatDataGridViewTextBoxColumn
            // 
            this.idRezultatDataGridViewTextBoxColumn.DataPropertyName = "IdRezultat";
            this.idRezultatDataGridViewTextBoxColumn.HeaderText = "IdRezultat";
            this.idRezultatDataGridViewTextBoxColumn.Name = "idRezultatDataGridViewTextBoxColumn";
            this.idRezultatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipJocDataGridViewTextBoxColumn
            // 
            this.tipJocDataGridViewTextBoxColumn.DataPropertyName = "TipJoc";
            this.tipJocDataGridViewTextBoxColumn.HeaderText = "TipJoc";
            this.tipJocDataGridViewTextBoxColumn.Name = "tipJocDataGridViewTextBoxColumn";
            // 
            // emailUtilizatorDataGridViewTextBoxColumn
            // 
            this.emailUtilizatorDataGridViewTextBoxColumn.DataPropertyName = "EmailUtilizator";
            this.emailUtilizatorDataGridViewTextBoxColumn.HeaderText = "EmailUtilizator";
            this.emailUtilizatorDataGridViewTextBoxColumn.Name = "emailUtilizatorDataGridViewTextBoxColumn";
            // 
            // punctajJocDataGridViewTextBoxColumn
            // 
            this.punctajJocDataGridViewTextBoxColumn.DataPropertyName = "PunctajJoc";
            this.punctajJocDataGridViewTextBoxColumn.HeaderText = "PunctajJoc";
            this.punctajJocDataGridViewTextBoxColumn.Name = "punctajJocDataGridViewTextBoxColumn";
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            // 
            // rezultateBindingSource
            // 
            this.rezultateBindingSource.DataMember = "Rezultate";
            this.rezultateBindingSource.DataSource = this.jocEducativDataSet;
            // 
            // jocEducativDataSet
            // 
            this.jocEducativDataSet.DataSetName = "JocEducativDataSet";
            this.jocEducativDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rezultateTableAdapter
            // 
            this.rezultateTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Testeaza Memoria";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AlegeJoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "AlegeJoc";
            this.Text = "AlegeJoc";
            this.Load += new System.EventHandler(this.AlegeJoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezultateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jocEducativDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private JocEducativDataSet jocEducativDataSet;
        private System.Windows.Forms.BindingSource rezultateBindingSource;
        private JocEducativDataSetTableAdapters.RezultateTableAdapter rezultateTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRezultatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipJocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailUtilizatorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn punctajJocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}