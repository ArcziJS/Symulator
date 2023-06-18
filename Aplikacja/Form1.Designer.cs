namespace Aplikacja
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableComboBox = new ComboBox();
            dataGridView = new DataGridView();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            executeQueryButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // tableComboBox
            // 
            tableComboBox.FormattingEnabled = true;
            tableComboBox.Location = new Point(70, 12);
            tableComboBox.Name = "tableComboBox";
            tableComboBox.Size = new Size(121, 23);
            tableComboBox.TabIndex = 0;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.Location = new Point(0, 70);
            dataGridView.MaximumSize = new Size(1900, 1000);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 40;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(172, 28);
            dataGridView.TabIndex = 1;
            // 
            // addButton
            // 
            addButton.Location = new Point(93, 41);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 3;
            addButton.Text = "DODAJ";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(174, 41);
            editButton.Name = "editButton";
            editButton.Size = new Size(75, 23);
            editButton.TabIndex = 4;
            editButton.Text = "EDYTUJ";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(255, 41);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 5;
            deleteButton.Text = "USUŃ";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // executeQueryButton
            // 
            executeQueryButton.Location = new Point(12, 41);
            executeQueryButton.Name = "executeQueryButton";
            executeQueryButton.Size = new Size(75, 23);
            executeQueryButton.TabIndex = 6;
            executeQueryButton.Text = "WCZYTAJ";
            executeQueryButton.UseVisualStyleBackColor = true;
            executeQueryButton.Click += executeQueryButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 7;
            label1.Text = "Wybierz:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(337, 98);
            Controls.Add(label1);
            Controls.Add(executeQueryButton);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(tableComboBox);
            Controls.Add(dataGridView);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Artur Siudak";
            Click += executeQueryButton_Click;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox tableComboBox;
        private DataGridView dataGridView;
        private Button addButton;
        private Button editButton;
        private Button deleteButton;
        private Button executeQueryButton;
        private Label label1;
    }
}