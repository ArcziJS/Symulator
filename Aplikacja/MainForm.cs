using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace Aplikacja
{
    public partial class MainForm : Form
    {
        private OracleConnection connection;
        private OracleCommand command;
        private string dsn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=217.173.198.135)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=tpdb)));User Id=s101700;Password=s101700;";
        private string selectedTable;



        public MainForm()
        {
            InitializeComponent();
            connection = new OracleConnection(dsn);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT table_name FROM user_tables";
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tableComboBox.Items.Add(reader.GetString(0));
            }
        }
        private void executeQueryButton_Click(object sender, EventArgs e)
        {
            string selectedTable = tableComboBox.Text;
            if (!string.IsNullOrEmpty(selectedTable))
            {
                command.CommandText = $"SELECT column_name FROM user_tab_columns WHERE table_name = '{selectedTable}' AND column_id = 1";
                string firstColumnName = (string)command.ExecuteScalar();

                command.CommandText = $"SELECT * FROM \"{selectedTable}\" ORDER BY {firstColumnName}";
                OracleDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView.DataSource = dataTable;

                int width = dataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + dataGridView.RowHeadersWidth + 20;
                this.Width = 350;
                dataGridView.Width = width;
                int height = dataTable.Rows.Count * 20;
                this.Height = Math.Min(height, 800);
                dataGridView.Height = Math.Min(height, 800);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            selectedTable = tableComboBox.Text;
            if (!string.IsNullOrEmpty(selectedTable))
            {
                AddRecordForm addRecordForm = new AddRecordForm(connection, selectedTable);
                addRecordForm.ShowDialog();
                executeQueryButton.PerformClick();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                string[] primaryKeys = GetPrimaryKeyColumns();
                if (primaryKeys.Length > 0)
                {
                    string whereClause = "";
                    for (int i = 0; i < primaryKeys.Length; i++)
                    {
                        whereClause += $"{primaryKeys[i]} = '{row.Cells[primaryKeys[i]].Value}'";
                        if (i < primaryKeys.Length - 1)
                        {
                            whereClause += " AND ";
                        }
                    }
                    command.CommandText = $"DELETE FROM {selectedTable} WHERE {whereClause}";
                    command.ExecuteNonQuery();
                    executeQueryButton.PerformClick();
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                EditRecordForm editRecordForm = new EditRecordForm(connection, selectedTable, row);
                editRecordForm.ShowDialog();
                executeQueryButton.PerformClick();
            }
        }

        private string[] GetPrimaryKeyColumns()
        {
            command.CommandText = $"SELECT column_name FROM user_cons_columns WHERE table_name = '{selectedTable}' AND constraint_name = (SELECT constraint_name FROM user_constraints WHERE table_name = '{selectedTable}' AND constraint_type = 'P')";
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
    }
}
