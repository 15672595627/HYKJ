﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp1
{
    public partial class Updatelog : Form
    {
        public Updatelog()
        {
            InitializeComponent();
        }


        private void GXRZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.A)
            {
                base.OnKeyDown(e);
                e.Handled = true;
            }
        }

        readonly string time1 = "2022-10-18 11:40";
        readonly string time2 = "2022-10-18 12:19";
        readonly string time3 = "2022-10-19 10:00";
        readonly string time4 = "2022-10-19 12:15";
        readonly string time5 = "2022-10-19 16:45";
        readonly string time6 = "2022-10-25 16:11";
        readonly string time7 = "2022-10-27 12:01";
        readonly string time8 = "2022-10-27 16:40";
        readonly string time9 = "2022-10-28 11:17";
        readonly string time10 = "2022-10-28 13:30";
        readonly string time11 = "2022-10-28 13:54";
        readonly string time12 = "2022-10-28 16:00";
        readonly string time13 = "2022-10-28 17:00";
        readonly string time14 = "2022-10-31 17:00";
        readonly string time15 = "2022-11-03 12:00";
        readonly string time16 = "2022-11-04 00:18";
        readonly string time17 = "2022-11-08 09:30";
        readonly string time18 = "2022-11-09 16:00";
        readonly string time19 = "2022-11-11 16:00";
        readonly string time20 = "2022-11-15 09:15";
        readonly string time21 = "2022-11-15 14:00";
        readonly string time22 = "2022-11-15 16:20";
        readonly string time23 = "2022-11-16 15:50";
        readonly string time24 = "2022-11-17 11:30";
        readonly string time25 = "2022-11-22 10:30";
        readonly string time26 = "2022-11-23 14:30";
        readonly string time27 = "2022-11-23 16:30";
        readonly string time28 = "2022-11-25 16:30";
        readonly string time29 = "2022-11-30 12:30";
        readonly string time30 = "2022-12-02 10:30";
        readonly string time31 = "2022-12-02 12:00";
        readonly string time32 = "2022-12-05 09:50";
        readonly string time33 = "2022-12-06 16:00";
        readonly string time34 = "2022-12-09 10:30";
        readonly string time35 = "2022-12-09 15:00";
        readonly string time36 = "2022-12-12 15:50";
        readonly string time37 = "2022-12-12 17:10";
        readonly string time38 = "2022-12-13 10:00";
        readonly string time39 = "2022-12-13 11:15";
        readonly string time40 = "2022-12-13 12:00";
        readonly string time41 = "2022-12-13 16:00";
        readonly string time42 = "2022-12-14 08:30";
        readonly string time43 = "2022-12-14 09:30";
        readonly string time44 = "2022-12-14 14:15";
        readonly string time45 = "2022-12-15 10:20";
        readonly string time46 = "2022-12-16 11:20";
        readonly string time47 = "2022-12-16 12:20";
        readonly string time48 = "2022-12-21 16:20";
        readonly string time49 = "2022-12-22 10:20";
        readonly string time50 = "2023-01-03 08:30";
        readonly string time51 = "2023-01-03 16:55";
        readonly string time52 = "2023-01-04 14:10";
        readonly string time53 = "2023-01-04 16:30";
        readonly string time54 = "2023-01-05 15:30";
        readonly string time55 = "2023-01-06 10:00";
        readonly string time56 = "2023-01-06 11:50";
        readonly string time57 = "2023-01-06 16:30";
        readonly string time58 = "2023-01-31 10:30";
        readonly string time59 = "2023-02-08 10:30";
        readonly string time60 = "2023-02-10 10:30";
        readonly string time61 = "2023-02-14 10:30";
        readonly string time62 = "2023-02-14 15:30";
        readonly string time63 = "2023-02-16 10:30";
        readonly string time64 = "2023-02-17 13:30";
        readonly string time65 = "2023-02-18 10:30";
        readonly string time66 = "2023-02-18 10:30";
        readonly string time67 = "2023-05-31 17:30";
        readonly string time68 = "2023-06-01 09:20";
        readonly string time69 = "2023-06-02 10:53";
        readonly string time70 = "2023-06-02 15:40";
        readonly string time71 = "2023-06-03 11:10";
        readonly string time72 = "2023-06-05 11:20";
        readonly string time73 = "2023-06-05 11:20";
        readonly string time74 = "2023-06-08 10:38";
        readonly string time75 = "2023-06-09 14:38";
        readonly string time76 = "2023-06-10 10:38";
        readonly string time77 = "2023-06-12 10:38";
        readonly string time78 = "2023-06-12 14:30";
        readonly string time79 = "2023-06-13 16:23";
        readonly string time80 = "2023-06-14 09:23";
        readonly string time81 = "2023-06-14 10:12";
        readonly string time82 = "2023-06-14 17:09";
        readonly string time83 = "2023-06-15 17:05";
        readonly string time84 = "2023-06-17 11:06";
        readonly string time85 = "2023-06-19 08:26";
        readonly string time86 = "2023-06-19 12:12";
        readonly string time87 = "2023-06-21 11:45";
        readonly string time88 = "2023-06-21 11:45";
        readonly string time89 = "2023-06-24 16:35";
        readonly string time90 = "2023-06-25 17:21";
        readonly string time91 = "2023-06-26 11:11";
        readonly string time92 = "2023-06-26 16:23";
        readonly string time93 = "2023-06-29 17:03";
        readonly string time94 = "2023-07-03 17:03";
        readonly string time95 = "2023-07-05 13:51";
        readonly string time96 = "2023-07-05 15:42";
        readonly string time97 = "2023-07-06 16:43";
        readonly string time98 = "2023-07-11 15:30";
        readonly string time99 = "2023-07-13 10:11";
        readonly string time100 = "2023-07-24 17:25";
        readonly string time101 = "2023-07-31 09:40";
        private void Updatelog_Load(object sender, EventArgs e)
        {
            GXRZ.Text = "\n" +"" + 101+
                        "\n" +"程序版本号：1.0.0.50" +
                        "\n" +"发布版本号：1.0.0.213" +
                        "\n" +"1、领料单维护" +
                        "\n" +"2、领料单打印" +
                        "\n" +"3、仓库数据的拼接" +
                        "\n" +"4、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time100 +
                        "\n" +"程序版本号：1.0.0.49" +
                        "\n" +"发布版本号：1.0.0.212" +
                        "\n" +"1、日志统计修复" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time99 +
                        "\n" +"程序版本号：1.0.0.47" +
                        "\n" +"发布版本号：1.0.0.211" +
                        "\n" +"1、导出修复" +
                        "\n" +"2、领料单维护修复" +
                        "\n" +"3、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time98 +
                        "\n" +"程序版本号：1.0.0.47" +
                        "\n" +"发布版本号：1.0.0.211" +
                        "\n" +"1、出库领料单模块" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time97 +
                        "\n" +"程序版本号：1.0.0.46" +
                        "\n" +"发布版本号：1.0.0.210" +
                        "\n" +"1、新增bom出库审核功能" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time96 +
                        "\n" +"程序版本号：1.0.0.46" +
                        "\n" +"发布版本号：1.0.0.210" +
                        "\n" +"1、修复客服税率的问题" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" +time95 +
                        "\n" +"程序版本号：1.0.0.45" +
                        "\n" +"发布版本号：1.0.0.209" +
                        "\n" +"1、修改按周统计客服部数量异常" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time94 +
                        "\n" +"程序版本号：1.0.0.44" +
                        "\n" +"发布版本号：1.0.0.208" +
                        "\n" +"1、收款单添加审核时间" +
                        "\n" +"2、禁用收款单录入日期的选择" +
                        "\n" +"3、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time93 +
                        "\n" +"程序版本号：1.0.0.43" +
                        "\n" +"发布版本号：1.0.0.207" +
                        "\n" +"1、后勤现在数据合同bug修复" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time92 +
                        "\n" +"程序版本号：1.0.0.42" +
                        "\n" +"发布版本号：1.0.0.206" +
                        "\n" +"1、基础物料维护删除功能添加" +
                        "\n" +"2、基础物料维护导出功能添加" +
                        "\n" +"3、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time91 +
                        "\n" +"程序版本号：1.0.0.42" +
                        "\n" +"发布版本号：1.0.0.206" +
                        "\n" +"1、新增基础物料bug修复" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" +time90 +
                        "\n" +"程序版本号：1.0.0.41" +
                        "\n" +"发布版本号：1.0.0.205" +
                        "\n" +"1、新增了基础数据的新增和维护功能" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" +time89+
                        "\n" +"程序版本号：1.0.0.40" +
                        "\n" +"发布版本号：1.0.0.204" +
                        "\n" +"1、添加了周统计各部门录入单数量" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" +time88+
                        "\n" +"程序版本号：1.0.0.39" +
                        "\n" +"发布版本号：1.0.0.203" +
                        "\n" +"1、设计部BOM增删查改。" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n"+time87+
                        "\n" +"程序版本号：1.0.0.39" +
                        "\n" +"发布版本号：1.0.0.203" +
                        "\n" +"1、设计部按组查询。" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +"" +
                        "\n" +"" +
                        "\n" + time86 +
                        "\n" +"程序版本号：1.0.0.38" +
                        "\n" +"发布版本号：1.0.0.202" +
                        "\n" +"1、客服部新增订单重复点击的修复。" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" + 
                        "\n" + time85 +
                        "\n" +"程序版本号：1.0.0.38" +
                        "\n" +"发布版本号：1.0.0.201" +
                        "\n" +"1、发货申请审核中时间格式的修改。" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time84 +
                        "\n" +"程序版本号：1.0.0.37" +
                        "\n" +"发布版本号：1.0.0.200" +
                        "\n" +"1、出货审核批量修改。" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time83 +
                        "\n" +"程序版本号：1.0.0.36" +
                        "\n" +"发布版本号：1.0.0.199" +
                        "\n" +"1、出货审核批量修改。" +
                        "\n" +"2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time82 +
                        "\n" + "程序版本号：" + "1.0.0.35" +
                        "\n" + "发布版本号：" + "1.0.0.198" +
                        "\n" + "1、出入库导出内容跳行的修复。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time81 +
                        "\n" + "程序版本号：" + "1.0.0.35" +
                        "\n" + "发布版本号：" + "1.0.0.197" +
                        "\n" + "1、出货维护添加修改财务时间。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time80 +
                        "\n" + "程序版本号：" + "1.0.0.35" +
                        "\n" + "发布版本号：" + "1.0.0.196" +
                        "\n" + "1、发货申请审核时间筛选当天无法筛选的修复。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time79 +
                        "\n" + "程序版本号：" + "1.0.0.34" +
                        "\n" + "发布版本号：" + "1.0.0.195" +
                        "\n" + "1、发货申请审核时间筛选修改。" +
                        "\n" + "2、出门入库维护功能的修改"+
                        "\n" + "3、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time78 +
                        "\n" + "程序版本号：" + "1.0.0.33" +
                        "\n" + "发布版本号：" + "1.0.0.194" +
                        "\n" + "1、优化了发货审核的条件的筛选。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time77 +
                        "\n" + "程序版本号：" + "1.0.0.32" +
                        "\n" + "发布版本号：" + "1.0.0.194" +
                        "\n" + "1、修复了出库时间的格式。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time76 +
                        "\n" + "程序版本号：" + "1.0.0.32" +
                        "\n" + "发布版本号：" + "1.0.0.194" +
                        "\n" + "1、修复了收款单的筛选bug。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time75 +
                        "\n" + "程序版本号：" + "1.0.0.31" +
                        "\n" + "发布版本号：" + "1.0.0.194" +
                        "\n" + "1、修复了收款单的筛选bug。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time74 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.193" +
                        "\n" + "1、修复了安月查询录入单子数量的程序bug。" +
                        "\n" + "2、修复了安天查询录入单子部分电脑查不出的bug。" +
                        "\n" + "3、对订单相关报表权限的设置。" +
                        "\n" + "4、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time73 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.192" +
                        "\n" + "1、修复了时间筛选的默认值设定。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time72 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.191" +
                        "\n" + "1、客服部批量发货申请数量不匹配修复。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time71 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.190" +
                        "\n" + "1、修复了标签和实际内容不符合的地方。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time70 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.189" +
                        "\n" + "1、修复了一下界面不美观的区域。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time69 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.188" +
                        "\n" + "1、添加了市场部反审核修改删除的权限。" +
                        "\n" + "2、添加了客服部反审核修改删除的权限。" +
                        "\n" + "3、修改了审核的流程。" +
                        "\n" + "4、删除了之前版本的审核以及批量审核的流程。" +
                        "\n" + "4、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time68 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.187" +
                        "\n" + "1、客服批量发货的bug修复。" +
                        "\n" + "2、更新了更新日志，详细记录每一次发布的内容。" +
                        "\n" +
                        "\n" +
                        "\n" + time67 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.186" +
                        "\n" + "1、客服和后勤部门数据录入添加了验证功能，不符合规定无法保存。" +
                        "\n" + "2、修复了合同批量修改过程中出现的报错。" +
                        "\n" + "3、修复了后勤在修改数据时空指针异常的报错。" +
                        "\n" + "4、修复了客服在条件查询数据说出现字符串不正确的错误。" +
                        "\n" + "5、更新了更新日志，详细记录每一次发布的内容。"+
                        "\n" +
                        "\n" +
                        "\n" + time66 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.185" +
                        "\n" + "1、修复发货申请表权限问题。" +
                        "\n" + "2、新增发货申请,申请时间。" +
                        "\n" +
                        "\n" +
                        "\n" + time65 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.184" +
                        "\n" + "1、修复排期状态不变更的问题。" +
                        "\n" + "2、新增发货申请合同编号筛选。" +
                        "\n" +
                        "\n" +
                        "\n" + time64 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.183" +
                        "\n" + "1、修复销售订单关联产品的问题。" +
                        "\n" +
                        "\n" +
                        "\n" + time63 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.182" +
                        "\n" + "1、修复PMC部分BUG。" +
                        "\n" +
                        "\n" +
                        "\n" + time62 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.176" +
                        "\n" + "1、修复出库报错。" +
                        "\n" +
                        "\n" +
                        "\n" + time61 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.175" +
                        "\n" + "1、增加出库验证入库。" +
                        "\n" + "1、增加出库单合计。" +
                        "\n" +
                        "\n" +
                        "\n" + time60 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.171" +
                        "\n" + "1、新增出库申请报表（修改/导出）。" +
                        "\n" + "2、新增销售订单中喷粉的选择。" +
                        "\n" + "3、修改PMC选单逻辑。" +
                        "\n" + "4、重复入库逻辑，增加金额作为筛选条件。" +
                        "\n" +
                        "\n" +
                        "\n" + time59 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.169" +
                        "\n" + "1、修改销售订单查看的默认时间条件。" +
                        "\n" + "2、新增合同主数据，钢材价格显示。" +
                        "\n" + "3、新增成品出库单，校验入库单的限制。" +
                        "\n" +
                        "\n" +
                        "\n" + time58 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.165" +
                        "\n" + "1、新增月录单报表。" +
                        "\n" + "2、新增订单进度追踪看板。" +
                        "\n" +
                        "\n" +
                        "\n" + time57 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.163" +
                        "\n" + "1、调整产品出库/入库结转策略。" +
                        "\n" +
                        "\n" +
                        "\n" + time56 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.162" +
                        "\n" + "1、更改生产排期单重复条件。" +
                        "\n" +
                        "\n" +
                        "\n" + time55 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.161" +
                        "\n" + "1、今日录单统计，0条数据时，显示bug的修复。" +
                        "\n" + "2、设计部录单合同的选择和公司/项目的带出。" +
                        "\n" +
                        "\n" +
                        "\n" + time54 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.159" +
                        "\n" + "1、订单录单统计显示调整。" +
                        "\n" + "2、更新部分窗口只允许打开一个的规则。" +
                        "\n" +
                        "\n" +
                        "\n" + time53 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.156" +
                        "\n" + "1、新增订单录单统计。" +
                        "\n" +
                        "\n" +
                        "\n" + time52 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.155" +
                        "\n" + "1、优化排产功能。" +
                        "\n" +
                        "\n" +
                        "\n" + time51 +
                        "\n" + "程序版本号：" + "1.0.0.30" +
                        "\n" + "发布版本号：" + "1.0.0.153" +
                        "\n" + "1、优化完毕排产功能。" +
                        "\n" + "2、显示产品出入库ID。" +
                        "\n" +
                        "\n" +
                        "\n" + time50 +
                        "\n" + "程序版本号：" + "1.0.0.29" +
                        "\n" + "发布版本号：" + "1.0.0.152" +
                        "\n" + "1、新增产品入库，无税产值结转。" +
                        "\n" + "2、修改排产计划，修改流程。" +
                        "\n" +
                        "\n" +
                        "\n" + time49 +
                        "\n" + "程序版本号：" + "1.0.0.28" +
                        "\n" + "发布版本号：" + "1.0.0.149" +
                        "\n" + "1、修复合同修改，总金额不变的bug。" +
                        "\n" +
                        "\n" +
                        "\n" + time48 +
                        "\n" + "程序版本号：" + "1.0.0.28" +
                        "\n" + "发布版本号：" + "1.0.0.148" +
                        "\n" + "1、客服部发货申请批量申请。" +
                        "\n" + "2、财务部发货申请筛选功能。" +
                        "\n" +
                        "\n" +
                        "\n" + time47 +
                        "\n" + "程序版本号：" + "1.0.0.28" +
                        "\n" + "发布版本号：" + "1.0.0.145" +
                        "\n" + "1、财务部发货申请批量审核。" +
                        "\n" + "2、即使库存新增修改功能。" +
                        "\n" + "3、销售订单修改，修复无法重置发货申请的bug。" +
                        "\n" +
                        "\n" +
                        "\n" + time46 +
                        "\n" + "程序版本号：" + "1.0.0.28" +
                        "\n" + "发布版本号：" + "1.0.0.144" +
                        "\n" + "1、产品入库/出库，月末结转逻辑更改，审核与结转分开。" +
                        "\n" +
                        "\n" +
                        "\n" + time45 +
                        "\n" + "程序版本号：" + "1.0.0.27" +
                        "\n" + "发布版本号：" + "1.0.0.142" +
                        "\n" + "1、产品入库新增加去重功能。" +
                        "\n" +
                        "\n" +
                        "\n" + time44 +
                        "\n" + "程序版本号：" + "1.0.0.27" +
                        "\n" + "发布版本号：" + "1.0.0.140" +
                        "\n" + "1、产品出库新增加去重功能。" +
                        "\n" +
                        "\n" +
                        "\n" + time43 +
                        "\n" + "程序版本号：" + "1.0.0.27" +
                        "\n" + "发布版本号：" + "1.0.0.135" +
                        "\n" + "1、界面DPI适配放缩，以免高DPI导致界面显示不全。" +
                        "\n" +
                        "\n" +
                        "\n" + time42 +
                        "\n" + "程序版本号：" + "1.0.0.27" +
                        "\n" + "发布版本号：" + "1.0.0.134" +
                        "\n" + "1、暂时取消弹窗。" +
                        "\n" +
                        "\n" +
                        "\n" + time41 +
                        "\n" + "程序版本号：" + "1.0.0.27" +
                        "\n" + "发布版本号：" + "1.0.0.133" +
                        "\n" + "1、销售订单，增加出库状态，避免重复出库。" +
                        "\n" + "1、消息中心-发货申请，管理员/财务部新增删除权限。" +
                        "\n" +
                        "\n" +
                        "\n" + time40 +
                        "\n" + "程序版本号：" + "1.0.0.27" +
                        "\n" + "发布版本号：" + "1.0.0.132" +
                        "\n" + "1、全窗口自适应适配,可以调整窗口以及最大化。" +
                        "\n" + "2、可发货的列表上以ID倒叙。" +
                        "\n" +
                        "\n" +
                        "\n" + time39 +
                        "\n" + "程序版本号：" + "1.0.0.27" +
                        "\n" + "发布版本号：" + "1.0.0.131" +
                        "\n" + "1、客服发货申请，新增发货仓库和发货物流。" +
                        "\n" + "2、消息中心同步显示，发货仓库和发货物流。" +
                        "\n" +
                        "\n" +
                        "\n" + time38 +
                        "\n" + "程序版本号：" + "1.0.0.27" +
                        "\n" + "发布版本号：" + "1.0.0.129" +
                        "\n" + "1、暂时取消弹窗，审核*出库即刷新。" +
                        "\n" +
                        "\n" +
                        "\n" + time37 +
                        "\n" + "程序版本号：" + "1.0.0.27" +
                        "\n" + "发布版本号：" + "1.0.0.127" +
                        "\n" + "1、发货申请新增出库，状态。" +
                        "\n" +
                        "\n" +
                        "\n" + time36 +
                        "\n" + "程序版本号：" + "1.0.0.27" +
                        "\n" + "发布版本号：" + "1.0.0.126" +
                        "\n" + "1、新增功能，发货申请，以及相关弹窗。" +
                        "\n" +
                        "\n" +
                        "\n" + time35 +
                        "\n" + "程序版本号：" + "1.0.0.26" +
                        "\n" + "发布版本号：" + "1.0.0.122" +
                        "\n" + "1、产品出库优化，更改入库逻辑，按照订单内容出库。" +
                        "\n" +
                        "\n" +
                        "\n" + time34 +
                        "\n" + "程序版本号：" + "1.0.0.26" +
                        "\n" + "发布版本号：" + "1.0.0.121" +
                        "\n" + "1、产品入库优化，更改入库逻辑，按照订单内容入库。" +
                        "\n" +
                        "\n" +
                        "\n" + time33 +
                        "\n" + "程序版本号：" + "1.0.0.25" +
                        "\n" + "发布版本号：" + "1.0.0.119" +
                        "\n" + "1、产品出库优化，新增字段、业务员、跟单员、含税金额,新增功能勾选隐藏列，新增部分不可写字段，以防录单员误录。" +
                        "\n" + "2、销售合同的部分功能优化。" +
                        "\n" + "3、设计部BOM单的功能优化。" +
                        "\n" + "3、产品入库单，验证入库数量来确实是否部分入库。" +
                        "\n" +
                        "\n" +
                        "\n" + time32 +
                        "\n" + "程序版本号：" + "1.0.0.24" +
                        "\n" + "发布版本号：" + "1.0.0.116" +
                        "\n" + "1、产品出库优化，新增批量审核。" +
                        "\n" +
                        "\n" +
                        "\n" + time31 +
                        "\n" + "程序版本号：" + "1.0.0.24" +
                        "\n" + "发布版本号：" + "1.0.0.113" +
                        "\n" + "1、产品入库优化，通过销售订单带出已知数据时不再报错。预置数据正常显示。" +
                        "\n" +
                        "\n" +
                        "\n" + time30 +
                        "\n" + "程序版本号：" + "1.0.0.24" +
                        "\n" + "发布版本号：" + "1.0.0.112" +
                        "\n" + "1、设计部下料单全部重新写，功能变化，新增上传图片功能。 " +
                        "\n" + "2、产品入库新增仓库，安徽/云南/重庆。 " +
                        "\n" +
                        "\n" +
                        "\n" + time29 +
                        "\n" + "程序版本号：" + "1.0.0.23" +
                        "\n" + "发布版本号：" + "1.0.0.105" +
                        "\n" + "1、修改产品出库单，审核策略，存库变更策略。 " +
                        "\n" + "2、新增功能，成本调整单。 " +
                        "\n" +
                        "\n" +
                        "\n" + time28 +
                        "\n" + "程序版本号：" + "1.0.0.22" +
                        "\n" + "发布版本号：" + "1.0.0.103" +
                        "\n" + "1、解决销售合同/销售订单，修改时录入信息不完整的问题。 " +
                        "\n" +
                        "\n" +
                        "\n" + time27 +
                        "\n" + "程序版本号：" + "1.0.0.21" +
                        "\n" + "发布版本号：" + "1.0.0.100" +
                        "\n" + "1、销售合同/销售订单，详细数据录入报错不会保存主数据。 " +
                        "\n" + "2、主程序关闭提醒。 " +
                        "\n" + "3、产品入库，产值，米数查询优化。 " +
                        "\n" +
                        "\n" +
                        "\n" + time26 +
                        "\n" + "程序版本号：" + "1.0.0.21" +
                        "\n" + "发布版本号：" + "1.0.0.97" +
                        "\n" + "1、产品入库，全面修改。 " +
                        "\n" + "2、产品出库，推翻重做。 " +
                        "\n" +
                        "\n" +
                        "\n" + time25 +
                        "\n" + "程序版本号：" + "1.0.0.20" +
                        "\n" + "发布版本号：" + "1.0.0.96" +
                        "\n" + "1、优化销售订单米数统计。 " +
                        "\n" +
                        "\n" +
                        "\n" + time24 +
                        "\n" + "程序版本号：" + "1.0.0.19" +
                        "\n" + "发布版本号：" + "1.0.0.92" +
                        "\n" + "1、优化产品入库取数逻辑。 " +
                        "\n" + "2、优化销售订单修改、更新逻辑。 " +
                        "\n" + "3、新增入库后，无法反审核。 " +
                        "\n" +
                        "\n" +
                        "\n" + time23 +
                        "\n" + "程序版本号：" + "1.0.0.19" +
                        "\n" + "发布版本号：" + "1.0.0.89" +
                        "\n" + "1、产品入库，新增不含税金额。 " +
                        "\n" + "2、销售订单，新增㎡单位的筛选。 " +
                        "\n" + "3、销售合同，修改方式的变化。。 " +
                        "\n" +
                        "\n" +
                        "\n" + time22 +
                        "\n" + "程序版本号：" + "1.0.0.18" +
                        "\n" + "发布版本号：" + "1.0.0.86" +
                        "\n" + "1、销售订单修改方式变更，双击到界面进行修改。 " +
                        "\n" + "2、销售订单list，右键功能修改，单据审核，反审核，修改，权限限制。 " +
                        "\n" +
                        "\n" +
                        "\n" + time21 +
                        "\n" + "程序版本号：" + "1.0.0.17" +
                        "\n" + "发布版本号：" + "1.0.0.85" +
                        "\n" + "1、销售订单增加期间必填项。 " +
                        "\n" + "2、产品入库，新增带出出库单位，修复发货数量录入null的问题。 " +
                        "\n" +
                        "\n" +
                        "\n" + time20 +
                        "\n" + "程序版本号：" + "1.0.0.17" +
                        "\n" + "发布版本号：" + "1.0.0.83" +
                        "\n" + "1、收款单的权限修复。 " +
                        "\n" +
                        "\n" +
                        "\n" + time19 +
                        "\n" + "程序版本号：" + "1.0.0.17" +
                        "\n" + "发布版本号：" + "1.0.0.82" +
                        "\n" + "1、优化产品入库单的录入。 " +
                        "\n" + "1、收款单权限设置，仅限财务部修改。 " +
                        "\n" +
                        "\n" +
                        "\n" + time18 +
                        "\n" + "程序版本号：" + "1.0.0.17" +
                        "\n" + "发布版本号：" + "1.0.0.81" +
                        "\n" + "1、下料单优化，主材和配件均以导入的方式。 " +
                        "\n" +
                        "\n" +
                        "\n" + time17 +
                        "\n" + "程序版本号：" + "1.0.0.16" +
                        "\n" + "发布版本号：" + "1.0.0.80" +
                        "\n" + "1、产品出库，新增部分出库功能。 " +
                        "\n" + "2、销售合同，新增美居选项，优化补单查询逻辑。 " +
                        "\n" +
                        "\n" +
                        "\n" + time16 +
                        "\n" + "程序版本号：" + "1.0.0.15" +
                        "\n" + "发布版本号：" + "1.0.0.78" +
                        "\n" + "1、产品出库单的重写。 " +
                        "\n" + "2、产品出库单逻辑的优化。 " +
                        "\n" +
                        "\n" +
                        "\n" + time15 +
                        "\n" + "程序版本号：" + "1.0.0.14" +
                        "\n" + "发布版本号：" + "1.0.0.78" +
                        "\n" + "1、销售订单单位优化。 " +
                        "\n" + "2、各个查询页面的数据合计。 " +
                        "\n" + "3、产品查询界面，增加粘贴功能，以便月底导入成本。 " +
                        "\n" + "4、合同查询界面，增加业务员查询字段。 " +
                        "\n" + "4、产品录入界面，增加部分字段的合计。 " +
                        "\n" + "4、产品查询界面，增加出库的逻辑。 " +
                        "\n" +
                        "\n" +
                        "\n" + time14 +
                        "\n" + "程序版本号：" + "1.0.0.13" +
                        "\n" + "发布版本号：" + "1.0.0.72" +
                        "\n" + "1、优化产品入库，修复部分公式除0报错的问题。 " +
                        "\n" + "2、修复销售订单，无法关联产品的问题。 " +
                        "\n" + "2、增加产品入库录单中，筛选条件的种类。 " +
                        "\n" +
                        "\n" +
                        "\n" + time13 +
                        "\n" + "程序版本号：" + "1.0.0.13" +
                        "\n" + "发布版本号：" + "1.0.0.69" +
                        "\n" + "1、库存导入优化。 " +
                        "\n" + "2、新增销售订单的米数转化功能。 " +
                        "\n" + "3、新增产品入库选择仓库功能,产值/米数的查询优化。 " +
                        "\n" + "4、修复销售订单打不开历史录单界面。 " +
                        "\n" +
                        "\n" +
                        "\n" + time12 +
                        "\n" + "程序版本号：" + "1.0.0.12" +
                        "\n" + "发布版本号：" + "1.0.0.68" +
                        "\n" + "1、修复成品入库单查询条件失效的问题。 " +
                        "\n" + "2、增加成品入库单，右键功能（修改，删除，批量审核，审核，反审核）。" +
                        "\n" + "3、增加成品入库单，合计功能。" +
                        "\n" +
                        "\n" +
                        "\n" + time11 +
                        "\n" + "程序版本号：" + "1.0.0.11" +
                        "\n" + "发布版本号：" + "1.0.0.67" +
                        "\n" + "1、修复销售订单不能反审核的问题。 " +
                        "\n" + "2、优化产品入库单导入逻辑。 " +
                        "\n" +
                        "\n" +
                        "\n" + time10 +
                        "\n" + "程序版本号：" + "1.0.0.10" +
                        "\n" + "发布版本号：" + "1.0.0.66" +
                        "\n" + "1、销售订单详细数据单位的统一，改成下拉框的形式。 " +
                        "\n" + "2、成品入库，查询订单，去掉时间条件；" +
                        "\n" + "3、总产量只计算米数 /支数/㎡，而产值则包含配件。 " +
                        "\n" +
                        "\n" +
                        "\n" + time9 +
                        "\n" + "程序版本号：" + "1.0.0.9" +
                        "\n" + "发布版本号：" + "1.0.0.65" +
                        "\n" + "1、修改产品出库保存逻辑。 " +
                        "\n" + "1、修改销售订单数量小数点。 " +
                        "\n" + "1、增加产品入库字段和部分自动计算关系。 " +
                        "\n" +
                        "\n" +
                        "\n" + time8 +
                        "\n" + "程序版本号：" + "1.0.0.8" +
                        "\n" + "发布版本号：" + "1.0.0.62" +
                        "\n" + "1、修复了，销售订单的批量审核功能。 " +
                        "\n" + "2、新增了，产品入库订单的导入功能。 " +
                        "\n" + "3、修改产品入库的单据选取逻辑。 " +
                        "\n" +
                        "\n" +
                        "\n" + time7 +
                        "\n" + "程序版本号：" + "1.0.0.7" +
                        "\n" + "发布版本号：" + "1.0.0.61" +
                        "\n" + "1、新增批量导入库存功能，新增即时库存查询功能。 " +
                        "\n" + "2、新增销售订单税率输入限制功能。" +
                        "\n" + "3、勾连入库/出库和即时库存的联系。" +
                        "\n" + "4、修复销售订单/收单批量审核失效的bug。" +
                        "\n" + "5、优化销售合同/销售订单的连带删除功能，删除主数据询问是否删除详细数据，不需要保存，以免误操作。" +
                        "\n" +
                        "\n" +
                        "\n" + time6 +
                        "\n" + "程序版本号：" + "1.0.0.6" +
                        "\n" + "发布版本号：" + "1.0.0.60" +
                        "\n" + "1、优化登录逻辑。" +
                        "\n" +
                        "\n" +
                        "\n" + time5 +
                        "\n" + "程序版本号：" + "1.0.0.5" +
                        "\n" + "发布版本号：" + "1.0.0.59" +
                        "\n" + "1、销售订单主数据/收款单，增加最后一行合计的功能。" +
                        "\n" + "2、新增销售订单/合同，批量审核功能。" +
                        "\n" + "3、修改客服销售订单单价为保留两位小数。" +
                        "\n" +
                        "\n" +
                        "\n" + time4 +
                        "\n" + "程序版本号：" + "1.0.0.4" +
                        "\n" + "发布版本号：" + "1.0.0.57" +
                        "\n" + "1、完成成品出库及出库单查看模块。" +
                        "\n" + "2、修改收款单业务员区域取值，收款单业务员/区域改成可手动修改。" +
                        "\n" +
                        "\n" +
                        "\n" + time3 +
                        "\n" + "程序版本号：" + "1.0.0.3" +
                        "\n" + "发布版本号：" + "1.0.0.56" +
                        "\n" + "1、完成成品入库及入库单查看模块。" +
                        "\n" + "2、增加问题反馈，方便收集使用过程中的各种问题和需求。" +
                        "\n" + "3、销售订单维护增加设计员显示和业务员筛选,销售内勤公司筛选增加项目名称。" +
                        "\n" + "4、修改删除逻辑，客服/内勤在删除主数据的同时会询问是否一并删除详细数据。" +
                        "\n" +
                        "\n" +
                        "\n" + time2 +
                        "\n" + "程序版本号：" + "1.0.0.2" +
                        "\n" + "发布版本号：" + "1.0.0.54" +
                        "\n" + "1、修复了销售订单保存成功，但是不显示跟单员的问题。" +
                        "\n" + "2、修改了内勤、客服增加条目的逻辑，带出大部分已知信息。" +
                        "\n" +
                        "\n" +
                        "\n" + time1 +
                        "\n" + "程序版本号：" + "1.0.0.1" +
                        "\n" + "发布版本号：" + "1.0.0.53" +
                        "\n" + "1、更新了基础资料查询修改模块，修复了之前不能使用关键字查询客户的问题。" +
                        "\n" + "2、更新了内勤、客服所需的，增加详细数据条目的功能。" +
                        "\n" + "3、更新了更新日志，详细记录每一次发布的内容。";          
        }
    }
}
