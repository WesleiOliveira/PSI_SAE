using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PUC.LDSI.Application.Interfaces
{
    public interface IProfessorAppService
    {
        Task<DataResult<int>> IncluirProfessorAsync(string nome);
    }
}
