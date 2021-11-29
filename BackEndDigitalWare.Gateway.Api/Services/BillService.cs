using BackEndDigitalWare.Aplication.Commands.AddNewBill;
using BackEndDigitalWare.Aplication.Commands.AddNewBill.Models;
using BackEndDigitalWare.Aplication.Commands.DeleteBill;
using BackEndDigitalWare.Aplication.Queries;
using BackEndDigitalWare.Aplication.Queries.Models;
using BackEndDigitalWare.Gateway.Api.Services.Contracts;
using BackEndDigitalWare.Gateway.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Gateway.Api.Services
{
    public class BillService : IBillService
    {
        private readonly IQueriesRepository _queriesRepository;
        private readonly IDeleteBill _deleteBill;
        private readonly IAddOrEditBill _addOrEditBill;


        public BillService(IQueriesRepository queriesRepository,
            IDeleteBill deleteBill,
            IAddOrEditBill addOrEditBill)
        {
            _addOrEditBill = addOrEditBill;
            _deleteBill = deleteBill;
            _queriesRepository = queriesRepository;
        }
        /// <summary>
        /// Metodo encargado de buscar la lista de facturas incluyendo la  información del cliente
        /// </summary>
        /// <returns></returns>
        public async Task<List<BillWithCustomer>> FindBillList()
        {
            return await _queriesRepository.GetListBillWithCustomer();
        }
        /// <summary>
        /// Metodo encargado de buscar la lista de detalles de una factura en especifico incluyendo los detalles del producto
        /// </summary>
        /// <returns>Lista de detalles</returns>
        public async Task<List<DetailBillByBillId>> FindDetailBillList(string billId)
        {
            return await _queriesRepository.GetListDetailBillByBillId(new Guid(billId));
        }

        /// <summary>
        /// Metodo encargado de eliminar la factura y sus correspondientes detalles 
        /// </summary>
        /// <returns></returns>
        public async Task DeleteBillAndDetailOfBills(string billId)
        {
            await _deleteBill.RunDeleteBill(new Guid(billId));
        }
        /// <summary>
        /// Metodo encargado de crear o editar una factura y sus correspondientes detalles
        /// </summary>
        /// <returns></returns>
        public async Task CreateOrEditBills(BillAddViewModel billModel)
        {
            var MapperBill = MapperBillsAndDetails(billModel);
            await _addOrEditBill.RunAddOrEditBiil(MapperBill);
        }

        /// <summary>
        /// / Metodo encargado de buscar un cliente por tipo y numero de identificación
        /// </summary>
        /// <param name="identificationType"> Tipo identificación</param>
        /// <param name="documentNumber">Numero de identificación </param>
        /// <returns></returns>
        public async Task<CustomerInfo> FindCustomer(int identificationType, string documentNumber)
        {
            return await _queriesRepository.GetCustomerByDocumentAndType(identificationType, documentNumber);
        }
        /// <summary>
        /// Mapea la factura del modelo de la cama del gateway a la del api 
        /// </summary>
        /// <param name="billModel">Modelo del Gateway</param>
        /// <returns></returns>
        private BillCommansdModel MapperBillsAndDetails(BillAddViewModel billModel)
        {
            var detailList = new List<Detail>();
            foreach(var item in billModel.ListDetalleAddViewModel)
            {
                var detail = new Detail();
                detail.Amount = item.Amount;
                detail.BillId = item.BillId;
                detail.DetailBillId = item.DetailBillId;
                detail.ProductId = item.ProductId;
                detailList.Add(detail);
            }
            return new BillCommansdModel()
            {
                BillId = billModel.BillId,
                CustomerId = billModel.CustomerId,
                Date = billModel.Date,
                Total = billModel.Total,
                ListDetalleAddViewModel = detailList
            };
        }

    }
}
