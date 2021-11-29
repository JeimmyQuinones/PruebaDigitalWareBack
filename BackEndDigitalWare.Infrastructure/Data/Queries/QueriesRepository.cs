using BackEndDigitalWare.Aplication.Queries;
using BackEndDigitalWare.Aplication.Queries.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Infrastructure.Data.Queries
{
    public class QueriesRepository: IQueriesRepository
    {
        private readonly string _connectionString;
        public QueriesRepository(IConfiguration config)
        {
            _connectionString = config["ConnectionStrings:DataBase"];
        }
        /// <summary>
        /// Metodo encargado de consultar la lista de facturas incluyendo el nombre del cliente y tipo de identificación
        /// </summary>
        /// <returns>lista de facturas con nombres de cliente y tipo de identificación</returns>
        public async Task<List<BillWithCustomer>> GetListBillWithCustomer()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var result = (await connection.QueryAsync<BillWithCustomer>(
                @"select B.BillId, B.CustomerId, C.IdentificationNumber,C.Name,I.Synonymous, B.Date, B.Total from DW.Bill B 
                JOIN DW.Customer C on B.CustomerId=C.CustomerId
                JOIN DW.IdentificationType I on I.IdentificationTypeId = C.IdentificationTypeId"));
            if (result.AsList().Count == 0)
                return null;
            return result.ToList();

        }
        /// <summary>
        /// Metodo encargado de consultar la lista de detalle incluyendo el nombre del producto y marca 
        /// </summary>
        /// <param name="billId"> Identificador de la factura</param>
        /// <returns>Lista de detalles de factura que incluye nombre de producto y Marca</returns>
        public async Task<List<DetailBillByBillId>> GetListDetailBillByBillId(Guid billId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            try
            {
                var result = (await connection.QueryAsync<DetailBillByBillId>(
                    @"select D.DetailBillId, D.Amount,D.ProductId, D.BillId,
                        P.Name AS ProductName,P.Price, M.Name AS MarkName ,
                        M.MarkId from  DW.DetailBill D
                        JOIN DW.Product P ON D.ProductId= P.ProductId
                        JOIN DW.Mark M ON M.MarkId=P.MarkId
                        where D.BillId='" + billId+"'"));
                if (result.AsList().Count == 0)
                    return null;
                return result.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
            

        }

        /// <summary>
        /// Metodo encargado de consultar un Cliente por tipo y numero de identificación
        /// </summary>
        /// <param name="identificationType">Tipo de identificación</param>
        /// <param name="documentNumber">Numero de identificación</param>
        /// <returns>objeto cliente</returns>
        public async Task<CustomerInfo> GetCustomerByDocumentAndType(int identificationType, string documentNumber)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            try
            {
                var result = (await connection.QueryAsync<CustomerInfo>(
                    @"select C.CustomerId,C.Name,C.IdentificationTypeId,C.IdentificationNumber,I.Synonymous AS TypeIdent from DW.Customer C
                    JOIN DW.IdentificationType I on C.IdentificationTypeId=I.IdentificationTypeId
                    WHERE C.IdentificationTypeId= "+ identificationType + "AND C.IdentificationNumber= '"+ documentNumber + "'")).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
}
