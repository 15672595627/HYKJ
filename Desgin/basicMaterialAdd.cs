using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Desgin
{
    public partial class basicMaterialAdd : Form
    {
        public basicMaterialAdd()
        {
            InitializeComponent();
        }
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private static string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void basicMaterialAdd_Load(object sender, EventArgs e)
        {
            this.asc.controllInitializeSize(this);
        }

        private void basicMaterialAdd_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = this.txtId.Text == "";
            if (flag)
            {
                MessageBox.Show("请输入id！");
            }
            bool flag2 = this.txtName.Text == "";
            if (flag2)
            {
                MessageBox.Show("请输入材料名称！");
            }
            bool flag3 = this.txtPinName.Text == "";
            if (flag3)
            {
                MessageBox.Show("请输入品名！");
            }
            bool flag4 = this.txtSpecs.Text == "";
            if (flag4)
            {
                MessageBox.Show("请输入材料规格！");
            }
            else
            {
                bool flag5 = this.txtId.Text != "" || this.txtName.Text != "" || this.txtPinName.Text != "" || this.txtSpecs.Text != "";
                if (flag5)
                {
                    string text = this.txtPinName.Text.Trim();
                    string text2 = this.txtId.Text.Trim();
                    string text3 = this.txtName.Text.Trim();
                    string text4 = this.txtSpecs.Text.Trim();
                    SqlConnection sqlConnection = new SqlConnection(basicMaterialAdd.SQL);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandText = "select * from basicMaterial where materialId = '" + text2 + "' and delState = 'N'";
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    bool hasRows = sqlDataReader.HasRows;
                    if (hasRows)
                    {
                        MessageBox.Show("已存在该记录，保存失败！");
                    }
                    else
                    {
                        sqlDataReader.Close();
                        SqlCommand sqlCommand2 = sqlConnection.CreateCommand();
                        sqlCommand2.CommandText = string.Concat(new string[]
                        {
                            "insert into basicMaterial (pinName,materialId,materialName,materialSpecs,delState) VALUES ('",
                            text,
                            "','",
                            text2,
                            "','",
                            text3,
                            "','",
                            text4,
                            "','N')"
                        });
                        int num = sqlCommand2.ExecuteNonQuery();
                        bool flag6 = num > 0;
                        if (flag6)
                        {
                            MessageBox.Show("保存成功！");
                        }
                        else
                        {
                            MessageBox.Show("保存失败！");
                        }
                    }
                    sqlConnection.Close();
                }
            }
        }
    }
}
