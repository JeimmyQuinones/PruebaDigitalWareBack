using BackEndDigitalWare.Aplication.Commands.AddNewBill.Models;
using BackEndDigitalWare.Aplication.Queries;
using BackEndDigitalWare.Domain.Contracts;
using BackEndDigitalWare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Aplication.Commands.AddNewBill
{
    public class AddOrEditBill: IAddOrEditBill
    {
        private readonly IQueriesRepository _queriesRepository;
        private readonly IBillRepository _billRepository;
        private readonly IDetailBillRepository _detailBillRepository;
        private readonly IProductRepository _productRepository;
        private readonly List<DetailBill> _listCreateDetail;
        private readonly List<DetailBill> _listUpdateDetail;

        public AddOrEditBill(IQueriesRepository queriesRepository, 
            IBillRepository billRepository,
            IDetailBillRepository detailBillRepository,
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _detailBillRepository = detailBillRepository;
            _queriesRepository = queriesRepository;
            _billRepository = billRepository;
            _listCreateDetail = new List<DetailBill>();
            _listUpdateDetail= new List<DetailBill>();
        }
        /// <summary>
        /// Metodo encargado de Crear o Actualizar una factura y sus detalles
        /// </summary>
        /// <param name="billModel">Modelo de la factura</param>
        /// <returns></returns>
        public async Task RunAddOrEditBiil(BillCommansdModel billModel)
        {
            if (string.IsNullOrEmpty(billModel.BillId))
            {
                await AddCreateBill(billModel);
            }
            else
            {
                await AddUpdateBill(billModel);
            }
        }
        /// <summary>
        /// Metodo encargado de Actualizar una Factura y sus correspondientes detalles
        /// </summary>
        /// <param name="billModel">Modelo de la factura</param>
        /// <returns></returns>
        private async Task AddUpdateBill(BillCommansdModel billModel)
        {
            var bill = await _billRepository.BillByIdFindAsync(new Guid(billModel.BillId));
            bill.CustomerId = new Guid(billModel.CustomerId);
            bill.Date = billModel.Date;
            bill.Total = billModel.Total;
            await _billRepository.BillUpdateAsync(bill);
            List<Product> listProduct = new List<Product>();
            foreach (var item in billModel.ListDetalleAddViewModel)
            {

                listProduct= await ValidateCreateOrAddDetail(item,bill.BillId,listProduct);
            }
            await SavePorductAndDetail(listProduct);
        }

        /// Metodo encargado de Crear una Factura y sus correspondientes detalles
        /// </summary>
        /// <param name="billModel">Modelo de la factura</param>
        /// <returns></returns>
        private async Task AddCreateBill(BillCommansdModel billModel)
        {
            Bill bill = new Bill()
            {
                BillId = new Guid(),
                CustomerId = new Guid(billModel.CustomerId),
                Date = billModel.Date,
                Total = billModel.Total
            };
            await _billRepository.BillAddAsync(bill);
            List<Product> listProduct = new List<Product>();
            foreach (var item in billModel.ListDetalleAddViewModel)
            {
                listProduct = await ValidateCreateOrAddDetail(item, bill.BillId, listProduct);
            }
            await SavePorductAndDetail(listProduct);
        }

        /// <summary>
        /// Metodo encargado de guardad en la base de datos las listas de productos y detalles
        /// </summary>
        /// <param name="listProduct">lista de productos</param>
        /// <returns></returns>
        private async Task SavePorductAndDetail(List<Product> listProduct)
        {
            if(listProduct!=null && listProduct.Count > 0)
            {
                await _productRepository.ProductUpdateAsync(listProduct);
            }
            if (_listCreateDetail != null && _listCreateDetail.Count > 0)
            {
                await _detailBillRepository.DetailBillListAddAsync(_listCreateDetail);
            }
            if (_listUpdateDetail != null && _listUpdateDetail.Count > 0)
            {
                await _detailBillRepository.DetailBillListUpdateAsync(_listUpdateDetail);
            }
                
        }


        /// <summary>
        /// Metodo encargado de crear o editar el detalle de la factura 
        /// </summary>
        /// <param name="detailItem">detalle</param>
        /// <param name="billId">Identificador de la factura</param>
        /// <param name="listProduct">Lista de productos</param>
        /// <returns>Lista de productos</returns>
        private async Task<List<Product>> ValidateCreateOrAddDetail(Detail detailItem, Guid billId, List<Product> listProduct)
        {
            DetailBill detail = new DetailBill()
            {
                BillId = billId,
                ProductId = Convert.ToInt32(detailItem.ProductId),
                Amount = detailItem.Amount
            };
            if (string.IsNullOrEmpty(detailItem.DetailBillId))
            {
                
                detail.DetailBillId = new Guid();
                _listCreateDetail.Add(detail);
            }
            else
            {
                detail.DetailBillId = new Guid(detailItem.DetailBillId);
                _listUpdateDetail.Add(detail);
            }
            return  await SubtractProduct(listProduct, detail);
        }
       
        /// <summary>
        /// Resta la cantidad comprada de un producto
        /// </summary>
        /// <param name="listProduct">Lista de productos</param>
        /// <param name="detail">Detalle factura</param>
        /// <returns></returns>
        private async Task<List<Product>> SubtractProduct(List<Product> listProduct,DetailBill detail)
        {
            var existProduct = listProduct.Find(x => x.ProductId == detail.ProductId);
            if (existProduct != null)
            {
                listProduct.Find(x => x.ProductId == detail.ProductId).Amount -= detail.Amount;
            }
            else
            {
                var product = await _productRepository.ProductByIdFindAsync(detail.ProductId);
                product.Amount -= detail.Amount;
                listProduct.Add(product);
            }
            return listProduct;
        }
    }
}
