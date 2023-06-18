using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Aplikacja
{
    public partial class EditRecordForm : Form
    {
        private OracleConnection connection;
        private string selectedTable;
        private DataGridViewRow row;
        private TextBox[] textBoxes;

        public EditRecordForm(OracleConnection connection, string selectedTable, DataGridViewRow row)
        {
            InitializeComponent();
            this.connection = connection;
            this.selectedTable = selectedTable;
            this.row = row;

            OracleCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT column_name FROM user_tab_columns WHERE table_name = '{selectedTable}'";
            OracleDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            textBoxes = new TextBox[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Label label = new Label();
                label.Text = dataTable.Rows[i][0].ToString();
                label.Location = new System.Drawing.Point(10, 10 + i * 30);
                label.AutoSize = true;
                this.Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Text = row.Cells[label.Text].Value.ToString();
                textBox.Location = new System.Drawing.Point(150, 10 + i * 30);
                this.Controls.Add(textBox);
                textBoxes[i] = textBox;
            }

            Button updateButton = new Button();
            updateButton.Text = "EDYTUJ";
            updateButton.Location = new System.Drawing.Point(10, 20 + dataTable.Rows.Count * 30);
            updateButton.Click += UpdateButton_Click;
            this.Controls.Add(updateButton);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string[] setValues = new string[textBoxes.Length];
            for (int i = 0; i < textBoxes.Length; i++)
            {
                setValues[i] = $"{row.Cells[i].OwningColumn.HeaderText}='{textBoxes[i].Text}'";
            }
            string setValuesStr = string.Join(", ", setValues);

            string[] primaryKeys = GetPrimaryKeyColumns();
            string[] whereValues = new string[primaryKeys.Length];
            for (int i = 0; i < primaryKeys.Length; i++)
            {
                whereValues[i] = $"{primaryKeys[i]}='{row.Cells[primaryKeys[i]].Value}'";
            }
            string whereValuesStr = string.Join(" AND ", whereValues);

            OracleCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE {selectedTable} SET {setValuesStr} WHERE {whereValuesStr}";
            command.ExecuteNonQuery();

            this.Close();
        }

        private string[] GetPrimaryKeyColumns()
        {
            OracleCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT column_name FROM user_cons_columns WHERE table_name='{selectedTable}' AND constraint_name=(SELECT constraint_name FROM user_constraints WHERE table_name='{selectedTable}' AND constraint_type='P')";
            OracleDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            string[] primaryKeys = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                primaryKeys[i] = dataTable.Rows[i][0].ToString();
            }
            return primaryKeys;
        }
    }
}
