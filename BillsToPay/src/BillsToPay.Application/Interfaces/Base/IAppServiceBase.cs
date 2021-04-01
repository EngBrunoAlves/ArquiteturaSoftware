﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillsToPay.Application.Interfaces
{
	public interface IAppServiceBase<TViewModel> : IDisposable where TViewModel : class
	{
		Task<TViewModel> Add(TViewModel viewModel);
		Task<TViewModel> Update(Guid id, TViewModel viewModel);
		Task Delete(Guid id);
		Task<TViewModel> Get(Guid id);
		Task<IEnumerable<TViewModel>> List();
	}
}
