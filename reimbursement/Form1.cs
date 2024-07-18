using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace reimbursement
{
    public partial class Form1 : Form
    {
        private string dbPath = "data.db"; // Путь к файлу базы данных
        private string connectionString; // Строока подключения к базе

        public Form1()
        {
            InitializeComponent();
            // Установка DataGridView в режим только для чтения
            sqlDataGridView.ReadOnly = true;
            sqlDataGridView.AllowUserToAddRows = false;
            sqlDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connectionString = $"Data Source={dbPath};Version=3;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDatabase();
            LoadData();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Reimbursements (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Compensation REAL NOT NULL,
                            Date TEXT NOT NULL
                        );";
                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void LoadData()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Reimbursements ORDER BY Date DESC;"; // Добавлено ORDER BY Date DESC
                using (var adapter = new SQLiteDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    sqlDataGridView.DataSource = dataTable;
                }
            }
            CalculateQuarterlyTotal();
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ДобавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addForm addForm = new addForm(new SQLiteConnection(connectionString));
            addForm.ShowDialog();
            LoadData(); // После закрытия addForm перезагружаем данные
        }

        private void ИзменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlDataGridView.SelectedCells.Count > 0)
            {
                int rowIndex = sqlDataGridView.SelectedCells[0].RowIndex;

                // Получение данных текущей строки
                int id = Convert.ToInt32(sqlDataGridView.Rows[rowIndex].Cells["Id"].Value);
                string name = Convert.ToString(sqlDataGridView.Rows[rowIndex].Cells["Name"].Value);
                decimal compensation = Convert.ToDecimal(sqlDataGridView.Rows[rowIndex].Cells["Compensation"].Value);
                DateTime date = Convert.ToDateTime(sqlDataGridView.Rows[rowIndex].Cells["Date"].Value);

                // Передача данных в форму Изменить
                Изменить editForm = new Изменить(id, name, compensation, date, new SQLiteConnection(connectionString));
                editForm.ShowDialog();

                // После закрытия формы Изменить перезагружаем данные
                LoadData();
            }
            else
            {
                MessageBox.Show("Не выбрана ячейка для обработки.");
            }
        }

        private void УдалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlDataGridView.SelectedCells.Count > 0)
            {
                // Получение индекса выбранной строки
                int rowIndex = sqlDataGridView.SelectedCells[0].RowIndex;

                // Отображение диалогового окна для подтверждения удаления
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(sqlDataGridView.Rows[rowIndex].Cells["Id"].Value);
                    DeleteFromDB(id);
                }
            }
            else
            {
                MessageBox.Show("Не выбрана ячейка для обработки.");
            }
        }

        private void DeleteFromDB(int id)
        {
            string deleteQuery = "DELETE FROM Reimbursements WHERE Id = @Id;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Id", id);
                    int rowsDeleted = cmd.ExecuteNonQuery();
                    if (rowsDeleted > 0)
                    {
                        MessageBox.Show("Запись успешно удалена.");
                        LoadData(); // Reload data after deletion
                    }
                    else
                    {
                        MessageBox.Show("Ошибка удаления записи из БД.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void CalculateQuarterlyTotal()
        {
            // Определение диапазона дат текущего квартала
            DateTime startDate = GetFirstDayOfQuarter(DateTime.Today);
            DateTime endDate = GetLastDayOfQuarter(DateTime.Today);

            // Формирование SQL-запроса для получения суммы
            string queryString = @"
                                    SELECT SUM(Compensation) AS TotalSum
                                    FROM Reimbursements
                                    WHERE Date BETWEEN @StartDate AND @EndDate;
                                ";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                using (SQLiteCommand cmd = new SQLiteCommand(queryString, conn))
                {
                    conn.Open();

                    // Параметры запроса: начальная и конечная даты квартала
                    cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd"));

                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        decimal totalSum = Convert.ToDecimal(result);
                        valueLabel.Text = $"{totalSum:F2} BYN";
                    }
                    else
                    {
                        valueLabel.Text = "0.00 белорусских рублей";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private DateTime GetFirstDayOfQuarter(DateTime date)
        {
            int quarter = (date.Month - 1) / 3 + 1;
            int firstMonthOfQuarter = 3 * (quarter - 1) + 1;
            return new DateTime(date.Year, firstMonthOfQuarter, 1);
        }

        private DateTime GetLastDayOfQuarter(DateTime date)
        {
            int quarter = (date.Month - 1) / 3 + 1;
            int lastMonthOfQuarter = 3 * quarter;
            int lastDay = DateTime.DaysInMonth(date.Year, lastMonthOfQuarter);
            return new DateTime(date.Year, lastMonthOfQuarter, lastDay);
        }
    }
}