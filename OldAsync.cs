using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3_Ado_async;

public partial class OldAsync : Form
{
    DataTable dataTable = null;
    IConfigurationRoot configuration = null;
    SqlConnection?conn = null;
    SqlDataReader?reader = null;
    string ConStr = string.Empty;
    public OldAsync()
    {
        InitializeComponent();
        Configure();
        AddDatas();
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

    private void AddDatas()
    {
        conn = new SqlConnection(ConStr);
        SqlCommand cmd = conn.CreateCommand();
        string selcommand = "\r\nSELECT NAME\r\nFROM Categories";
        var commandtxt = "WAITFOR DELAY '00:00:02'";
        cmd.CommandText = commandtxt+selcommand;

        try
        {
            conn?.Open();

            IAsyncResult iar = cmd.BeginExecuteReader();
            WaitHandle handle = iar.AsyncWaitHandle;
            if (handle.WaitOne(10000))
            {
                GetCategories(cmd, iar);
            }
            else
            {
                MessageBox.Show("TimeOut exceeded");
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
    }

    private void GetCategories(SqlCommand command, IAsyncResult ia)
    {
        try
        {
            reader = command.EndExecuteReader(ia);
            

            int line = 0;

            do
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        {
                            CategoryCmbx.Items.Add(reader[i]);
                        }      
                    
                }
            } while (reader.NextResult());


            //dataGridView1.DataSource = dataTable;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            if (reader is not null && !reader.IsClosed)
                reader.Close();
            conn.Close();
        }
    }







    private void CategoryCmbx_SelectedIndexChanged(object sender, EventArgs e)
    {

        SqlCommand cmd = conn.CreateCommand();
        string selcommand = @"
                                      Select Authors.FirstName
                                      From Books
                                      JOIN Authors ON Authors.Id=Id_Author
                                      JOIN Categories ON Id_Category=Categories.Id
                                      WHERE Categories.Name=@p1";
        cmd.Parameters.AddWithValue("@p1", CategoryCmbx.SelectedItem.ToString());

        var commandtxt = "WAITFOR DELAY '00:00:02'";
        cmd.CommandText = commandtxt + selcommand;


        try
        {
            conn?.Open();

            IAsyncResult iar = cmd.BeginExecuteReader();
            WaitHandle handle = iar.AsyncWaitHandle;
            if (handle.WaitOne(10000))
            {
                GetAuthors(cmd, iar);
            }
            else
            {
                MessageBox.Show("TimeOut exceeded");
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
    }


    private void GetAuthors(SqlCommand command, IAsyncResult ia)
    {
        try
        {
            reader = command.EndExecuteReader(ia);


            int line = 0;

            do
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        AuthorsCmbx.Items.Add(reader[i]);
                    }

                }
            } while (reader.NextResult());


            //dataGridView1.DataSource = dataTable;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            if (reader is not null && !reader.IsClosed)
                reader.Close();
                conn.Close();
        }
    }







    private void ExecuteBtn_Click(object sender, EventArgs e)
    {

        SqlCommand cmd = conn.CreateCommand();
        var selcommand = @"SELECT Books.Name,Books.Pages,Books.YearPress,Books.Comment,Books.Quantity
                                       FROM Books
                                       JOIN Authors ON Authors.Id=Id_Author
                                       JOIN Categories ON Categories.Id=Books.Id_Category
                                       WHERE Authors.FirstName=@p1 AND Categories.[Name] = @p2";

        var commandtxt = "WAITFOR DELAY '00:00:02'";

        cmd.CommandText = commandtxt + selcommand;

        cmd.Parameters.AddWithValue("@p1", AuthorsCmbx.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@p2", CategoryCmbx.SelectedItem.ToString());

        try
        {
            conn?.Open();

            IAsyncResult iar = cmd.BeginExecuteReader();
            WaitHandle handle = iar.AsyncWaitHandle;

            //MessageBox.Show("Added thread is working...");




            if (handle.WaitOne(10000))
            {
                GetData(cmd, iar);
            }
            else
            {
                MessageBox.Show("TimeOut exceeded");
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }        
    }

    private void GetData(SqlCommand command, IAsyncResult ia)
    {
        //SqlDataReader? dataReader = null;

        try
        {
            reader = command.EndExecuteReader(ia);
            dataTable = new DataTable();

            int line = 0;

            do
            {
                while (reader.Read())
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
                    {
                        row[i] = reader[i];
                    }

                    dataTable.Rows.Add(row);
                }
            } while (reader.NextResult());


            dataGridView1.DataSource = dataTable;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            if (reader is not null && !reader.IsClosed)
                reader.Close();
                conn.Close();
        }
    }

}
