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

namespace WindowsFormsApp1.Product
{
    public partial class QuickOut : Form
    {
        public QuickOut()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        public string QO_User { get; set; }
        public string QO_Group { get; set; }
        public string QO_HTBH { get; set; }
        public string QO_GDY { get; set; }
        public string QO_GSM { get; set; }
        public string QO_XMMC { get; set; }
        public string QO_CPMC { get; set; }
        public string QO_NR { get; set; }
        public string QO_SL { get; set; }
        public string QO_DW { get; set; }
        public string QO_JE { get; set; }

        private string djbh = "CPCK" + DateTime.Now.ToString("yyyyMMddHHmmss");
        private string djrq = DateTime.Now.ToString("d");

        private void QuickOut_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);


            CPMC.Text = QO_CPMC;
            NR.Text = QO_NR;
            SL.Text = QO_SL;
            DW.Text = QO_DW;


        }

        private void QuickOut_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void BC_Click(object sender, EventArgs e)
        {
            if(FHSL.Text == "" || FHCK.Text == "")
            {
                MessageBox.Show("请填写完成数量和仓库");
            }
            else
            {
                string strsql = "select * from Order_b where productname = '" + QO_CPMC + "' and sub = '" + QO_NR + "'";
                SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                DataTable dt = new DataTable();
                da.Fill(dt);

                string xsdjbh = dt.Rows[0][1].ToString();
                string kfdj = dt.Rows[0][11].ToString();
                string ms = dt.Rows[0][12].ToString();

                string strsql1 = "select orderid,seller,tax from Order_h where orderid = '" + xsdjbh + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(strsql1, SQL);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                string ywy = dt1.Rows[0][1].ToString();
                string jesl = dt1.Rows[0][2].ToString();

                SqlConnection con = new SqlConnection(SQL);
                SqlCommand cmmd = con.CreateCommand();
                cmmd.CommandText = "select * from [dbo].[ProductOut] where product = '" + QO_CPMC + "' and  substance = '" + QO_NR + "' and fhsl = '" + FHSL.Text.Trim() + "'";
                SqlDataReader sdr = cmmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    sdr.Close();
                    string ts = "此产品" + QO_CPMC + "-" + QO_NR + "已出库，保存跳过此行";
                    MessageBox.Show(ts);
                }
                else
                {
                    sdr.Close();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO [dbo].[ProductOut] ([orderid],[date],[staffout],[sorderid],[contractid],[service],[seller],[company],[project],[product],[substance],[sl],[dw],[kfdj],[meters],[kfje],[tax],[wscz],[fhsl],[fhamount],[fhcbamount],[shck],[sent],[examine],[examine1]) values ('" + djbh + "','" + djrq + "','" + QO_User + "','-','" + QO_HTBH + "','" + QO_GDY + "','" + ywy + "','" + QO_GSM + "','" + QO_XMMC + "','" + QO_CPMC + "','" + QO_NR + "','" + QO_SL + "','" + QO_DW + "','" + kfdj + "','" + ms + "','" + QO_JE + "','" + jesl + "','0','" + FHSL.Text.Trim() + "','0','0','" + FHCK.Text + "','0','未审核','未审核')";
                    int cot = cmd.ExecuteNonQuery();
                    if (cot > 0)
                    {
                        MessageBox.Show("保存成功");
                    }
                }
            }
           



        }
    }
}
