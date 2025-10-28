using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IFamiliaRepository
    {
        List<PatenteBE> GetPatentesByFamiliaId(int FamiliaId);
        List<FamiliaBE> GetFamiliasHijas(int FamiliaId);
    }
}
