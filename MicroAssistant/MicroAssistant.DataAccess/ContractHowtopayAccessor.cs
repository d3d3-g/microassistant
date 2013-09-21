﻿/**
 * @author yangchao
 * @email:aaronyangchao@gmail.com
 * @date: 2013/8/31 14:47:38
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;
using MicroAssistant.Common;
using MicroAssistant.Meta;


namespace MicroAssistant.DataAccess
{
    public class ContractHowtopayAccessor
    {
        private MySqlCommand cmdInsertContractHowtopay;
        private MySqlCommand cmdDeleteContractHowtopay;
        private MySqlCommand cmdUpdateContractHowtopay;
        private MySqlCommand cmdLoadContractHowtopay;
        private MySqlCommand cmdLoadAllContractHowtopay;
        private MySqlCommand cmdGetContractHowtopayCount;
        private MySqlCommand cmdGetContractHowtopay;

        private ContractHowtopayAccessor()
        {
            #region cmdInsertContractHowtopay

            cmdInsertContractHowtopay = new MySqlCommand("INSERT INTO contract_howtopay(instalments_no,amount,pay_time,received_time,IsReceived) values (@InstalmentsNo,@Amount,@PayTime,@ReceivedTime,@Isreceived)");

            cmdInsertContractHowtopay.Parameters.Add("@InstalmentsNo", MySqlDbType.Int32);
            cmdInsertContractHowtopay.Parameters.Add("@Amount", MySqlDbType.Decimal);
            cmdInsertContractHowtopay.Parameters.Add("@PayTime", MySqlDbType.DateTime);
            cmdInsertContractHowtopay.Parameters.Add("@ReceivedTime", MySqlDbType.DateTime);
            cmdInsertContractHowtopay.Parameters.Add("@Isreceived", MySqlDbType.Int32);
            #endregion

            #region cmdUpdateContractHowtopay

            cmdUpdateContractHowtopay = new MySqlCommand(" update contract_howtopay set instalments_no = @InstalmentsNo,amount = @Amount,pay_time = @PayTime,received_time = @ReceivedTime,IsReceived = @Isreceived where howtopay_id = @HowtopayId");
            cmdUpdateContractHowtopay.Parameters.Add("@HowtopayId", MySqlDbType.Int32);
            cmdUpdateContractHowtopay.Parameters.Add("@InstalmentsNo", MySqlDbType.Int32);
            cmdUpdateContractHowtopay.Parameters.Add("@Amount", MySqlDbType.Decimal);
            cmdUpdateContractHowtopay.Parameters.Add("@PayTime", MySqlDbType.DateTime);
            cmdUpdateContractHowtopay.Parameters.Add("@ReceivedTime", MySqlDbType.DateTime);
            cmdUpdateContractHowtopay.Parameters.Add("@Isreceived", MySqlDbType.Int32);

            #endregion

            #region cmdDeleteContractHowtopay

            cmdDeleteContractHowtopay = new MySqlCommand(" delete from contract_howtopay where howtopay_id = @HowtopayId");
            cmdDeleteContractHowtopay.Parameters.Add("@HowtopayId", MySqlDbType.Int32);
            #endregion

            #region cmdLoadContractHowtopay

            cmdLoadContractHowtopay = new MySqlCommand(@" select howtopay_id,instalments_no,amount,pay_time,received_time,IsReceived from contract_howtopay limit @PageIndex,@PageSize");
            cmdLoadContractHowtopay.Parameters.Add("@pageIndex", MySqlDbType.Int32);
            cmdLoadContractHowtopay.Parameters.Add("@pageSize", MySqlDbType.Int32);

            #endregion

            #region cmdGetContractHowtopayCount

            cmdGetContractHowtopayCount = new MySqlCommand(" select count(*)  from contract_howtopay ");

            #endregion

            #region cmdLoadAllContractHowtopay

            cmdLoadAllContractHowtopay = new MySqlCommand(" select howtopay_id,instalments_no,amount,pay_time,received_time,IsReceived from contract_howtopay");

            #endregion

            #region cmdGetContractHowtopay

            cmdGetContractHowtopay = new MySqlCommand(" select howtopay_id,instalments_no,amount,pay_time,received_time,IsReceived from contract_howtopay where howtopay_id = @HowtopayId");
            cmdGetContractHowtopay.Parameters.Add("@HowtopayId", MySqlDbType.Int32);

            #endregion
        }

        /// <summary>
        /// 添加数据
        /// <param name="es">数据实体对象数组</param>
        /// <returns></returns>
        /// </summary>
        public bool Insert(ContractHowtopay e)
        {
            MySqlConnection oc = ConnectManager.Create();
            MySqlCommand _cmdInsertContractHowtopay = cmdInsertContractHowtopay.Clone() as MySqlCommand;
            bool returnValue = false;
            _cmdInsertContractHowtopay.Connection = oc;
            try
            {
                if (oc.State == ConnectionState.Closed)
                    oc.Open();
                _cmdInsertContractHowtopay.Parameters["@InstalmentsNo"].Value = e.InstalmentsNo;
                _cmdInsertContractHowtopay.Parameters["@Amount"].Value = e.Amount;
                _cmdInsertContractHowtopay.Parameters["@PayTime"].Value = e.PayTime;
                _cmdInsertContractHowtopay.Parameters["@ReceivedTime"].Value = e.ReceivedTime;
                _cmdInsertContractHowtopay.Parameters["@Isreceived"].Value = e.Isreceived;

                _cmdInsertContractHowtopay.ExecuteNonQuery();
                return returnValue;
            }
            finally
            {
                oc.Close();
                oc.Dispose();
                oc = null;
                _cmdInsertContractHowtopay.Dispose();
                _cmdInsertContractHowtopay = null;
            }
        }

        /// <summary>
        /// 删除数据
        /// <param name="es">数据实体对象数组</param>
        /// <returns></returns>
        /// </summary>
        public bool Delete(int HowtopayId)
        {
            MySqlConnection oc = ConnectManager.Create();
            MySqlCommand _cmdDeleteContractHowtopay = cmdDeleteContractHowtopay.Clone() as MySqlCommand;
            bool returnValue = false;
            _cmdDeleteContractHowtopay.Connection = oc;
            try
            {
                if (oc.State == ConnectionState.Closed)
                    oc.Open();
                _cmdDeleteContractHowtopay.Parameters["@HowtopayId"].Value = HowtopayId;


                _cmdDeleteContractHowtopay.ExecuteNonQuery();
                return returnValue;
            }
            finally
            {
                oc.Close();
                oc.Dispose();
                oc = null;
                _cmdDeleteContractHowtopay.Dispose();
                _cmdDeleteContractHowtopay = null;
            }
        }

        /// <summary>
        /// 修改指定的数据
        /// <param name="e">修改后的数据实体对象</param>
        /// <para>数据对应的主键必须在实例中设置</para>
        /// </summary>
        public void Update(ContractHowtopay e)
        {
            MySqlConnection oc = ConnectManager.Create();
            MySqlCommand _cmdUpdateContractHowtopay = cmdUpdateContractHowtopay.Clone() as MySqlCommand;
            _cmdUpdateContractHowtopay.Connection = oc;

            try
            {
                if (oc.State == ConnectionState.Closed)
                    oc.Open();

                _cmdUpdateContractHowtopay.Parameters["@HowtopayId"].Value = e.HowtopayId;
                _cmdUpdateContractHowtopay.Parameters["@InstalmentsNo"].Value = e.InstalmentsNo;
                _cmdUpdateContractHowtopay.Parameters["@Amount"].Value = e.Amount;
                _cmdUpdateContractHowtopay.Parameters["@PayTime"].Value = e.PayTime;
                _cmdUpdateContractHowtopay.Parameters["@ReceivedTime"].Value = e.ReceivedTime;
                _cmdUpdateContractHowtopay.Parameters["@Isreceived"].Value = e.Isreceived;

                _cmdUpdateContractHowtopay.ExecuteNonQuery();

            }
            finally
            {
                oc.Close();
                oc.Dispose();
                oc = null;
                _cmdUpdateContractHowtopay.Dispose();
                _cmdUpdateContractHowtopay = null;
                GC.Collect();
            }
        }

        /// <summary>
        /// 根据条件分页获取指定数据
        /// <param name="pageIndex">当前页</param>
        /// <para>索引从0开始</para>
        /// <param name="pageSize">每页记录条数</param>
        /// <para>记录数必须大于0</para>
        /// </summary>
        public PageEntity<ContractHowtopay> Search(Int32 HowtopayId, Int32 InstalmentsNo, Decimal Amount, DateTime PayTime, DateTime ReceivedTime, Int32 Isreceived, int pageIndex, int pageSize)
        {
            PageEntity<ContractHowtopay> returnValue = new PageEntity<ContractHowtopay>();
            MySqlConnection oc = ConnectManager.Create();
            MySqlCommand _cmdLoadContractHowtopay = cmdLoadContractHowtopay.Clone() as MySqlCommand;
            MySqlCommand _cmdGetContractHowtopayCount = cmdGetContractHowtopayCount.Clone() as MySqlCommand;
            _cmdLoadContractHowtopay.Connection = oc;
            _cmdGetContractHowtopayCount.Connection = oc;

            try
            {
                _cmdLoadContractHowtopay.Parameters["@PageIndex"].Value = pageIndex;
                _cmdLoadContractHowtopay.Parameters["@PageSize"].Value = pageSize;
                _cmdLoadContractHowtopay.Parameters["@HowtopayId"].Value = HowtopayId;
                _cmdLoadContractHowtopay.Parameters["@InstalmentsNo"].Value = InstalmentsNo;
                _cmdLoadContractHowtopay.Parameters["@Amount"].Value = Amount;
                _cmdLoadContractHowtopay.Parameters["@PayTime"].Value = PayTime;
                _cmdLoadContractHowtopay.Parameters["@ReceivedTime"].Value = ReceivedTime;
                _cmdLoadContractHowtopay.Parameters["@Isreceived"].Value = Isreceived;

                if (oc.State == ConnectionState.Closed)
                    oc.Open();

                MySqlDataReader reader = _cmdLoadContractHowtopay.ExecuteReader();
                while (reader.Read())
                {
                    returnValue.Items.Add(new ContractHowtopay().BuildSampleEntity(reader));
                }
                returnValue.RecordsCount = (int)_cmdGetContractHowtopayCount.ExecuteScalar();
            }
            finally
            {
                oc.Close();
                oc.Dispose();
                oc = null;
                _cmdLoadContractHowtopay.Dispose();
                _cmdLoadContractHowtopay = null;
                _cmdGetContractHowtopayCount.Dispose();
                _cmdGetContractHowtopayCount = null;
                GC.Collect();
            }
            return returnValue;

        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        public List<ContractHowtopay> Search()
        {
            MySqlConnection oc = ConnectManager.Create();
            MySqlCommand _cmdLoadAllContractHowtopay = cmdLoadAllContractHowtopay.Clone() as MySqlCommand;
            _cmdLoadAllContractHowtopay.Connection = oc; List<ContractHowtopay> returnValue = new List<ContractHowtopay>();
            try
            {
                _cmdLoadAllContractHowtopay.CommandText = string.Format(_cmdLoadAllContractHowtopay.CommandText, string.Empty);
                if (oc.State == ConnectionState.Closed)
                    oc.Open();

                MySqlDataReader reader = _cmdLoadAllContractHowtopay.ExecuteReader();
                while (reader.Read())
                {
                    returnValue.Add(new ContractHowtopay().BuildSampleEntity(reader));
                }
            }
            finally
            {
                oc.Close();
                oc.Dispose();
                oc = null;
                _cmdLoadAllContractHowtopay.Dispose();
                _cmdLoadAllContractHowtopay = null;
                GC.Collect();
            }
            return returnValue;
        }

        /// <summary>
        /// 获取指定记录
        /// <param name="id">Id值</param>
        /// </summary>
        public ContractHowtopay Get(int HowtopayId)
        {
            ContractHowtopay returnValue = null;
            MySqlConnection oc = ConnectManager.Create();
            MySqlCommand _cmdGetContractHowtopay = cmdGetContractHowtopay.Clone() as MySqlCommand;

            _cmdGetContractHowtopay.Connection = oc;
            try
            {
                _cmdGetContractHowtopay.Parameters["@HowtopayId"].Value = HowtopayId;

                if (oc.State == ConnectionState.Closed)
                    oc.Open();

                MySqlDataReader reader = _cmdGetContractHowtopay.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    returnValue = new ContractHowtopay().BuildSampleEntity(reader);
                }
            }
            finally
            {
                oc.Close();
                oc.Dispose();
                oc = null;
                _cmdGetContractHowtopay.Dispose();
                _cmdGetContractHowtopay = null;
                GC.Collect();
            }
            return returnValue;

        }
        private static readonly ContractHowtopayAccessor instance = new ContractHowtopayAccessor();
        public static ContractHowtopayAccessor Instance
        {
            get
            {
                return instance;
            }
        }

    }
}