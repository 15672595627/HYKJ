using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Controls;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Product
{
    public partial class ProductIn : Form
    {
        public ProductIn()
        {
            InitializeComponent();
            this.dataGridView1.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e) { };
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string PI_user { get; set; }
        public string PI_group { get; set; }

        public DataTable PDI;

        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void ProductIn_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "CPRK" + time;
            DJRQ.Text = DateTime.Now.ToString("yyyy-MM-dd");
            toolStripStatusLabel2.Text = PI_user;
            toolStripStatusLabel5.Text = PI_group;
            LDY.Text = PI_user;
        }

        private void BC_Click(object sender, EventArgs e)
        {
            string djbh = DJBH.Text.Trim();
            string djrq = DJRQ.Text.Trim();
            string ldy = LDY.Text.Trim();

            SqlConnection con = new SqlConnection(SQL);

            try
            {
                con.Open();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    string xsdj = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string htbh = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string gsm = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string xmmc = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string cpmc = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string nr = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string sl = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    string dw = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    string kfdj = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    string ms = dataGridView1.Rows[i].Cells[9].Value.ToString();
                    string kfje = dataGridView1.Rows[i].Cells[10].Value.ToString();

                    string jesl = dataGridView1.Rows[i].Cells[11].Value.ToString();
                    string wscz = dataGridView1.Rows[i].Cells[12].Value.ToString();
                    string sssl = dataGridView1.Rows[i].Cells[13].Value.ToString();
                    string zsms = dataGridView1.Rows[i].Cells[14].Value.ToString();
                    string sjdj = dataGridView1.Rows[i].Cells[15].Value.ToString();
                    string shck = dataGridView1.Rows[i].Cells[16].Value.ToString();
                    string cbdj = dataGridView1.Rows[i].Cells[17].Value.ToString();
                    string cbje = dataGridView1.Rows[i].Cells[18].Value.ToString();
                    //string cwrq = dataGridView1.Rows[i].Cells["caiwuRiqi"].Value.ToString();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "select * from [dbo].[ProductIn] where product = '" + cpmc + "' and  substance = '" + nr + "' and sssl = '" + sssl + "' and kfje = '" + kfje + "'";
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    if (sdr.HasRows)
                    {
                        sdr.Close();
                        string ts = "此产品" + cpmc + "-" + nr + "已入库，保存跳过此行";
                        MessageBox.Show(ts);
                        continue;
                    }
                    else
                    {
                        sdr.Close();
                        SqlCommand cmmd = con.CreateCommand();
                        cmmd.CommandText = "INSERT INTO [dbo].[ProductIn] ([orderid],[date],[caiwuRiqi],[staffin],[sorderid],[contractid],[company],[project],[product],[substance],[sl],[dw],[kfdj],[meters],[kfje],[tax],[wscz],[sssl],[zsms],[sjdj],[shck],[cbdj],[cbje],[state],[examine],[sent]) VALUES ('" + djbh + "','" + djrq + "','"+ djrq + "','" + ldy + "','" + xsdj + "','" + htbh + "','" + gsm + "','" + xmmc + "','" + cpmc + "','" + nr + "','" + sl + "','" + dw + "','" + kfdj + "','" + ms + "','" + kfje + "','" + jesl + "','" + wscz + "','" + sssl + "','" + zsms + "','" + sjdj + "','" + shck + "','" + cbdj + "','" + cbje + "','已入库','已审核','0')";
                        int cot = cmmd.ExecuteNonQuery();
                        if (cot == 0)
                        {
                            MessageBox.Show("保存失败");
                        }
                    }
                }
                MessageBox.Show("保存成功");


                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "你还有没填完的数据。");
            }
            finally
            {
                con.Close();
            }
        }

        private void ProductIn_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = PDI;


            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["销售订单"].Visible = false;
                dataGridView1.Columns["合同编号"].Visible = false;
                dataGridView1.Columns["公司名"].Visible = false;
                dataGridView1.Columns["项目名称"].Visible = false;

                DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn();
                cb.Items.Add("一线成品仓");
                cb.Items.Add("二线成品仓");
                cb.Items.Add("三线成品仓");
                cb.Items.Add("重庆公司");
                cb.Items.Add("安徽公司");
                cb.Items.Add("云南公司");
                cb.HeaderText = "收货仓库";
                cb.Name = "收货仓库";

                dataGridView1.Columns.Add("税率", "税率");
                dataGridView1.Columns.Add("无税产值", "无税产值");
                dataGridView1.Columns.Add("实收数量", "实收数量");
                dataGridView1.Columns.Add("折算米数", "折算米数");
                dataGridView1.Columns.Add("实际单价", "实际单价");
                dataGridView1.Columns.Add(cb);
                dataGridView1.Columns.Add("成本单价", "成本单价");
                dataGridView1.Columns.Add("成本金额", "成本金额");

                dataGridView1.Columns["产品"].ReadOnly = true;
                dataGridView1.Columns["内容"].ReadOnly = true;
                dataGridView1.Columns["数量"].ReadOnly = true;
                dataGridView1.Columns["单位"].ReadOnly = true;
                dataGridView1.Columns["单价"].ReadOnly = true;
                dataGridView1.Columns["米数"].ReadOnly = true;
                dataGridView1.Columns["金额"].ReadOnly = true;
                dataGridView1.Columns["税率"].ReadOnly = true;

                if (PI_group == "资材部")
                {
                    dataGridView1.Columns["单价"].Visible = false;
                    dataGridView1.Columns["金额"].Visible = false;
                    dataGridView1.Columns["税率"].Visible = false;
                    dataGridView1.Columns["无税产值"].Visible = false;
                    dataGridView1.Columns["实际单价"].Visible = false;
                    dataGridView1.Columns["成本单价"].Visible = false;
                    dataGridView1.Columns["成本金额"].Visible = false;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string xsdj = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string strsql = "select orderid,tax from Order_h  WHERE orderid = '" + xsdj + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["税率"].Value = dt.Rows[0][1].ToString();
                    }

                    dataGridView1.Rows[i].Cells["无税产值"].Value = "0";
                    dataGridView1.Rows[i].Cells["实际单价"].Value = "0";
                    dataGridView1.Rows[i].Cells["成本单价"].Value = "0";
                    dataGridView1.Rows[i].Cells["成本金额"].Value = "0";

                }
            }
        }

        private void XZ_Click(object sender, EventArgs e)
        {
            ProductInCon pcon = new ProductInCon();
            pcon.Show(this);
        }

        private void ProductIn_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
