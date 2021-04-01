namespace BillsToPay.Application.AppServices.Base
{
	using BillsToPay.Application.Interfaces;
	using BillsToPay.Domain.Entities;
	using BillsToPay.Domain.Interfaces.Services;
	using BillsToPay.Domain.Interfaces.UoW;
	using global::AutoMapper;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	internal abstract class AppServiceBase<TModel, TViewModel> : IAppServiceBase<TViewModel> where TModel : EntityBase where TViewModel : class
	{
		private readonly IServiceBase<TModel> _service;
		protected readonly IUnitOfWork _uow;
		protected readonly IMapper _mapper;
		private bool disposedValue;

		protected AppServiceBase(IServiceBase<TModel> service, IUnitOfWork uow, IMapper mapper)
		{
			_service = service;
			_uow = uow;
			_mapper = mapper;
		}

		public async Task<TViewModel> Add(TViewModel viewModel)
		{
			var entity = _mapper.Map<TModel>(viewModel);

			BeginTransaction();
			var result = await _service.Add(entity);
			Commit();

			return _mapper.Map<TViewModel>(result);
		}

		public async Task<TViewModel> Update(Guid id, TViewModel viewModel)
		{
			var entity = _mapper.Map<TModel>(viewModel);

			BeginTransaction();
			var result = await _service.Update(id, entity);
			Commit();

			return _mapper.Map<TViewModel>(result);
		}

		public async Task Delete(Guid id)
		{
			BeginTransaction();
			await _service.Delete(id);
			Commit();
		}

		public async Task<TViewModel> Get(Guid id)
		{
			var result = await _service.Get(id);

			return _mapper.Map<TViewModel>(result);
		}

		public async Task<IEnumerable<TViewModel>> List()
		{
			var result = await _service.List();

			return result
				.Select(r => _mapper.Map<TViewModel>(r))
				.ToList();
		}
		public void BeginTransaction()
		{
			_uow.BeginTransaction();
		}

		public void Commit()
		{
			_uow.Commit();
		}

		public void RollBack()
		{
			_uow.Rollback();
		}

		protected abstract void DisposeCustom();
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_service.Dispose();
					_uow.Dispose();
					DisposeCustom();
				}

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}