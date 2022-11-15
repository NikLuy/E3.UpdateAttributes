using E3.UpdateAttributes.Interfaces.E3Connector;
using E3.UpdateAttributes.Interfaces.Repository;
using E3PluginExample.Plugin.Repo.Extension;
using Ninject.Activation;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;

namespace E3.UpdateAttributes.Repository
{
    public class E3Repository : E3RepositoryBase, IE3Repository
    {
        public E3Repository(IE3Connector e3Connector) : base(e3Connector)
        {
        }

        private List<string> ConnectionSettings = new List<string>() { "Password", "Persist Security Info", "User ID", "Initial Catalog", "Data Source" };

        private string _SqlString = string.Empty;
        private string _SqlDatabase = string.Empty;
        private string _SqlTableScema = string.Empty;

        private void GetDBConnection()
        {
            object cmp, sym, cnf;
            E3App.GetDefinedDatabaseConnectionStrings(E3App.GetActualDatabase(), out cmp, out sym, out cnf);
            // "Provider=SQLOLEDB.1;Password=kks99e3;Persist Security Info=True;User ID=e3;Initial Catalog=E3_Schema;Data Source=kks17;Table Schema=E3";
            
            if(cmp != null)
            {
                var KeyVallues = cmp.ToString().Split(';');
                foreach (var item in KeyVallues)
                {
                    var pairs = item.Split('=');
                    if (pairs.Length <= 1) continue;
                    if (ConnectionSettings.Contains(pairs[0]))
                    {
                        _SqlString += $"{item};";
                    }
                    if(pairs[0] == "Table Schema")
                    {
                        _SqlTableScema = pairs[1];
                    }
                    if (pairs[0] == "Initial Catalog")
                    {
                        _SqlDatabase = pairs[1];
                    }
                }
            }
        }

        public List<string> GetAttributesFromDevice()
        {
            List<string> Attributes = new List<string>();

            if(E3Job.GetSelectedDevicesCount() == 0)
            {
                PutError(false, "Bitte ein Bauteil selektieren");
            }
            else
            {
                foreach (var device in E3Job.GetSelectedDevices())
                {
                    var AttList = GetAllAttributesFromDB(device.GetComponentName());

                    foreach (var Name in AttList)
                    {
                        if (!Attributes.Contains(Name))
                        {
                            Attributes.Add(Name);
                        }
                    }
                }
                
            }
            return Attributes;
        }
        private List<string> GetAllAttributesFromDB(string Entry)
        {
            GetDBConnection();
            var value = new List<string>();
            using (var SqlCon = new System.Data.SqlClient.SqlConnection())
            {
                SqlCon.ConnectionString = _SqlString;

                string Cmd = $"SELECT ComponentAttribute.AttributeName as AttributeName FROM {_SqlTableScema}.ComponentData " +
                    $"right join {_SqlTableScema}.ComponentAttribute on ComponentData.ID = ComponentAttribute.ID " +
                    $"where ComponentData.ENTRY = '{Entry}' and VSTATUS = 'C'";

                using (var SqlAdapter = new System.Data.SqlClient.SqlDataAdapter(Cmd, SqlCon))
                {
                    var E3Part = new System.Data.DataSet();
                    SqlAdapter.Fill(E3Part, "retVal");
                    for (int x = 0; x < E3Part.Tables["retVal"].Rows.Count; x++)
                    {
                        value.Add($"{E3Part.Tables["retVal"].Rows[x]["AttributeName"].ToString()}");
                    }
                }

                Cmd = $"SELECT * FROM {_SqlTableScema}.ComponentData " +
                  $"where ComponentData.ENTRY = '{Entry}' and VSTATUS = 'C'";

                using (var SqlAdapter = new System.Data.SqlClient.SqlDataAdapter(Cmd, SqlCon))
                {
                    var E3Part = new System.Data.DataSet();
                    SqlAdapter.Fill(E3Part, "retVal");
                    foreach (var colName in E3Part.Tables["retVal"].Columns)
                    {
                        value.Add($"{colName.ToString()}");
                    }
                }
            }
            return value;
        }

        public void UpdateDeviceAttributes(List<string> Attributes)
        {
            if (Attributes.Count < 1) return;

            #region Attribute zuweisen
            List<DeviceData> bauteile = new List<DeviceData>();

            foreach (var device in E3Job.GetAllDevices())
            {
                DeviceData bauteil;
                if (!bauteile.Any(b => b.ArticleNumber == device.GetComponentName()))
                {
                    bauteil = new DeviceData();
                    bauteil.ArticleNumber = device.GetComponentName();
                    var AttList = GetAllAttributesFromDB(bauteil.ArticleNumber);
                    foreach (var att in Attributes)
                    {
                        if (AttList.Contains(att) && !bauteil.AttributesToUpdate.Contains(att))
                        {
                            bauteil.AttributesToUpdate.Add(att);
                        }
                    }
                    GetAllValuesFromDB(ref bauteil);
                    bauteile.Add(bauteil);
                }
                else
                {
                    bauteil = bauteile.Find(b => b.ArticleNumber == device.GetComponentName());
                }

                foreach (var att in bauteil.AttributesToUpdate)
                {
                    device.SetAttributeValue(att, bauteil.GetValue(att));
                }

            }
            #endregion
            PutInfo(false,"Alle Attribute sind nun aktuell.");
        }
        public bool GetAllValuesFromDB(ref DeviceData bauteil, bool GetAllAttributes = false)
        {
            GetDBConnection();
            using (var SqlCon = new System.Data.SqlClient.SqlConnection())
            {
                SqlCon.ConnectionString = _SqlString;

                string Cmd = $"SELECT * FROM {_SqlTableScema}.ComponentData Where ENTRY ='{bauteil.ArticleNumber}' and VSTATUS = 'C'";

                using (var SqlAdapter = new System.Data.SqlClient.SqlDataAdapter(Cmd, SqlCon))
                {
                    var E3Part = new System.Data.DataSet();
                    SqlAdapter.Fill(E3Part, "retVal");
                    if (E3Part.Tables["retVal"].Rows.Count > 0)
                    {
                        for (int i = 0; i < E3Part.Tables["retVal"].Columns.Count; i++)
                        {
                            if (GetAllAttributes || bauteil.AttributesToUpdate.Contains(E3Part.Tables["retVal"].Columns[i].ColumnName))
                            {
                                bauteil.SetValue(E3Part.Tables["retVal"].Columns[i].ColumnName, E3Part.Tables["retVal"].Rows[0][i].ToString());
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                Cmd = $"SELECT ComponentAttribute.AttributeValue as AttributeValue, ComponentAttribute.AttributeName as AttributeName " +
                    $"FROM {_SqlTableScema}.ComponentData " +
                    $"right join {_SqlTableScema}.ComponentAttribute on ComponentData.ID = ComponentAttribute.ID " +
                    $"where ComponentData.ENTRY = '{bauteil.ArticleNumber}' and VSTATUS = 'C'";

                using (var SqlAdapter = new System.Data.SqlClient.SqlDataAdapter(Cmd, SqlCon))
                {
                    var E3Part = new System.Data.DataSet();
                    SqlAdapter.Fill(E3Part, "retVal");
                    for (int i = 0; i < E3Part.Tables["retVal"].Rows.Count; i++)
                    {
                        if (GetAllAttributes || bauteil.AttributesToUpdate.Contains(E3Part.Tables["retVal"].Rows[i]["AttributeName"].ToString()))
                        {
                            bauteil.SetValue(E3Part.Tables["retVal"].Rows[i]["AttributeName"].ToString(), E3Part.Tables["retVal"].Rows[i]["AttributeValue"].ToString());
                        }
                    }
                }
            }
            return true;
        }
    }
}