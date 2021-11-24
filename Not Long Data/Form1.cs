using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


// 다음 프로그램 실행 선행 조건
// 대신증권 CreonPlus 설치 후, 계좌 계설 및 CreonPlus에 연결 후 Debugging Mode로 실행
// 세 개의 DataGridView에 11 줄의 호가창 생성 (삼성전자, SK하이닉스, NAVER)

// 실행하면 세 개의 호가창이 생성됩니다. 
// Handler에 변수 Passing 등, 프로그램 단순화가 가능할런지요 ? 

// Visual Studio 2017 Version

namespace Not_Long_Data
{
    public partial class Form1 : Form
    {
        private static DSCBO1Lib.StockJpbid _stockjpbid; // 대신증권 호가창 실시간 데이터 수신을 위한 API

        private static DataTable dtb1;
        private static DataTable dtb3;
        private static DataTable dtb4;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            dtb1 = new DataTable();
            dtb1.Columns.Add("매도");
            dtb1.Columns.Add("호가");
            dtb1.Columns.Add("매수");

            dtb3 = new DataTable();
            dtb3.Columns.Add("매도");
            dtb3.Columns.Add("호가");
            dtb3.Columns.Add("매수");

            dtb4 = new DataTable();
            dtb4.Columns.Add("매도");
            dtb4.Columns.Add("호가");
            dtb4.Columns.Add("매수");

            dgv1.DataSource = dtb1;
            for (int i = 0; i < 11; i++)
            {
                dtb1.Rows.Add("", "", "");
            }

            dgv3.DataSource = dtb3;
            for (int i = 0; i < 11; i++)
            {
                dtb3.Rows.Add("", "", "");
            }
            dgv4.DataSource = dtb4;
            for (int i = 0; i < 11; i++)
            {
                dtb4.Rows.Add("", "", "");
            }

            _stockjpbid = new DSCBO1Lib.StockJpbid();
            if (_stockjpbid.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            _stockjpbid.Received += new DSCBO1Lib._IDibEvents_ReceivedEventHandler(stockjpbid_Received);
            _stockjpbid.SetInputValue(0, "A005930"); // 삼성전자
            _stockjpbid.Subscribe();

            _stockjpbid.SetInputValue(0, "A000660"); // SK하이닉스
            _stockjpbid.Subscribe();

            _stockjpbid.SetInputValue(0, "A035420"); // NAVER
            _stockjpbid.Subscribe();
        }


        private static void stockjpbid_Received()
        {
            string code = _stockjpbid.GetHeaderValue(0);
            if(code == "A005930")
            {
                dtb1.Rows[4]["호가"] = _stockjpbid.GetHeaderValue(3);
                dtb1.Rows[5]["호가"] = _stockjpbid.GetHeaderValue(4);
                dtb1.Rows[4]["매도"] = _stockjpbid.GetHeaderValue(5);
                dtb1.Rows[5]["매수"] = _stockjpbid.GetHeaderValue(6);

                dtb1.Rows[3]["호가"] = _stockjpbid.GetHeaderValue(7);
                dtb1.Rows[6]["호가"] = _stockjpbid.GetHeaderValue(8);
                dtb1.Rows[3]["매도"] = _stockjpbid.GetHeaderValue(9);
                dtb1.Rows[6]["매수"] = _stockjpbid.GetHeaderValue(10);

                dtb1.Rows[2]["호가"] = _stockjpbid.GetHeaderValue(11);
                dtb1.Rows[7]["호가"] = _stockjpbid.GetHeaderValue(12);
                dtb1.Rows[2]["매도"] = _stockjpbid.GetHeaderValue(13);
                dtb1.Rows[7]["매수"] = _stockjpbid.GetHeaderValue(14);

                dtb1.Rows[1]["호가"] = _stockjpbid.GetHeaderValue(15);
                dtb1.Rows[8]["호가"] = _stockjpbid.GetHeaderValue(16);
                dtb1.Rows[1]["매도"] = _stockjpbid.GetHeaderValue(17);
                dtb1.Rows[8]["매수"] = _stockjpbid.GetHeaderValue(18);

                dtb1.Rows[0]["호가"] = _stockjpbid.GetHeaderValue(19);
                dtb1.Rows[9]["호가"] = _stockjpbid.GetHeaderValue(20);
                dtb1.Rows[0]["매도"] = _stockjpbid.GetHeaderValue(21);
                dtb1.Rows[9]["매수"] = _stockjpbid.GetHeaderValue(22);

                dtb1.Rows[10]["매도"] = _stockjpbid.GetHeaderValue(23);
                dtb1.Rows[10]["매수"] = _stockjpbid.GetHeaderValue(24);
            }

            if (code == "A000660")
            {
                dtb3.Rows[4]["호가"] = _stockjpbid.GetHeaderValue(3);
                dtb3.Rows[5]["호가"] = _stockjpbid.GetHeaderValue(4);
                dtb3.Rows[4]["매도"] = _stockjpbid.GetHeaderValue(5);
                dtb3.Rows[5]["매수"] = _stockjpbid.GetHeaderValue(6);

                dtb3.Rows[3]["호가"] = _stockjpbid.GetHeaderValue(7);
                dtb3.Rows[6]["호가"] = _stockjpbid.GetHeaderValue(8);
                dtb3.Rows[3]["매도"] = _stockjpbid.GetHeaderValue(9);
                dtb3.Rows[6]["매수"] = _stockjpbid.GetHeaderValue(10);

                dtb3.Rows[2]["호가"] = _stockjpbid.GetHeaderValue(11);
                dtb3.Rows[7]["호가"] = _stockjpbid.GetHeaderValue(12);
                dtb3.Rows[2]["매도"] = _stockjpbid.GetHeaderValue(13);
                dtb3.Rows[7]["매수"] = _stockjpbid.GetHeaderValue(14);

                dtb3.Rows[1]["호가"] = _stockjpbid.GetHeaderValue(15);
                dtb3.Rows[8]["호가"] = _stockjpbid.GetHeaderValue(16);
                dtb3.Rows[1]["매도"] = _stockjpbid.GetHeaderValue(17);
                dtb3.Rows[8]["매수"] = _stockjpbid.GetHeaderValue(18);

                dtb3.Rows[0]["호가"] = _stockjpbid.GetHeaderValue(19);
                dtb3.Rows[9]["호가"] = _stockjpbid.GetHeaderValue(20);
                dtb3.Rows[0]["매도"] = _stockjpbid.GetHeaderValue(21);
                dtb3.Rows[9]["매수"] = _stockjpbid.GetHeaderValue(22);

                dtb3.Rows[10]["매도"] = _stockjpbid.GetHeaderValue(23);
                dtb3.Rows[10]["매수"] = _stockjpbid.GetHeaderValue(24);
            }

            if (code == "A035420")
            {
                dtb4.Rows[4]["호가"] = _stockjpbid.GetHeaderValue(3);
                dtb4.Rows[5]["호가"] = _stockjpbid.GetHeaderValue(4);
                dtb4.Rows[4]["매도"] = _stockjpbid.GetHeaderValue(5);
                dtb4.Rows[5]["매수"] = _stockjpbid.GetHeaderValue(6);

                dtb4.Rows[3]["호가"] = _stockjpbid.GetHeaderValue(7);
                dtb4.Rows[6]["호가"] = _stockjpbid.GetHeaderValue(8);
                dtb4.Rows[3]["매도"] = _stockjpbid.GetHeaderValue(9);
                dtb4.Rows[6]["매수"] = _stockjpbid.GetHeaderValue(10);

                dtb4.Rows[2]["호가"] = _stockjpbid.GetHeaderValue(11);
                dtb4.Rows[7]["호가"] = _stockjpbid.GetHeaderValue(12);
                dtb4.Rows[2]["매도"] = _stockjpbid.GetHeaderValue(13);
                dtb4.Rows[7]["매수"] = _stockjpbid.GetHeaderValue(14);

                dtb4.Rows[1]["호가"] = _stockjpbid.GetHeaderValue(15);
                dtb4.Rows[8]["호가"] = _stockjpbid.GetHeaderValue(16);
                dtb4.Rows[1]["매도"] = _stockjpbid.GetHeaderValue(17);
                dtb4.Rows[8]["매수"] = _stockjpbid.GetHeaderValue(18);

                dtb4.Rows[0]["호가"] = _stockjpbid.GetHeaderValue(19);
                dtb4.Rows[9]["호가"] = _stockjpbid.GetHeaderValue(20);
                dtb4.Rows[0]["매도"] = _stockjpbid.GetHeaderValue(21);
                dtb4.Rows[9]["매수"] = _stockjpbid.GetHeaderValue(22);

                dtb4.Rows[10]["매도"] = _stockjpbid.GetHeaderValue(23);
                dtb4.Rows[10]["매수"] = _stockjpbid.GetHeaderValue(24);
            }
        }
    }
}