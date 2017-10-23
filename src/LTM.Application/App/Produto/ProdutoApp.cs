using LTM.Application.Interfaces;
using LTM.Application.Models;
using LTM.Infra.CrossCutting.Operations;
using LTM.Domain.Interfaces.Repositories;
using LTM.Domain.Entities;
using LTM.Application.Mapper;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LTM.Application.App
{
    public class ProdutoApp : IProdutoApp
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IAutoMapperAdapter _mapper;

        public ProdutoApp(IProdutoRepository produtoRepository, IAutoMapperAdapter mapper )
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Add(ProdutoModel poduto)
        {
            var response = new ResponseBase();
            try
            {
                Produto produtoDomain = _mapper.Adapt<ProdutoModel, Produto>(poduto);
                response.OperationResult.Id = await _produtoRepository.Add(produtoDomain);
                response.OperationResult.Status = StatusOperation.OKRESULT;
            }
            catch (Exception ex)
            {
                response.OperationResult.Status = StatusOperation.ERRORRESULT;
                response.OperationResult.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseCore<IEnumerable<ProdutoModel>>> Get(int limit, int offset)
        {
            var response = new ResponseCore<IEnumerable<ProdutoModel>>();
            try
            {
                IEnumerable<Produto> produtos = await _produtoRepository.Get(limit, offset);
                response.Data = _mapper.Adapt<IEnumerable<Produto>, IEnumerable<ProdutoModel>>(produtos);
                response.OperationResult.Status = StatusOperation.OKRESULT;
            }
            catch (Exception ex)
            {
                response.OperationResult.Status = StatusOperation.ERRORRESULT;
                response.OperationResult.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseCore<ProdutoModel>> GetById(Guid id)
        {
            var response = new ResponseCore<ProdutoModel>();
            try
            {
                Produto produto = await _produtoRepository.GetById(id);
                response.Data = _mapper.Adapt<Produto,ProdutoModel>(produto);
                response.OperationResult.Status = StatusOperation.OKRESULT;
            }
            catch (Exception ex)
            {
                response.OperationResult.Status = StatusOperation.ERRORRESULT;
                response.OperationResult.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseBase> Remove(Guid id)
        {
            var response = new ResponseCore<ProdutoModel>();
            try
            {
                await _produtoRepository.Remove(id);
                response.OperationResult.Status = StatusOperation.OKRESULT;
            }
            catch (Exception ex)
            {
                response.OperationResult.Status = StatusOperation.ERRORRESULT;
                response.OperationResult.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseBase> Update(ProdutoModel produto)
        {
            var response = new ResponseBase();
            try
            {
                Produto produtoDomain = _mapper.Adapt<ProdutoModel, Produto>(produto);
                await _produtoRepository.Update(produtoDomain);
                response.OperationResult.Status = StatusOperation.OKRESULT;
            }
            catch (Exception ex)
            {
                response.OperationResult.Status = StatusOperation.ERRORRESULT;
                response.OperationResult.Message = ex.Message;
            }
            return response;
        }
    }
}
