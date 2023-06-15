using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1.Calc
{
    public partial class Air : Form
    {
        public Air()
        {
            InitializeComponent();
        }

        private static string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void Air_Load(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Nowtime.Text = time;
            H.Text = (0.6).ToString();
            L.Text = (1.8).ToString();
            GCJG.Text = (5600).ToString();
            YSF.Text = (300).ToString();
            GG1.Text = (32).ToString();
            GG2.Text = (32).ToString();
            GG3.Text = (32).ToString();
            GG4.Text = (32).ToString();
            GG5.Text = (32).ToString();
            GG6.Text = (32).ToString();
            GG7.Text = (19).ToString();
            GG8.Text = (19).ToString();

            ZC1.Text = (128).ToString();
            ZC2.Text = (128).ToString();
            ZC3.Text = (128).ToString();
            ZC4.Text = (76).ToString();

            FH1.Text = (1.0).ToString();
            FH2.Text = (1.0).ToString();
            FH3.Text = (1.0).ToString();
            FH4.Text = (0.8).ToString();

            HBC1.Text = (0.05).ToString();
            HBC2.Text = (0.05).ToString();
            HBC3.Text = (0.05).ToString();
            HBC4.Text = (0.3).ToString();

            JEY9.Text = (23.56).ToString();

            FYL1.Text = (0.12).ToString();
            FYL2.Text = (0.05).ToString();
            YM2.Text = (4).ToString();
            YM3.Text = (2).ToString();
            YM7.Text = (2).ToString();
            DJY5.Text = (7.5).ToString();
            DJY6.Text = (0.05).ToString();
        }

        #region 输入数字限制

        private void H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (H.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(H.Text, out oldf);
                    b2 = float.TryParse(H.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void L_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (L.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(L.Text, out oldf);
                    b2 = float.TryParse(L.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void GXJG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (GCJG.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(GCJG.Text, out oldf);
                    b2 = float.TryParse(GCJG.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void YSF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (YSF.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(YSF.Text, out oldf);
                    b2 = float.TryParse(YSF.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void FH1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (FH1.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(FH1.Text, out oldf);
                    b2 = float.TryParse(FH1.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void FH2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (FH2.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(FH2.Text, out oldf);
                    b2 = float.TryParse(FH2.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void FH3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (FH3.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(FH3.Text, out oldf);
                    b2 = float.TryParse(FH3.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void FH4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (FH4.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(FH4.Text, out oldf);
                    b2 = float.TryParse(FH4.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void HBC1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (HBC1.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(HBC1.Text, out oldf);
                    b2 = float.TryParse(HBC1.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void HBC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (HBC2.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(HBC2.Text, out oldf);
                    b2 = float.TryParse(HBC2.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void HBC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (HBC3.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(HBC3.Text, out oldf);
                    b2 = float.TryParse(HBC3.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void HBC4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (HBC4.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(HBC4.Text, out oldf);
                    b2 = float.TryParse(HBC4.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void ZC1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (ZC1.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(ZC1.Text, out oldf);
                    b2 = float.TryParse(ZC1.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void ZC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (ZC2.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(ZC2.Text, out oldf);
                    b2 = float.TryParse(ZC2.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void ZC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (ZC3.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(ZC3.Text, out oldf);
                    b2 = float.TryParse(ZC3.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void ZC4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (ZC4.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(ZC4.Text, out oldf);
                    b2 = float.TryParse(ZC4.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void DJY5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (DJY5.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(DJY5.Text, out oldf);
                    b2 = float.TryParse(DJY5.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void DJY6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (DJY6.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(DJY6.Text, out oldf);
                    b2 = float.TryParse(DJY6.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void JEY9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (JEY9.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(JEY9.Text, out oldf);
                    b2 = float.TryParse(JEY9.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void YM2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (YM2.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(YM2.Text, out oldf);
                    b2 = float.TryParse(YM2.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void YM3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (YM3.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(YM3.Text, out oldf);
                    b2 = float.TryParse(YM3.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void FYL1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (FYL1.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(FYL1.Text, out oldf);
                    b2 = float.TryParse(FYL1.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void FYL2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (FYL2.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(FYL2.Text, out oldf);
                    b2 = float.TryParse(FYL2.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void YM7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
            //小数点的处理。
            if ((int)e.KeyChar == 46) //小数点
            {
                if (YM7.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(YM7.Text, out oldf);
                    b2 = float.TryParse(YM7.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        #endregion 输入数字限制

        #region 表头输入变化

        private void H_TextChanged(object sender, EventArgs e)
        {
            if (H.Text == "" || H.Text == null)
            {
                return;
            }

            Double a;
            a = Convert.ToDouble(H.Text);
            SL2.Text = ((a - 0.032) * 3).ToString();
            SL4.Text = ((a - 0.1) * 11).ToString();
        }

        private void L_TextChanged(object sender, EventArgs e)
        {
            if (L.Text == "" || L.Text == null)
            {
                return;
            }

            double b;
            b = Convert.ToDouble(L.Text);
            SL1.Text = (b).ToString();
            SL3.Text = (b - 0.2 - 0.032 * 3).ToString();
        }

        #endregion 表头输入变化

        #region 计算按钮

        private void button1_Click(object sender, EventArgs e)
        {
            if (H.Text == "" || L.Text == "")
            {
                MessageBox.Show("请输入H或者L");
            }
            else
            {
                if (FH1.Text == "" || FH2.Text == "" || FH3.Text == "" || FH4.Text == "" || ZC1.Text == "" || ZC2.Text == "" || ZC3.Text == "" || ZC4.Text == "")
                {
                    MessageBox.Show("请输入完整的周长和粉厚数据");
                }
                else
                {
                    button2.Visible = true;
                    double a = Convert.ToDouble(ZC1.Text);
                    double b = Convert.ToDouble(ZC2.Text);
                    double c = Convert.ToDouble(ZC3.Text);
                    double d = Convert.ToDouble(ZC4.Text);
                    double f = Convert.ToDouble(FH1.Text);
                    double g = Convert.ToDouble(FH2.Text);
                    double h = Convert.ToDouble(FH3.Text);
                    double i = Convert.ToDouble(FH4.Text);
                    double j = Convert.ToDouble(SL1.Text);
                    double k = Convert.ToDouble(SL2.Text);
                    double l = Convert.ToDouble(SL3.Text);
                    double m = Convert.ToDouble(SL4.Text);
                    MZ1.Text = ((a - 4 * (f - 0.1)) * (f - 0.1) * 0.00785).ToString();
                    MZ2.Text = ((b - 4 * (g - 0.1)) * (g - 0.1) * 0.00785).ToString();
                    MZ3.Text = ((c - 4 * (h - 0.1)) * (h - 0.1) * 0.00785).ToString();
                    MZ4.Text = ((d - 4 * (i - 0.1)) * (i - 0.1) * 0.00785).ToString();
                    SL5.Text = (((a * j) + (b * k) + (c * l) + (d * m)) / 1000).ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GCJG.Text == "" || YSF.Text == "")
            {
                MessageBox.Show("请完整输入钢材价格和运输费");
            }
            else
            {
                if (DJY5.Text == "" || DJY6.Text == "")
                {
                    MessageBox.Show("请输入喷粉和损耗的单/元");
                }
                else
                {
                    button3.Visible = true;
                    double a = Convert.ToDouble(GCJG.Text);
                    double b = Convert.ToDouble(YSF.Text);
                    double ll = Convert.ToDouble(L.Text);
                    double aa = Convert.ToDouble(SL1.Text);
                    double ab = Convert.ToDouble(SL2.Text);
                    double ac = Convert.ToDouble(SL3.Text);
                    double ad = Convert.ToDouble(SL4.Text);
                    double ae = Convert.ToDouble(SL5.Text);
                    double af = Convert.ToDouble(MZ1.Text);
                    double ag = Convert.ToDouble(MZ2.Text);
                    double ah = Convert.ToDouble(MZ3.Text);
                    double ai = Convert.ToDouble(MZ4.Text);
                    DJY1.Text = ((a + b) / 1000).ToString();
                    DJY2.Text = ((a + b) / 1000).ToString();
                    DJY3.Text = ((a + b) / 1000).ToString();
                    DJY4.Text = ((a + b) / 1000).ToString();
                    double aj = Convert.ToDouble(DJY1.Text);
                    double ak = Convert.ToDouble(DJY2.Text);
                    double al = Convert.ToDouble(DJY3.Text);
                    double an = Convert.ToDouble(DJY4.Text);
                    double ao = Convert.ToDouble(DJY5.Text);
                    double ap = Convert.ToDouble(DJY6.Text);
                    double aq = Convert.ToDouble(HBC1.Text);
                    double ar = Convert.ToDouble(HBC2.Text);
                    double at = Convert.ToDouble(HBC3.Text);
                    double am = Convert.ToDouble(HBC4.Text);
                    JEY1.Text = (aa * af * (aj + aq)).ToString("0.00");
                    JEY2.Text = (ab * ag * (ak + ar)).ToString("0.00");
                    JEY3.Text = (ac * ah * (al + at)).ToString("0.00");
                    JEY4.Text = (ad * ai * (an + am)).ToString("0.00");
                    JEY5.Text = (ae * ao).ToString("0.00");
                    double c = Convert.ToDouble(JEY1.Text);
                    double d = Convert.ToDouble(JEY2.Text);
                    double f = Convert.ToDouble(JEY3.Text);
                    double g = Convert.ToDouble(JEY4.Text);
                    double h = Convert.ToDouble(JEY5.Text);
                    JEY6.Text = (((c + d + f + g + h) / 0.95) * ap).ToString("0.00");
                    double i = Convert.ToDouble(JEY6.Text);
                    JEY7.Text = (c + d + f + g + h + i).ToString();
                    double j = Convert.ToDouble(JEY7.Text);
                    JEY8.Text = (j / ll).ToString("0.00");
                    double l = Convert.ToDouble(JEY8.Text);

                    double n = Convert.ToDouble(JEY9.Text);

                    JEY10.Text = ((n / ll) - 3).ToString("0.00");

                    double m = Convert.ToDouble(JEY10.Text);

                    YM1.Text = (l + m).ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (YM2.Text == "" || YM3.Text == "")
            {
                MessageBox.Show("请输入制作费和你包装费");
            }
            else
            {
                double a = Convert.ToDouble(YM1.Text);
                double b = Convert.ToDouble(YM2.Text);
                double c = Convert.ToDouble(YM3.Text);
                double d = Convert.ToDouble(FYL1.Text);
                double f = Convert.ToDouble(FYL2.Text);
                double i = Convert.ToDouble(YM7.Text);

                YM4.Text = (((a + b + c) / (1 - d - f)) * d).ToString("0.00");
                YM5.Text = (((a + b + c) / (1 - d - f)) * f).ToString("0.00");

                double g = Convert.ToDouble(YM4.Text);
                double h = Convert.ToDouble(YM5.Text);

                YM6.Text = (a + b + c + g + h).ToString();

                double j = Convert.ToDouble(YM6.Text);
                YM8.Text = (i + j).ToString("0");
                double k = Convert.ToDouble(YM8.Text);
                YM9.Text = (k / 0.89).ToString("0.00");
            }
        }

        #endregion 计算按钮

        #region 保存

        private void button4_Click(object sender, EventArgs e)
        {
            //
            //  头表的字段定义
            //
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            string time1 = DateTime.Now.ToString("yyyyMMdd");
            string a = "BJ" + time;
            string hh = H.Text;
            string ll = L.Text;
            string b = ywy.Text;
            string c = khhgd.Text;
            string c1 = c + time1;
            string c2 = c + time;
            string d = CP.Text;
            string f = GCJG.Text;
            string g = YSF.Text;
            string h = YM8.Text;
            string i = YM9.Text;
            //
            // 明细表字段定义
            //
            //项目名称的定义
            string ba = MC1.Text; string bb = MC2.Text; string bc = MC3.Text; string bd = MC4.Text; string be = MC5.Text; string bf = MC6.Text; string bg = MC8.Text; string bh = MC10.Text; string bi = MC18.Text; string bj = MC19.Text;
            //主内容定义
            string ca = JEY1.Text; string cb = JEY2.Text; string cc = JEY3.Text; string cd = JEY4.Text; string ce = JEY5.Text; string cf = JEY6.Text; string cg = JEY8.Text; string ch = JEY10.Text; string ci = YM8.Text; string cj = YM9.Text;
            string da = GG1.Text; string db = GG2.Text; string dc = GG3.Text; string dd = GG4.Text; string de = GG5.Text; string df = GG6.Text; string dg = GG7.Text; string dh = GG8.Text;
            string aa = ZC1.Text; string ab = ZC2.Text; string ac = ZC3.Text; string ad = ZC4.Text;
            string ea = FH1.Text; string eb = FH2.Text; string ec = FH3.Text; string ed = FH4.Text;
            string fa = SL1.Text; string fb = SL2.Text; string fc = SL3.Text; string fd = SL4.Text; string fe = SL5.Text;
            string ga = MZ1.Text; string gb = MZ2.Text; string gc = MZ3.Text; string gd = MZ4.Text;
            string ha = DJY1.Text; string hb = DJY2.Text; string hc = DJY3.Text; string hd = DJY4.Text; string he = DJY5.Text; string hf = DJY6.Text;
            string ia = HBC1.Text; string ib = HBC2.Text; string ic = HBC3.Text; string id = HBC4.Text;

            //合并
            string gg1 = da + "*" + db;
            string gg2 = dc + "*" + dd;
            string gg3 = de + "*" + df;
            string gg4 = dg + "*" + dh;
            string mcgg1 = ba + gg1;
            string mcgg2 = bb + gg2;
            string mcgg3 = bc + gg3;
            string mcgg4 = bd + gg4;
            string bjgg = mcgg1 + "\n" + mcgg2 + "\n" + mcgg3 + "\n" + mcgg4;
            //
            //算计截图
            //
            string name = c2 + ".png";
            Bitmap bit = new Bitmap(this.Width, this.Height);//实例化一个和窗体一样大的bitmap
            Graphics graphics = Graphics.FromImage(bit);
            graphics.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
            graphics.CopyFromScreen(this.Left, this.Top, 0, 0, new Size(this.Width, this.Height));//保存整个窗体为图片
            bit.Save(name);//默认保存格式为PNG，保存成jpg格式质量不是很好
            string path = @name;
            //
            //
            //
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            Byte[] byteFile = new Byte[fs.Length];
            fs.Read(byteFile, 0, (int)fs.Length);
            fs.Close();

            cmd.CommandText = "INSERT INTO [dbo].[Price_h] ([Uid],[Seller],[Company],[Product],[High],[Long],[Steel],[Freight],[Amount],[AmountTAX],[FileName],[Image]) VALUES ('" + a + "','" + b + "','" + c1 + "','" + d + "','" + hh + "','" + ll + "','" + f + "','" + g + "','" + h + "','" + i + "',@FileName,@Img)";

            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@FileName", SqlDbType.NVarChar, 200);

            parameters[0].Value = path;

            parameters[1] = new SqlParameter("@Img", SqlDbType.Image, int.MaxValue);

            parameters[1].Value = byteFile;

            cmd.Parameters.AddRange(parameters);

            int count = cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO [dbo].[Price_b] ([Uid],[Project],[Specification],[Perimeter],[Thickness],[Quantity],[Meterweight],[Unitprice],[Thicknessd],[Amount]) VALUES ('" + a + "','" + ba + "','" + gg1 + "','" + aa + "','" + ea + "','" + fa + "','" + ga + "','" + ha + "','" + ia + "','" + ca + "')";

            int count1 = cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO [dbo].[Price_b] ([Uid],[Project],[Specification],[Perimeter],[Thickness],[Quantity],[Meterweight],[Unitprice],[Thicknessd],[Amount]) VALUES ('" + a + "','" + bb + "','" + gg2 + "','" + ab + "','" + eb + "','" + fb + "','" + gb + "','" + hb + "','" + ib + "','" + cb + "')";

            int count2 = cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO [dbo].[Price_b] ([Uid],[Project],[Specification],[Perimeter],[Thickness],[Quantity],[Meterweight],[Unitprice],[Thicknessd],[Amount]) VALUES ('" + a + "','" + bc + "','" + gg3 + "','" + ac + "','" + ec + "','" + fc + "','" + gc + "','" + hc + "','" + ic + "','" + cc + "')";

            int count3 = cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO [dbo].[Price_b] ([Uid],[Project],[Specification],[Perimeter],[Thickness],[Quantity],[Meterweight],[Unitprice],[Thicknessd],[Amount]) VALUES ('" + a + "','" + bd + "','" + gg4 + "','" + ad + "','" + ed + "','" + fd + "','" + gd + "','" + hd + "','" + id + "','" + cd + "')";

            int count4 = cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO [dbo].[Price_b] ([Uid],[Project],[Quantity],[Unitprice],[Amount]) VALUES ('" + a + "','" + be + "','" + fe + "','" + he + "','" + ce + "')";

            int count5 = cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO [dbo].[Price_b] ([Uid],[Project],[Unitprice],[Amount]) VALUES ('" + a + "','" + bf + "','" + hf + "','" + cf + "')";

            int count6 = cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO [dbo].[Price_b] ([Uid],[Project],[Amount]) VALUES ('" + a + "','" + bg + "','" + cg + "')";

            int count7 = cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO [dbo].[Price_b] ([Uid],[Project],[Amount]) VALUES ('" + a + "','" + bh + "','" + ch + "')";

            int count8 = cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO [dbo].[Price_b] ([Uid],[Project],[Amount]) VALUES ('" + a + "','" + bi + "','" + ci + "')";

            int count9 = cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO [dbo].[Price_b] ([Uid],[Project],[Amount]) VALUES ('" + a + "','" + bj + "','" + cj + "')";

            int count10 = cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO [dbo].[Price_e] ([Uid],[Company],[Product],[High],[Specification],[Amount]) VALUES ('" + a + "','" + c1 + "','" + d + "','" + hh + "','" + bjgg + "','" + h + "')";

            int count11 = cmd.ExecuteNonQuery();

            if (count > 0 || count1 > 0 || count2 > 0 || count3 > 0 || count4 > 0 || count5 > 0 || count6 > 0 || count7 > 0 || count8 > 0 || count9 > 0 || count10 > 0 || count11 > 0)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        #endregion 保存
    }
}