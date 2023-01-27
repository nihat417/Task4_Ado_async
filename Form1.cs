using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Task3_Ado_async;

public partial class Form1 : Form
{
    IConfigurationRoot configuration = null;
    SqlConnection? conn = null;
    SqlDataReader? reader = null;
    string ConStr=string.Empty;
    
    public Form1()
    {
        InitializeComponent();
        Configure();
        AddData();
    }

    private void Configure()
    {
        string projectPath = Directory.GetCurrentDirectory().Split(@"bin\")[0];
        configuration=new ConfigurationBuilder()
            .SetBasePath(projectPath)
            .AddJsonFile("appsettings.json")
            .Build();

        ConStr = configuration.GetConnectionString("ConStr");
    }

    private void AddData()
    {
        conn = new SqlConnection(ConStr);


        try
        {
            conn.Open();
            string selcom= "\r\nSELECT NAME\r\nFROM Categories";
            SqlCommand cmd = new SqlCommand(selcom,conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CategoryCmbx.Items.Add(reader[0]);
            }
            
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
        finally
        { 
            conn?.Close();
            reader?.Close();
        }
    }

    private void CategoryCmbx_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            conn?.Open();
            string selectedString = @"
                                      Select Authors.FirstName
                                      From Books
                                      JOIN Authors ON Authors.Id=Id_Author
                                      JOIN Categories ON Id_Category=Categories.Id
                                      WHERE Categories.Name=@p1";
            using SqlCommand cmd = new SqlCommand(selectedString, conn);
            cmd.Parameters.AddWithValue("@p1", CategoryCmbx.SelectedItem.ToString());
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AuthorsCmbx.Items.Add(reader[0]);
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
        finally
        {
            conn?.Close();
            reader?.Close();
        }
    }

    private async void ExecuteBtn_Click(object sender, EventArgs e)
    {
        try
        {
            await conn?.OpenAsync();

            string selectedString = @"SELECT Books.Name,Books.Pages,Books.YearPress,Books.Comment,Books.Quantity
                                       FROM Books
                                       JOIN Authors ON Authors.Id=Id_Author
                                       JOIN Categories ON Categories.Id=Books.Id_Category
                                       WHERE Authors.FirstName=@p1 AND Categories.[Name] = @p2";

           SqlCommand command=conn.CreateCommand();
            command.Parameters.AddWithValue("@p1", AuthorsCmbx.SelectedItem.ToString());
            command.Parameters.AddWithValue("@p2", CategoryCmbx.SelectedItem.ToString());
            command.CommandText= "WAITFOR DELAY '00:00:05';";
            command.CommandText += selectedString;
            DataTable dataTable= new DataTable();

            reader = await command.ExecuteReaderAsync();
       
            int line =0;

            do
            {
                while (await reader.ReadAsync())
                {
                    if (line == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            dataTable.Columns.Add(reader.GetName(i));
                        }
                        line++;
                    }

                    DataRow row = dataTable.NewRow();

                    for (int i = 0; i < reader.FieldCount; i++)
                        row[i] = await reader.GetFieldValueAsync<object>(i);


                    dataTable.Rows.Add(row);
                }
            } while (reader.NextResult());

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataTable;
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
        finally
        {
            await conn?.CloseAsync();
            await reader?.CloseAsync();
        }
    }
}